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
        spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
    }

    void LateUpdate()
    {
                spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
    }

    public void SpriteBubble()
    {
        spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
        bubbleItem = EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>().item;
        if(bubbleItem != null)
        {
            if(!Bubble.activeSelf)
            {
                bubbleItem.IsSelected = true;
                Debug.Log(bubbleItem.name + " = " + bubbleItem.IsSelected);
                Bubble.SetActive(true);
                spriteBubble.GetComponent<SpriteRenderer>().sprite = bubbleItem.image;
            }
            else
            {
                if(Bubble.activeSelf && bubbleItem.IsSelected == true)
                {
                    bubbleItem.IsSelected = false;
                    Debug.Log(bubbleItem.name + " = " + bubbleItem.IsSelected);
                    Bubble.SetActive(value: false);
                    spriteBubble.GetComponent<SpriteRenderer>().sprite = null;
                }

                if(Bubble.activeSelf && bubbleItem.IsSelected == false)
                {
                    spriteBubble.GetComponent<SpriteRenderer>().sprite = bubbleItem.image;
                    bubbleItem.IsSelected = true;
                    Debug.Log(bubbleItem.name + " = " + bubbleItem.IsSelected);
                }
            }
        }
        else
        {
            Bubble.SetActive(value: false);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    public void SelectItem()
    {     
        if(bubbleItem.IsSelected == false)
        {
            bubbleItem.IsSelected = true;
            Debug.Log(bubbleItem.name + " est selectionné : " + bubbleItem.IsSelected);
        }
        else
        {
            bubbleItem.IsSelected = false;
            Debug.Log(bubbleItem.name + " est selectionné : " + bubbleItem.IsSelected);
        }
    }

}
