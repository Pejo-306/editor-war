using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FakeLoadingBar : MonoBehaviour
{
    public float timeToDisplay = 1f;
    public Text textBox;
    public char borderCharacter = '|';
    public char progressCharacter = '#';
    public int numberOfProgressCharacters = 10;

    void Start()
    {
        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        int progressBarLength = numberOfProgressCharacters + 2;
        string progressBar = new string(borderCharacter, 2);
        float characterTimeFraction = timeToDisplay / (progressBarLength + 1);

        for (int i = 0; i < progressBarLength + 1; i++)
        {
            textBox.text = progressBar;
            progressBar = progressBar.Insert(1, progressCharacter.ToString());
            yield return new WaitForSeconds(characterTimeFraction);
        }
    }
}

