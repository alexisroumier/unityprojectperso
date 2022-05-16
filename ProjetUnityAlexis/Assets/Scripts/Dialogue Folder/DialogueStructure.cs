using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueStructure
{
    public int id;
    public string nameNPC;
    public GameObject imageNPC;
    public Image imageBackground;
    public AudioClip soundToPlay;
    public List<string> sentences;
    public List<ChoicesStructure> choicesStructure = new List<ChoicesStructure>();

    private void Start() {
    imageNPC.SetActive(false);
}
}

[System.Serializable]
public struct ChoicesStructure
{
    public int choices;
    public string shortSentence;
}



/*

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public struct DialogueStructure
{
    int id;
    string nameNPC;
    Image imageNPC;
    Image imageBackground;
    AudioClip soundToPlay;
    List<string> sentences;
    List<int> choices;

}

*/