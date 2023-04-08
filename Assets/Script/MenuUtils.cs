using System.Collections;
using System.Collections.Generic;
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
   
   private void Start() {
       gameManager = GameManager.Instance;
       gameManager.onPlayingRecordChange += UpdateText;
       gameManager.onRecordTime += UpdateText;
       UpdateText();
   }

   private void UpdateText() {
       textIsReversing.text = gameManager.isRecording  ? "live" : "past";
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
