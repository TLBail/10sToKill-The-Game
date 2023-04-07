using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUtils : MonoBehaviour
{
   private GameManager gameManager;
   [SerializeField]
   private TMPro.TMP_Text textIsReversing;
   
   
   private void Start() {
       gameManager = GameManager.Instance;
       gameManager.onReverseTime += UpdateText;
       textIsReversing.text = gameManager.isReversing ? "Time is Reversing" : "Time is not Reversing";
   }

   private void UpdateText() {
       textIsReversing.text = gameManager.isReversing ? "Time is Reversing" : "Time is not Reversing";
   }

   public void switchTimeReversing() {
       gameManager.isReversing = !gameManager.isReversing;
   }
   
   
   
   
}
