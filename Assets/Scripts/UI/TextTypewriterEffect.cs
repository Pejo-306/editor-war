﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// reference:
// https://answers.unity.com/questions/676760/scrolling-typewriter-effect.html

public class TextTypewriterEffect : MonoBehaviour 
{
     public float timeToDisplay = 1f;
     public Text textBox;
     public string textToDisplay;
     public char cursor = '_';

     void Awake()
     {
         textBox.enabled = false;
     }

     void Start() 
     {
         textToDisplay = (textToDisplay.Length == 0) ? textBox.text : textToDisplay;
         textBox.enabled = true;
         StartCoroutine(AnimateText());
     }

     IEnumerator AnimateText()
     {
         string cursorString = cursor.ToString();
         float characterTimeFraction = timeToDisplay / (textToDisplay.Length + 1);

         for (int i = 0; i < textToDisplay.Length + 1; i++)
         {
             textBox.text = textToDisplay.Substring(0, i);
             if (i < textToDisplay.Length)
             {
                 textBox.text += cursorString;
             }
             yield return new WaitForSeconds(characterTimeFraction);
         }
     }
}

