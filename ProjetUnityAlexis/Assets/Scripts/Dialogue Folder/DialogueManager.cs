using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    public DialogueClass charDialogue;
    public bool isTalking = false;
    public int idDialogueStart;
    public int idCurrentDialogue;

}


/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Image imageCharImage;
    public Text dialogueText;
    public Animator animator;
    public Queue<string> sentences;
    public static DialogueManager instance;
    public  PlayerCC PlayerCC;

    private void Awake()
    {

        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance dans la scene");
            return;
        }

        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
            PlayerCC._speed = 0;
            animator.SetBool("isOpen", true);
            dialogue.imageChar.SetActive(true);
            nameText.text = dialogue.name;
            sentences.Clear();
            foreach (var sentence in dialogue.sentences)
            {
                        Debug.Log("Avant le Enqueue, il reste " + sentences.Count + " phrases.");
                sentences.Enqueue(sentence);
                        Debug.Log("Après le Enqueue, il reste " + sentences.Count + " phrases.");
            }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
                Debug.Log("Avant le dequeue, il reste " + sentences.Count + " phrases.");
        string sentence = sentences.Dequeue();
                Debug.Log("Après le dequeue, il reste " + sentences.Count + " phrases.");
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
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        PlayerCC._speed = 5;
    }

} 
*/