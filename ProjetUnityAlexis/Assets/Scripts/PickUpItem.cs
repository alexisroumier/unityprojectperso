using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickUpItem : MonoBehaviour
{

    public Text interactUI;
    private bool isInRange;
    public Text pickUp;
    public Item item;
    public AudioClip soundToPlay;

    public Dialogue dialogue;
    public DialogueManager DialogueManager;
    Camera cam;
    public Transform objectToFollow;
    private float wait;
    [SerializeField] private GameObject myObject;
    [SerializeField] private PickUpItem myScript;

void Start()
{
    pickUp.enabled = false;
    cam = Camera.main;
}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
            if(DialogueManager.sentences.Count > 0)
            {
                TriggerDialogue();
                DisablePickUp();
            }
        }
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        interactUI.enabled = false;
        StartCoroutine(WaitFewSeconds());
    }

    IEnumerator WaitFewSeconds() 
    {
        pickUp.enabled = true;
        yield return new WaitForSeconds (1.5f);
        pickUp.enabled = false;
        gameObject.SetActive(false);
    }

    void DisablePickUp()
    {
        myScript.enabled = false;
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
        interactUI.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {    
            if (!gameObject.activeSelf) return;
            else interactUI.enabled = true;
            if (!objectToFollow) return;
            interactUI.rectTransform.position = RectTransformUtility.WorldToScreenPoint(cam, objectToFollow.position) + new Vector2(0f, 40f);
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {    
            interactUI.enabled = false;
            isInRange = false;
        }
    }

}
