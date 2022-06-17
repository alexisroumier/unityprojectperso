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

    public float x;
    public float y;
    public float z;

    private void Awake()
    {
        instance = this;   
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
        Bubble = CluesInventory.instance.objectsToActivate[1];
        if(InventorySlot.instance.item != null)
         {
            if(!Bubble.activeSelf)
            {
            Bubble.SetActive(true);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = InventorySlot.instance.item.image;
            }
            else
            {
            Bubble.SetActive(value: false);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        else
        {
            Bubble.SetActive(value: false);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

}
