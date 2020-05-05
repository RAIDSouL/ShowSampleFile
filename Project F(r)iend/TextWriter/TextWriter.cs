using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharactor;
    private float timer;
    private bool invisibleCharacters;

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharactor, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharactor = timePerCharactor;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }

    private void Update()
    {
        if(uiText != null)
        {
            timer -= Time.deltaTime;
            while(timer <= 0f)
            {
                timer += timePerCharactor;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if(invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex);
                }
                uiText.text = text;
                if(characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}
