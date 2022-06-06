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
    public ReadFromCharacter DialogueManager;
    Camera cam;
    public Transform objectToFollow;
    private float wait; 
    public static PickUpItem instance;
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

            if(DialogueManager != null)
            {
                TriggerDialogue();
                DisablePickUp();
            }
        }
    }

    void TakeItem()
    {
        //pnjA.DialogueManager.charDialogue = pnjA.
        CluesInventory.instance.Add(item);
        CluesInventory.instance.UpdateInventoryUI();
        interactUI.enabled = false;
        NewItemText();
    }

    public void NewItemText()
    {
        pickUp.enabled = true;
        gameObject.SetActive(false);
    }

    void DisablePickUp()
    {
        myScript.enabled = false;
    }

    void TriggerDialogue()
    {
        ReadFromCharacter.instance.StartDialogue();
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
