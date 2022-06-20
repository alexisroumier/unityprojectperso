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

    private void Awake()
    {
        instance = this;   
    }

    public void UpdateItemSlot()
    {
        int index = CluesInventory.instance.inventorySlots.IndexOf(this);
        if(CluesInventory.instance.itemList[index] != null)
        {
            item = CluesInventory.instance.itemList[index];
            icon.GetComponent<Image>().sprite = item.image;
            gameObject.name = item.Name + "slot numéro 1";
            foreach (var item in CluesInventory.instance.itemList)
            if(CluesInventory.instance.itemList.Count == 0)
            {
            gameObject.name = item.Name + "slot numéro 1";
            }
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }

    public void UpdateSuspectSlot()
    {
        int index = SuspectsInventory.instance.suspectInventorySlots.IndexOf(this);
        if(SuspectsInventory.instance.suspectList[index] != null)
        {
            item = SuspectsInventory.instance.suspectList[index];
            icon.GetComponent<Image>().sprite = item.image;
            gameObject.name = item.Name + "slot numéro 1";
            foreach (var item in SuspectsInventory.instance.suspectList)
            if(SuspectsInventory.instance.suspectList.Count == 0)
            {
            gameObject.name = item.Name + "slot numéro 1";
            }
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }

}