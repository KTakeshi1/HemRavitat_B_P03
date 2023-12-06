using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogueTool : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueMaster;
    [Header("Basic Setup")]
    [SerializeField][Tooltip("Drag dialogue text object from scene/hiearchy to here")]
    private TMP_Text dialogueTextObject;
    [SerializeField][Tooltip("Drag character name text object from scene/hiearchy to here")]
    private TMP_Text nameTextObject;
    [SerializeField][Tooltip("Drag character image object from scene/hiearchy to here (make sure it's blank)")]
    private Image characterImageObject;

    [Header("Text Colors Customization")]
    [SerializeField]
    private Color dialogueColor = Color.black;
    [SerializeField]
    private Color nameColor = Color.white;
    private int currentLine = 0;
    
    [Header("Dialogue Script")]
    [SerializeField]
    private Dialogue[] dialogues;
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
        dialogueTextObject.color = dialogueColor;
        nameTextObject.color = nameColor;
        dialogueTextObject.text = dialogues[currentLine].dialogue;
        nameTextObject.text = dialogues[currentLine].characterName;
        characterImageObject.sprite = dialogues[currentLine].characterImage;
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
        /*Users may handle this part in any way of their choosing, but just for all intents and purpose I will
        hide the UI once the dialogue has ended*/
        dialogueMaster.SetActive(false);
    }
}

[System.Serializable]
public class Dialogue
{
    [Header("Lines")]
    [SerializeField][Tooltip("This is where you add the name of the character")]
    public string characterName;
    [SerializeField][Tooltip("This is where you add the image for the character")]
    public Sprite characterImage;
    [SerializeField][Tooltip("This is where you add dialogue for the textbox")]
    [TextArea()]
    public string dialogue;
    
}
