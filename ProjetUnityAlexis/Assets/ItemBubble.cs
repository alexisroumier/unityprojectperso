using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBubble : MonoBehaviour
{
    Camera cam;
    public Transform objectToFollow;

    public GameObject spriteBubble;
    public GameObject sizeBubble;
    public GameObject Bubble;

    public float x;
    public float y;
    public float z;

    void Start()
    {
        transform.rotation = Quaternion.Euler(x,y,z);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(x,y,z);
        spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
    }

    public void SpriteBubble()
    {
        spriteBubble.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
        if(CluesInventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            Bubble.SetActive(true);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = CluesInventory.instance.itemList[transform.GetSiblingIndex()].image;
            //spriteBubble.transform.localScale = sizeBubble.transform.localScale;
        }
        else
        {
            Bubble.SetActive(false);
            spriteBubble.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

}
