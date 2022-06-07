using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenSuspectDetails : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject objectDetails;
    bool isHidden = false;

    public void OnPointerEnter(PointerEventData data)
     {
            SuspectsInventory.instance.itemNameUI.text = SuspectsInventory.instance.suspectList[transform.GetSiblingIndex()].name;
            SuspectsInventory.instance.itemDescriptionUI.text = SuspectsInventory.instance.suspectList[transform.GetSiblingIndex()].description;
            isHidden = true;
            objectDetails.SetActive(isHidden);
    }   

        public void OnPointerExit(PointerEventData data)
     {
            isHidden = false;
            objectDetails.SetActive(isHidden);
    } 
}
