using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public GameObject icon;
    public Item item;

    private void Start()
    {
        item = null;
    }

    public void UpdateItemSlot()
    {
        if(CluesInventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            item = CluesInventory.instance.itemList[transform.GetSiblingIndex()];
            Debug.Log(CluesInventory.instance.itemList[transform.GetSiblingIndex()].name);
            icon.GetComponent<Image>().sprite = CluesInventory.instance.itemList[transform.GetSiblingIndex()].image;
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
            item = CluesInventory.instance.itemList[transform.GetSiblingIndex()];
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