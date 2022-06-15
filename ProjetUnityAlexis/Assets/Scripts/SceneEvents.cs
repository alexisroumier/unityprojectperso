using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneEvents : MonoBehaviour
{

    public UnityEvent EventPNJA;
    
    public bool itemOne;
    public bool itemTwo;
    public bool itemThree;
    public bool itemFour;

    void Start()
    {
        //initialisation des persos
        //get du charManager (GameManager) et initier les dialogues de chaque perso (quand on recharge la scène, on met à jour les persos)       
    }

    public void Update() {
        EventPNJA.Invoke();
    }

    // Activer OnPropertyChanged from Current Scene Event

    private void CurrentSceneUpdateEvent()
    {
        // Si itemone est recupere / activer dans le monde faire les actions
        if (itemOne)
        {
            //liste actions itemone.
            //Ouvrir porte.
            //Changer current Id perso.
        }

        // Si itemtwo est recupere / activer dans le monde faire les actions
        if (itemTwo)
        {
            //liste actions itemtwo.
        }

        // Si itemone && itemtwo est recupere / activer dans le monde faire les actions
        if (itemOne && itemTwo)
        {
            //liste actions itemone && itemtwo.
        }
    }

}
