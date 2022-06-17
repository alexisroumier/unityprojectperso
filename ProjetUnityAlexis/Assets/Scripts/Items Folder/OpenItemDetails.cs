using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenItemDetails : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject objectDetails;
  
    bool isHidden = false;

    public void OnPointerEnter(PointerEventData data)
     {
        objectDetails = CluesInventory.instance.objectsToActivate[0];
            if(CluesInventory.instance.itemList[transform.GetSiblingIndex()] != null)
            {
            CluesInventory.instance.itemNameUI.text = CluesInventory.instance.itemList[transform.GetSiblingIndex()].Name;
            CluesInventory.instance.itemDescriptionUI.text = CluesInventory.instance.itemList[transform.GetSiblingIndex()].description;
            }
            isHidden = true;
            objectDetails.SetActive(isHidden);
    }   

        public void OnPointerExit(PointerEventData data)
     {
            isHidden = false;
            objectDetails.SetActive(isHidden);
            if(Input.GetMouseButtonUp(0) && InventorySlot.instance.item.IsSelected)
            {
            InventorySlot.instance.item.IsSelected = false;
            Debug.Log("On clique ailleurs. " + InventorySlot.instance.item.name + " est déselectionné : " + InventorySlot.instance.item.IsSelected);
            }
    } 

}
