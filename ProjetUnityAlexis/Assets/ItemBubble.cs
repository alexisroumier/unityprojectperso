using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemBubble : MonoBehaviour
{
    public static ItemBubble instance;
    public GameObject spriteBubble;
    public GameObject sizeBubble;
    public GameObject Bubble;
    public GameObject currentSelectedGO;
    public Item bubbleItem;

    public float x;
    public float y;
    public float z;

    private void Awake()
    {
        instance = this;
        Bubble = CluesInventory.instance.objectsToActivate[1];
        spriteBubble = CluesInventory.instance.objectsToActivate[2];
    }

    void Start()
    {
        transform.rotation = Quaternion.Euler(x,y,z);
        spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(x,y,z);
        
        if(spriteBubble)spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
    }

    void LateUpdate()
    {
        if(spriteBubble)spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
    }

    public void onInventoryItemClick()
    {
        Item newBubbleItem = EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>().item;
        spriteBubble = CluesInventory.instance.objectsToActivate[2];
        Bubble = CluesInventory.instance.objectsToActivate[1];
        spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
        if(!Bubble.activeSelf)
        {
            Bubble.SetActive(true);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = newBubbleItem.image;
            bubbleItem = newBubbleItem;
        }
        else
        {
            if(newBubbleItem.id == bubbleItem.id)
            {
                Bubble.SetActive(value: false);
                spriteBubble.GetComponent<SpriteRenderer>().sprite = null;
                bubbleItem = null;
            }
            else
            {
                spriteBubble.GetComponent<SpriteRenderer>().sprite = newBubbleItem.image;
                bubbleItem = newBubbleItem;
            }
        }
    }


}
