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

    private int slotNumber = 0;

    private void Awake()
    {
        instance = this;   
    }

    public void UpdateItemSlot()
    {
        Debug.Log("CluesInventory.instance.itemList[transform.GetSiblingIndex()]");
        Debug.Log("cest lui aui nous interesse" + CluesInventory.instance.inventorySlots.IndexOf(this));
        Debug.Log("CluesInventory.instance.itemList" + CluesInventory.instance.itemList);
        if(CluesInventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            item = CluesInventory.instance.itemList[transform.GetSiblingIndex()];
            icon.GetComponent<Image>().sprite = item.image;
            gameObject.name = item.Name + "slot numéro 1";
            foreach (var item in CluesInventory.instance.itemList)
            if(CluesInventory.instance.itemList.Length == 0)
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
        if(item.IsSelected == false)
        {
            item.IsSelected = true;
            Debug.Log(item.name + " est selectionné : " + item.IsSelected);
        }
        else
        {
            item.IsSelected = false;
            Debug.Log(item.name + " est selectionné : " + item.IsSelected);
        }
    }


}