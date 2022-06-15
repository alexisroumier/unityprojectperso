using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectsInventory : MonoBehaviour
{

    public Item[] suspectList = new Item[10];
    public List<InventorySlot> suspectInventorySlots = new List<InventorySlot>();
    public static SuspectsInventory instance;
    public int itemCurrentIndex = 0;
    public Image itemImageUI;
    public Sprite emptyItemImage;
    public Text itemNameUI;
    public Text itemDescriptionUI;
    public GameObject suspectsInventory;
    bool isHidden = false;
    public GameObject itemSlotObject;
    public Transform itemSlotObjectTransform;
    public Text newSuspectText;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance dans la scène");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.F))
        {
            newSuspectText.enabled = false;
            if(isHidden)
            {
                isHidden = false;
                suspectsInventory.SetActive(isHidden);
                CluesInventory.instance.cluesInventory.SetActive(value: false);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                suspectsInventory.SetActive(isHidden);
                CluesInventory.instance.cluesInventory.SetActive(value: false);
            }
        }
    }

    
    public bool Add(Item suspect)
    {
        AddItemSlots();
        for(int i = 0; i < suspectList.Length; i++)
        {
            if(suspectList[i] == null)
            {
                suspectList[i] = suspect;
                return true;
            }
        }
        return false;
    }
    

    public void UpdateInventoryUI()
    {
        for(int i = 0; i < suspectInventorySlots.Count; i++)
        {
            suspectInventorySlots[i].UpdateSuspectSlot();
        }
        
        if(suspectList[itemCurrentIndex] != null)
        {
            itemImageUI.sprite = suspectList[itemCurrentIndex].image;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
            itemDescriptionUI.text = "";
        }
    }

    private void AddItemSlots()
    {
        GameObject GO = Instantiate(itemSlotObject, itemSlotObjectTransform);
        InventorySlot newSuspectSlot = GO.GetComponent<InventorySlot>();
        suspectInventorySlots.Add(newSuspectSlot);
    }


    public void OpenCloseSuspectsInventory()
    {
        newSuspectText.enabled = false;
        if(isHidden)
            {
                isHidden = false;
                suspectsInventory.SetActive(isHidden);
                CluesInventory.instance.cluesInventory.SetActive(value: false);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                suspectsInventory.SetActive(isHidden);
                CluesInventory.instance.cluesInventory.SetActive(value: false);
            }
    }

}
