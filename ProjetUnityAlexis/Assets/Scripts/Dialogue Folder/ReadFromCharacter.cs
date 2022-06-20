using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReadFromCharacter : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public DialogueTrigger dialogueTrigger;
    public int currentIndex;
    public GameObject panelDialogue;
    public Text nameText;
    public GameObject charImage;
    public Text dialogueText;
    public GameObject Continue;
    public GameObject endDialogueButton;
    public GameObject choiceButton1;
    public GameObject choiceButton2;
    public GameObject choiceButton3;
    public Text choice1;
    public Text choice2;
    public Text choice3;
    public Queue<string> sentences;
    public List<ChoicesStructure> ChoicesStructures;
    public bool isTalking;
    public static ReadFromCharacter instance;
    public PlayerCC PlayerCC;
    public Animator dialogueAnimator;
    public Animator fondNoirAnimator;
    public Text newSuspectText;
    public AudioClip soundToPlay;

    private void Awake()
    {        
        instance = this;
        sentences = new Queue<string>();
        isTalking = false;
    }

    private void Start()
    {
        currentIndex = 0;
    }

    public void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            isTalking = true;
            StartDialogue();
        }
        */
        if(isTalking)
        {
            ChoicesStructures = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure;
        }
        if(isTalking && Input.GetKeyDown(KeyCode.E) && sentences.Count > 0)
        {
            //ChoicesStructures = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure;
            TakeSuspect();
            DisplayNextSentence();
        }
        //ChoicesStructures = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure;

    }


    public void StartDialogue()
    {
        PlayerCC._speed = 0;
        PlayerCC._turnSpeed = 0;
        CluesInventory.instance.CloseCluesInventory();
        //.DisableDevice(Keyboard.G);
        SuspectsInventory.instance.suspectsInventory.SetActive(false);
        charImage.SetActive(false);
        panelDialogue.SetActive(true);
        fondNoirAnimator.SetBool("isOpen", true);
        dialogueAnimator.SetBool("isOpen", true);
        nameText.text = dialogueManager.charDialogue.dialogueStructure[currentIndex].nameNPC;
        charImage = dialogueManager.charDialogue.dialogueStructure[currentIndex].imageNPC;
        charImage.SetActive(true);
        Continue.SetActive(false);
        endDialogueButton.SetActive(false);
        choiceButton1.SetActive(false);
        choiceButton2.SetActive(false);
        choiceButton3.SetActive(false);
        sentences.Clear();
        foreach (var sentence in dialogueManager.charDialogue.dialogueStructure[currentIndex].sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        EventSystem.current.SetSelectedGameObject(null);
        string sentence = sentences.Dequeue();
        Continue.SetActive(false);
        endDialogueButton.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }


        if(sentences.Count >= 1)       
        {
            Continue.SetActive(true);
        }    

        if(sentences.Count == 0 && ChoicesStructures.Count == 0)       
        {
            endDialogueButton.SetActive(true);
            EventSystem.current.SetSelectedGameObject(endDialogueButton);
            if(Input.GetKeyDown(KeyCode.E))
            {
            EndDialogue();
            }
        }  

        if(sentences.Count == 0)
        {
            if(ChoicesStructures.Count == 3)
                {
                    choiceButton1.SetActive(true);
                    choiceButton2.SetActive(true);
                    choiceButton3.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(choiceButton1);
                    choice1.text = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[0].shortSentence;
                    choice2.text = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[1].shortSentence;
                    choice3.text = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[2].shortSentence;
                }
            if(ChoicesStructures.Count == 2)
                {
                    choiceButton1.SetActive(true);
                    choiceButton2.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(choiceButton1);
                    choice1.text = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[0].shortSentence;
                    choice2.text = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[1].shortSentence;
                }
            if(ChoicesStructures.Count == 1)
                {
                    choiceButton1.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(choiceButton1);
                    choice1.text = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[0].shortSentence;
                }
        }


/*
        if(sentences.Count == 0)
        {
                panelDialogue.SetActive(false);
        }
*/
    }

    public void SelectChoice1()
    {
        currentIndex = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[0].choices;
        StartDialogue();
    }

    public void SelectChoice2()
    {
        currentIndex = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[1].choices;
        StartDialogue();
    }

    public void SelectChoice3()
    {
        currentIndex = dialogueManager.charDialogue.dialogueStructure[currentIndex].choicesStructure[2].choices;
        StartDialogue();
    }

    public void EndDialogue()
    {
        fondNoirAnimator.SetBool("isOpen", false);
        dialogueAnimator.SetBool("isOpen", false);
        charImage.SetActive(false);
        isTalking = false;
        dialogueManager = null;
        dialogueTrigger = null;
        currentIndex = 0;
        PlayerCC._speed = 5;
        PlayerCC._turnSpeed = 360;

        if(ItemBubble.instance.Bubble != null && isActiveAndEnabled)
        {
            ItemBubble.instance.Bubble.SetActive(false);
            ItemBubble.instance.spriteBubble.GetComponent<SpriteRenderer>().sprite = null;
            ItemBubble.instance.bubbleItem = null;
        }
    }


    public void TakeSuspect()
    {
        if(SuspectsInventory.instance.suspectList.IndexOf(dialogueManager.charDialogue.suspect) == -1)
        {
            SuspectsInventory.instance.Add(dialogueManager.charDialogue.suspect);
            SuspectsInventory.instance.UpdateInventoryUI();
            NewSuspectText();
        }
    }

    public void NewSuspectText()
    {
        newSuspectText.enabled = true;
    }


}
