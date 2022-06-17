using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> charManager;
    public GameObject CurrentScene;
    // Inventaire
    // Evenement

    void Awake()
    {
        // Recuperation des Personnages en vue d'exploiter et de modifier leurs dialogues.
        charManager.AddRange(GameObject.FindGameObjectsWithTag("Character"));
        CurrentScene = GameObject.FindGameObjectWithTag("sceneevents");
    }

    void Update()
    {
        UpdateEvent();
    }

    // Activer OnPropertyChanged from Current Scene Event
    private void UpdateEvent()
    {
        //CurrentScene.CurrentSceneUpdateEvent();
    }

    // Via trigger collider selectione GameManager puis ce code.
    private void CheckPoint()
    {
        //Sauvegarder dans un dossier.
        // Au besoin copier list inventaire dans la liste du Game Manager avant de Sauvegarder.
        // enregistrer tout les donnes de CE script (Inventaire + scene courrante + etat du jeu);
        // Sauvegarder position du personnage
    }

    //Sur le code qui fait le gestion de scene (ex : SceneManager), faire appel a ce code AVANT le changement pour bien sauvegarder les donnees
    //puis les chargers de l autre cote.
    private void OnScenechanged()
    {
        //Sauvegarder dans un dossier.
        // Au besoin copier list inventaire dans la liste du Game Manager avant de Sauvegarder.
        // enregistrer tout les donnes de CE script (Inventaire + scene courrante + etat du jeu);
    }

    // Via button Exit faire un appel a ce code.
    private void OnGameExit()
    {
        //Sauvegarder dans un dossier.
        // Au besoin copier list inventaire dans la liste du Game Manager avant de Sauvegarder.
        // enregistrer tout les donnes de CE script (Inventaire + scene courrante + etat du jeu);
    }
}