using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public GameObject icon;
    public void UpdateSlot()
    {
        if(Inventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            icon.GetComponent<Image>().sprite = Inventory.instance.itemList[transform.GetSiblingIndex()].image;
            Inventory.instance.itemNameUI.text = Inventory.instance.itemList[transform.GetSiblingIndex()].name;
            Inventory.instance.itemDescriptionUI.text = Inventory.instance.itemList[transform.GetSiblingIndex()].description;
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }

}
