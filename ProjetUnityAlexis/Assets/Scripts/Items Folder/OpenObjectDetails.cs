using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObjectDetails : MonoBehaviour
{

    public GameObject objectDetails;
    bool isHidden = false;

    public void OpenPanel()
    {
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
