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
    [SerializeField] private List<GameObject> gameObjectsFamous;

    public Dictionary<string, GameObject> famousGameObjectDictionary = new Dictionary<string, GameObject>();
    public Dictionary<string, Transform> impactPositionDictionary = new Dictionary<string, Transform>();

    private List<GameEvent> eventsAvailable = new List<GameEvent>()
    {
        new GameEventNight(),
        new GameEventGrêve(),
        new GameEventBraquage()
    };
    private void Start() {
        foreach (ImpactPosition impactPosition in impactPositions) {
            impactPositionDictionary.Add(impactPosition.name, impactPosition.transform);
        }
        foreach (GameObject gameObject in gameObjectsFamous) {
            famousGameObjectDictionary.Add(gameObject.name, gameObject);
        }

        foreach (GameObject gameObjectFamous in gameObjectsFamous) {
            if (gameObjectFamous.TryGetComponent(typeof(CollidingScript), out var component)) {
                gameObjectFamous.GetComponent<CollidingScript>().actionOnCollision = () =>
                {   
                    stopRecord();
                };   
            }
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

    public void setImpactPosition(string impactName) {
        GameManager.Instance.impactPosition = impactPositionDictionary[impactName].position;
        bulletController.updateVector();
    }
    

    public void setActiveFamousGameObject(string name, bool active) {
        famousGameObjectDictionary[name]?.SetActive(active);
    }
}
