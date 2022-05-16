using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAEvents : MonoBehaviour
{

public bool itemOne;
public bool itemTwo;
public bool itemThree;
public bool itemFour;


void Start()
{
    //initialisation des persos
    //get du charManager (GameManager) et initier les dialogues de chaque perso (quand on recharge la scène, on met à jour les persos)


}

void CharacterDialogue()
{
    if(itemOne)
    {
        if(itemTwo)
        {
            //action si le joueur a item1 + item 2. Exemple : modifier l'id dialogueStructure de charA
            return;
        }
        
        //action si le joueur a item1
        return;
    }
    if(itemTwo)
    {

    }
}

}
