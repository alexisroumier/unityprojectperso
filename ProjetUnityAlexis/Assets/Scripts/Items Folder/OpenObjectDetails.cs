using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenObjectDetails : MonoBehaviour
{

    public GameObject objectDetails;
  
    bool isHidden = false;

    public void OpenItemPanel()
    {
        /*inventory.itemNameUI.text = inventory.itemList[inventory.itemCurrentIndex].name;
        inventory.itemDescriptionUI.text = inventory.itemList[inventory.itemCurrentIndex].description;*/
            CluesInventory.instance.itemNameUI.text = CluesInventory.instance.itemList[transform.GetSiblingIndex()].name;
            CluesInventory.instance.itemDescriptionUI.text = CluesInventory.instance.itemList[transform.GetSiblingIndex()].description;
            
            if(isHidden)
            {
                isHidden = false;
                objectDetails.SetActive(isHidden);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                objectDetails.SetActive(isHidden);
                Time.timeScale = 0f;
            }
    }

    public void OpenSuspectPanel()
    {
        /*inventory.itemNameUI.text = inventory.itemList[inventory.itemCurrentIndex].name;
        inventory.itemDescriptionUI.text = inventory.itemList[inventory.itemCurrentIndex].description;*/
            SuspectsInventory.instance.itemNameUI.text = SuspectsInventory.instance.suspectList[transform.GetSiblingIndex()].name;
            SuspectsInventory.instance.itemDescriptionUI.text = SuspectsInventory.instance.suspectList[transform.GetSiblingIndex()].description;
            
            if(isHidden)
            {
                isHidden = false;
                objectDetails.SetActive(isHidden);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                objectDetails.SetActive(isHidden);
                Time.timeScale = 0f;
            }
    }

}
