using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadFromCharacter : MonoBehaviour
{

    public DialogueManager dialogueManager;
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
    public Animator animator;
    public DialogueTrigger dialogueTrigger;

    private void Awake()
    {        
        instance = this;
        sentences = new Queue<string>();
        isTalking = false;
    }

    private void Start()
    {
        currentIndex = 0;
        ChoicesStructures = dialogueTrigger.DialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure;
    }

    public void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            isTalking = true;
            StartDialogue();
        }
        */
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isTalking = true;
            if(isTalking)
            DisplayNextSentence();
        }
        ChoicesStructures = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure;

    }


    public void StartDialogue()
    {
        PlayerCC._speed = 0;
        panelDialogue.SetActive(true);
        animator.SetBool("isOpen", true);
        nameText.text = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].nameNPC;
        charImage = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].imageNPC;
        charImage.SetActive(true);
        Continue.SetActive(false);
        endDialogueButton.SetActive(false);
        choiceButton1.SetActive(false);
        choiceButton2.SetActive(false);
        choiceButton3.SetActive(false);
        sentences.Clear();
        Debug.Log("Index StartDialogue N° " + currentIndex);
        foreach (var sentence in dialogueManager.dialogueCharA.dialogueStructure[currentIndex].sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log("StartDialogue Count : " + sentences.Count);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        string sentence = sentences.Dequeue();
        Continue.SetActive(false);
        endDialogueButton.SetActive(false);
        Debug.Log("DisplayNextSentence Count : " + sentences.Count);
        //Ajouter des "Watchers"
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
            EndDialogue();
        }  

        if(sentences.Count == 0)
        {
            if(ChoicesStructures.Count == 3)
                {
                    choiceButton1.SetActive(true);
                    choiceButton2.SetActive(true);
                    choiceButton3.SetActive(true);
                    choice1.text = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[0].shortSentence;
                    choice2.text = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[1].shortSentence;
                    choice3.text = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[2].shortSentence;
                }
            if(ChoicesStructures.Count == 2)
                {
                    choiceButton1.SetActive(true);
                    choiceButton2.SetActive(true);
                    choice1.text = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[0].shortSentence;
                    choice2.text = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[1].shortSentence;
                }
            if(ChoicesStructures.Count == 1)
                {
                    choiceButton1.SetActive(true);
                    choice1.text = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[0].shortSentence;
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
        Debug.Log("Fin StartDialogue - Choix 1 - Index N° " + currentIndex);
        currentIndex = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[0].choices;
        StartDialogue();
    }

    public void SelectChoice2()
    {
        currentIndex = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[1].choices;
        StartDialogue();
    }

    public void SelectChoice3()
    {
        currentIndex = dialogueManager.dialogueCharA.dialogueStructure[currentIndex].choicesStructure[2].choices;
        StartDialogue();
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        charImage.SetActive(false);
        PlayerCC._speed = 5;
    }

}
