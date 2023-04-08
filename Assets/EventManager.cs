using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

[Serializable]
public class ImpactPosition
{
    public string name;
    public Transform transform;
}

public class EventManager : MonoBehaviour
{

    [SerializeField] private Light gameLight;
    [SerializeField] private Material skyboxMaterial;
    [SerializeField] private GameObject uiInRecording;
    [SerializeField] private GameObject uiChoosingEvents;
    [SerializeField] private Object prefabButtonEventToAdd;
    [SerializeField] private GameObject holderButtonEventToAdd;
    [SerializeField] private GameObject holderButtonEventAdded;
    [SerializeField] private List<ImpactPosition> impactPositions;
    [SerializeField] private Transform defaultImpactPosition;
    [SerializeField] private BulletController bulletController;
    [SerializeField] private Object prefabCollisionWall;
    
    public Dictionary<string, Transform> impactPositionDictionary = new Dictionary<string, Transform>();

    public List<GameEvent> eventsAvailable = new List<GameEvent>()
    {
        new GameEventNight()
    };
    private void Start() {
        foreach (ImpactPosition impactPosition in impactPositions) {
            impactPositionDictionary.Add(impactPosition.name, impactPosition.transform);
        }
        
        UpdateList();
    }

    private void UpdateList() {
        //clear list
        foreach (var button in holderButtonEventToAdd.GetComponentsInChildren<UnityEngine.UI.Button>()) {
            Destroy(button.gameObject);
        }
        foreach (var button in holderButtonEventAdded.GetComponentsInChildren<UnityEngine.UI.Button>()) {
            Destroy(button.gameObject);
        }
            
        
        
        
        foreach (GameEvent gameEvent in eventsAvailable) {
            GameObject button = Instantiate(prefabButtonEventToAdd, holderButtonEventToAdd.transform) as GameObject;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = gameEvent.eventName;
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                GameManager.Instance.events.Add(gameEvent);
                eventsAvailable.Remove(gameEvent);
                UpdateList();

            });
        }

        foreach (GameEvent gameEvent in GameManager.Instance.events) {
            GameObject button = Instantiate(prefabButtonEventToAdd, holderButtonEventAdded.transform) as GameObject;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = gameEvent.eventName;
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                GameManager.Instance.events.Remove(gameEvent);
                eventsAvailable.Add(gameEvent);
                UpdateList();

            });
        }
    }


    public void validateEvents() {
        //inits Events
        foreach (GameEvent gameEvent in GameManager.Instance.events) {
            gameEvent.init(this);
            foreach (SubEvent subEvent in gameEvent.SubEvents) {
                GameObject collisionWall = Instantiate(prefabCollisionWall, subEvent.Position, Quaternion.identity) as GameObject;
                collisionWall.GetComponent<CollidingScript>().actionOnCollision = subEvent.Action;
            }
        }
        
        
        
        GameManager.Instance.impactPosition = defaultImpactPosition.position; 
        foreach (GameEvent gameEvent in GameManager.Instance.events) {
            gameEvent.triggerEvent(this);
            if (gameEvent.positionImpactName != "") {
                GameManager.Instance.impactPosition = impactPositionDictionary[gameEvent.positionImpactName].position;
            }
        }
        
        bulletController.updateVector();
        uiChoosingEvents.SetActive(false);
        uiInRecording.SetActive(true);
        GameManager.Instance.StartShooting();
    }
    
    

    public void setNight() {
        gameLight.color = new Color(0.1f, 0.1f, 0.1f);
        gameLight.intensity = 0.1f;
        RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
        RenderSettings.fogColor = new Color(0.1f, 0.1f, 0.1f);
        RenderSettings.skybox = skyboxMaterial;
    }

    public void stopRecord() {
        GameManager.Instance.isRecording = false;
    }
}
