using UnityEngine;
using UnityEngine.UI;

public class DisplayContinues : MonoBehaviour
{
    public Text textBox;
    public string continuesPlaceholderString;

    void Awake()
    {
        string textToDisplay = textBox.text.Replace(continuesPlaceholderString,
                PersistantGameManager.Instance.GetLeftoverContinues().ToString());

        textBox.text = textToDisplay;
    }
}

