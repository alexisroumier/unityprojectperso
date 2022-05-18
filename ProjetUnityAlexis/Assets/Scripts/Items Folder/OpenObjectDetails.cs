using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenObjectDetails : MonoBehaviour
{

    public GameObject objectDetails;
    public Inventory inventory;
    bool isHidden = false;

    public void OpenPanel()
    {
        inventory.itemNameUI.text = inventory.itemList[inventory.itemCurrentIndex].name;
        inventory.itemDescriptionUI.text = inventory.itemList[inventory.itemCurrentIndex].description;
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
