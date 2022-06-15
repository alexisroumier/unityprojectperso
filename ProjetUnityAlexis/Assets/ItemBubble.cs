using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        if(CluesInventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            if(!Bubble.activeSelf)
            {
            Bubble.SetActive(true);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = CluesInventory.instance.itemList[transform.GetSiblingIndex()].image;
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
