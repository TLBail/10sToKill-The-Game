using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUtils : MonoBehaviour
{
   private GameManager gameManager;
   [SerializeField]
   private TMPro.TMP_Text textIsReversing;

   [SerializeField] private TMPro.TMP_Text textIsRecording;
   [SerializeField] private Slider slider;
   
   private void Start() {
       gameManager = GameManager.Instance;
       gameManager.onPlayingRecordChange += UpdateText;
       gameManager.onRecordTime += UpdateText;
       UpdateText();
   }

   private void UpdateText() {
       textIsReversing.text = gameManager.isPlayingRecord == -1 ? "Time is Reversing" : "Time is not Reversing";
       textIsRecording.text = gameManager.isRecording ? "Time is Recording" : "Time is not Recording";
   }

   public void switchTimeReversing() {
       gameManager.isPlayingRecord = gameManager.isPlayingRecord != 0 ? 0 : 1;
   }

   public void playPauseRecord() {
       gameManager.isPlayingRecord = gameManager.isPlayingRecord != 0 ? 0 : -1;
   }

   public void setPlayingRecordSpeed() {
       gameManager.isPlayingRecord = (int)slider.value;
   }
   
   
   public void switchTimeRecording() {
       gameManager.isRecording = !gameManager.isRecording;
   }
   
   
}
