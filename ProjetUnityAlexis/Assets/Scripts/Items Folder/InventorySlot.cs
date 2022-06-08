using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public static InventorySlot instance;
    public GameObject icon;
    public Item item;

    public void UpdateItemSlot()
    {
        if(CluesInventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            item = CluesInventory.instance.itemList[transform.GetSiblingIndex()];
            //ItemBubble.instance.item = CluesInventory.instance.itemList[transform.GetSiblingIndex()];
            icon.GetComponent<Image>().sprite = item.image;
            gameObject.name = item.Name;
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }

    public void UpdateSuspectSlot()
    {
        if(SuspectsInventory.instance.suspectList[transform.GetSiblingIndex()] != null)
        {
            item = SuspectsInventory.instance.suspectList[transform.GetSiblingIndex()];
            icon.GetComponent<Image>().sprite = SuspectsInventory.instance.suspectList[transform.GetSiblingIndex()].image;
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }
    

    public void SelectItem()
    {   
            item.IsSelected = true;
            Debug.Log(item.name + " est selectionné : " + item.IsSelected);
    }


}