using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string Name;
    public string description;
    public Sprite image;
    public bool IsSelected = false;

    public void Start()
    {
        IsSelected = false;
    }

}
