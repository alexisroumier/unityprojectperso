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
            CluesInventory.instance.itemNameUI.text = CluesInventory.instance.itemList[transform.GetSiblingIndex()].name;
            CluesInventory.instance.itemDescriptionUI.text = CluesInventory.instance.itemList[transform.GetSiblingIndex()].description;
            isHidden = true;
            objectDetails.SetActive(isHidden);
    }   

        public void OnPointerExit(PointerEventData data)
     {
            isHidden = false;
            objectDetails.SetActive(isHidden);
    } 

}
