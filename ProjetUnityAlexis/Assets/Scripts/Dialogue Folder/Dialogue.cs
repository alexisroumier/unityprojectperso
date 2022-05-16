using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public GameObject imageChar;
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;

private void Start() {
    imageChar.SetActive(false);
}

}
