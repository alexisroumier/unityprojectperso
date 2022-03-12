using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public List<Item> content = new List<Item>();
    public static Inventory instance;
    public int contentCurrentIndex = 0;
    public Image itemImageUI;
    public Sprite emptyItemImage;
    public Text itemNameUI;
    public Text itemDescriptionUI;
    public GameObject inventory;
    bool isHidden = false;

    public Button GetNextItemButton;
    public Button GetPreviousItemButton;


    private void Start()
    {
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
            GetNextItemButton.enabled = true;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
        {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
            GetPreviousItemButton.enabled = true;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if(content.Count > 0)
        {
        itemImageUI.sprite = content[contentCurrentIndex].image;
        itemNameUI.text = content[contentCurrentIndex].name;
        itemDescriptionUI.text = content[contentCurrentIndex].description;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
            itemDescriptionUI.text = "";
            GetNextItemButton = null;
            GetPreviousItemButton = null;
        }
    }


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance dans la scène");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            if(isHidden)
            {
                isHidden = false;
                inventory.SetActive(isHidden);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                inventory.SetActive(isHidden);
            }
        }
    }

}
