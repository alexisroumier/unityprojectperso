using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenItemDetails : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject objectDetails;
  
    bool isHidden = false;


    public void Update()
     {
        if(EventSystem.current.currentSelectedGameObject != null)
        {
            if(EventSystem.current.currentSelectedGameObject == gameObject)
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
        }
     }


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
    } 

}
