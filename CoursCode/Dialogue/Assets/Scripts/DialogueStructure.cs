using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueStructure
{
    //Eléments que je souhaite pouvoir afficher dans mon dialogue (pour chaque phrase) : 
        //Un id pour chaque phrase (à afficher selon le choix/l'action effectué(e))
        //Une image du personnage qui s'exprime (dans un dialogue, 2 personnages peuvent s'exprimer tour à tour)
        //Le nom du personnage qui s'exprime (ex : "Obelix"),
        //Une phrase (ex : "J'ai faim. T'aurais pas un p'tit truc pour moi ?" ou une image (exemple : smiley affamé)),
        //Un son qui se joue (ex : Gargouilli de ventre car le personnage a faim),
        //Une image d'arrière-plan modifiable selon le dialogue (exemple : bulle de dialogue ronde et jaune pour un personnage heureux puis une bulle de dialogue carrée et rouge si le personnage est énervé)
        //Des paramètres de texte (Gras, Italique, Police, Couleur),
        //Une zone de drop d'item pour déclencher un dialogue précis. EXEMPLE :
                // 1. Dialogue d'un personnage A qui dit qu'il a faim.
                // 2. Drag & Drop un objet de son inventaire (Gateau au Chocolat) sur le personnage A
                // 3. Lancement d'un dialogue avec le personnage A qui remercie le joueur de lui avoir donné à manger
        //Un input (touche ESPACE) pour passer à la phrase suivante ou clore le dialogue,
        //Un système de choix qui renvoient vers un nouveau dialogue (parfois)

    public int id;
    public string nameNPC;
    public Image imageNPC;
    public Image imageBackground;
    public AudioClip soundToPlay;
    public List<string> sentences;
    public List<ChoicesStructure> choicesStructure = new List<ChoicesStructure>();
}

[System.Serializable]
public struct ChoicesStructure
{
    public int choices;
    public string shortSentence;
}
