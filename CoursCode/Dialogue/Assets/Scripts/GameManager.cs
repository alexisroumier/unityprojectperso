using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public List<GameObject> charManager;


void Awake()

{
        charManager.AddRange(GameObject.FindGameObjectsWithTag("Character"));

}


}
