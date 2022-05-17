using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    //public Dialogue dialogue;

    private bool isInRange;
    public Text interactUI;
    Camera cam;
    public Transform objectToFollow;
    public ReadFromCharacter ReadFromCharacter;
    public PlayerCC PlayerCC;
    public DialogueManager dialogueManager;


    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<ReadFromCharacter>().dialogueManager = dialogueManager;
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<ReadFromCharacter>().dialogueTrigger = this;
            Debug.Log("Press E : " + ReadFromCharacter.ChoicesStructures.Count);
            //dialogueManager.dialogueCharA.dialogueStructure[ReadFromCharacter.currentIndex].choicesStructure = ReadFromCharacter.ChoicesStructures;
            TriggerDialogue();
            interactUI.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
                if (interactUI) interactUI.enabled = true;
                if(!objectToFollow) return;
                interactUI.rectTransform.position = RectTransformUtility.WorldToScreenPoint(cam, objectToFollow.position) + new Vector2(0f, 110f);
                isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
        }
    }

    void TriggerDialogue()
    {
        ReadFromCharacter.isTalking = true;
        ReadFromCharacter.instance.StartDialogue();
        interactUI.enabled = false;
    }

}
