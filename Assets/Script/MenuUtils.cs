using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuUtils : MonoBehaviour
{
   private GameManager gameManager;
   [SerializeField]
   private TMPro.TMP_Text textIsReversing;

   [FormerlySerializedAs("slider")] [SerializeField] private Slider sliderTime;
   [SerializeField] private Slider sliderSlowdownFactor;
   [SerializeField] private List<GameObject> buttonToAddEvent;
   [SerializeField] private GameObject uiSelectEvents;
   [SerializeField] private EventManager eventManager;
   private void Start() {
       gameManager = GameManager.Instance;
       List<GameEvent> randomEvents = new List<GameEvent>();
       for (int i = 0; i < 3; i++) {
           if(GameManager.Instance.allGameEvents.Count == 0) break;
           int index = 0;
           GameEvent gameEvent = null;
           while (true) {
               if (index >= GameManager.Instance.allGameEvents.Count) {
                   break;
               }
               GameEvent myEvent = GameManager.Instance.allGameEvents[index];
               if(randomEvents.Contains(myEvent)) {
                   index++;
                   continue;
               } else {
                   gameEvent = myEvent;
                   randomEvents.Add(gameEvent);
                   break;
               }
           }

           if (gameEvent == null) {
               break;
           }
           buttonToAddEvent[i].SetActive(true);
           buttonToAddEvent[i].GetComponentInChildren<TMP_Text>().SetText(gameEvent.eventName);
           buttonToAddEvent[i].GetComponent<UnityEngine.UI.Button>().onClick.AddListener (() => {
               GameManager.Instance.selectedGameEvents.Add(gameEvent);
               GameManager.Instance.allGameEvents.Remove(gameEvent);
               buttonToAddEvent[0].transform.parent.gameObject.SetActive(false);
               uiSelectEvents.SetActive(true);
               eventManager.eventsForSelection(GameManager.Instance.selectedGameEvents);
           });
       }
       
       
   }

   public void passButton() {
       uiSelectEvents.SetActive(true);
       eventManager.eventsForSelection(GameManager.Instance.selectedGameEvents);
       buttonToAddEvent[0].transform.parent.gameObject.SetActive(false);
   }

   private void Update() {
       textIsReversing.text = gameManager.isRecording  ? "live : " + GameManager.Instance.elpasedTime  : "past";
   }

   public void switchTimeReversing() {
       gameManager.isPlayingRecord = gameManager.isPlayingRecord != 0 ? 0 : 1;
   }

   public void playPauseRecord() {
       gameManager.isPlayingRecord = gameManager.isPlayingRecord != 0 ? 0 : -1;
   }

   public void setPlayingRecordSpeed() {
       gameManager.isPlayingRecord = (int)sliderTime.value;
   }


   public void setTimeSlowdownFactor() {
       gameManager.slowdowFactor = sliderSlowdownFactor.value;
   }
   
   public void switchTimeRecording() {
       gameManager.isRecording = !gameManager.isRecording;
   }
   
   
   public void restartGame() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   
}
