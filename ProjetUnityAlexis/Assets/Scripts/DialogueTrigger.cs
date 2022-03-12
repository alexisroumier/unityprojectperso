using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private bool isInRange;
    public Text interactUI;
    Camera cam;
    public Transform objectToFollow;
    public DialogueManager DialogueManager;
    public PlayerCC PlayerCC;


    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
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
        DialogueManager.instance.StartDialogue(dialogue);
        interactUI.enabled = false;
    }

}
