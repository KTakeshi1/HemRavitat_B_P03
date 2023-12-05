using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogueTool : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public Image characterImage;
    private int currentLine = 0;
    public Dialogue[] dialogues;
    //public Dialogue[] names;

    void Start()
    {
        ShowDialogue();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ContinueDialogue();
        }
    }

    void ShowDialogue()
    {
        dialogueText.text = dialogues[currentLine].dialogue;
        nameText.text = dialogues[currentLine].characterName;
        characterImage.sprite = dialogues[currentLine].speakerImage;
    }

    public void ContinueDialogue()
    {
        currentLine++;

        if (currentLine < dialogues.Length)
        {
            ShowDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        
    }
}

[System.Serializable]
public class Dialogue
{
    public string characterName;
    public string dialogue;
    public Sprite speakerImage;
}
