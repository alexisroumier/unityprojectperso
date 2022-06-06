using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewNPCFound : MonoBehaviour
{

    public Text newSuspect;
    public Item suspect;
    public AudioClip soundToPlay;


    void Update()
    {

        //if(ReadFromCharacter.EndDialogue)
        if(Array.IndexOf(SuspectsInventory.instance.itemList, suspect) == -1)
        {
        TakeSuspect();
        }
    }

    public void TakeSuspect()
    {
        SuspectsInventory.instance.Add(suspect);
        SuspectsInventory.instance.UpdateInventoryUI();
        NewSuspectText();
    }

    public void NewSuspectText()
    {
        newSuspect.enabled = true;
        gameObject.SetActive(false);
        if(CluesInventory.instance.cluesInventory.activeSelf)
        {
            newSuspect.enabled = false;
        }
    }

}
