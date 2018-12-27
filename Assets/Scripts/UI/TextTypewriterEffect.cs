using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// reference:
// https://answers.unity.com/questions/676760/scrolling-typewriter-effect.html

public class TextTypewriterEffect : MonoBehaviour 
{
     public float timeToDisplay = 1f;
     private Text textBox;

     void Awake() 
     {
         textBox = GetComponent<Text>();
         StartCoroutine(AnimateText());
     }

     IEnumerator AnimateText()
     {
         string textToDisplay = textBox.text;
         float characterTimeFraction = timeToDisplay / (textToDisplay.Length + 1);

         for (int i = 0; i < textToDisplay.Length + 1; i++)
         {
             textBox.text = textToDisplay.Substring(0, i);
             if (i < textToDisplay.Length)
             {
                 textBox.text += "_";
             }
             yield return new WaitForSeconds(characterTimeFraction);
         }
     }
}

