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
        if(CluesInventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            icon.GetComponent<Image>().sprite = CluesInventory.instance.itemList[transform.GetSiblingIndex()].image;
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }

}
