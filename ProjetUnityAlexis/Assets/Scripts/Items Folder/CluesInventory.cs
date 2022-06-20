using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CluesInventory : MonoBehaviour
{

    public List<Item> itemList = new List<Item>();
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public List<GameObject> objectsToActivate = new List<GameObject>();

    public static CluesInventory instance;
    public Text pickUpText;
    public Text itemNameUI;
    public Text itemDescriptionUI;
    public GameObject cluesInventory;
    public GameObject cluesButton;
    Color buttonTemp;
    Color imageTemp;
    Color textTemp;
    public GameObject imageTempGameObject;
    public GameObject textTempGameObject;
    bool isHidden = false;
    public GameObject itemSlotObject;
    public GameObject Content;

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
        buttonTemp = cluesButton.GetComponent<Image>().color;       
        imageTemp = imageTempGameObject.GetComponent<Image>().color;
        textTemp = textTempGameObject.GetComponent<Text>().color;
        UpdateInventoryUI();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            buttonTemp = new Color(r: 0.3f,0.9f,0.4f,0.2f);
            SuspectsInventory.instance.suspectButton.GetComponent<Image>().color = buttonTemp;
            imageTemp = new Color(0,0,0,0.4f);
            textTemp = new Color(0.9f,0.9f,0.9f,a: 0.4f);
            SuspectsInventory.instance.imageTempGameObject.GetComponent<Image>().color = imageTemp;
            SuspectsInventory.instance.textTempGameObject.GetComponent<Text>().color = textTemp; 
            pickUpText.enabled = false;

            if(isHidden == true)
                {OpenCluesInventory();}
            else
                {CloseCluesInventory();}
        }
    }

    
    public bool Add(Item item)
    {
        itemList.Add(item);
        AddItemSlots();
        for(int i = 0; i < itemList.Count; i++)
        {
            if(itemList[i] == null)
            {
                itemList[i] = item;
                return true;
            }
        }
        return false;
    }
    

    public void UpdateInventoryUI()
    {
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateItemSlot();
        }
    }

    private void AddItemSlots()
    {
        GameObject GO = Instantiate(itemSlotObject, Content.transform);
        InventorySlot newSlot = GO.GetComponent<InventorySlot>();
        inventorySlots.Add(newSlot);
    }


   public void OpenCluesInventory()
    {
        isHidden = false;
        cluesInventory.SetActive(!isHidden);
        SuspectsInventory.instance.suspectsInventory.SetActive(value: false);  
        if(Content.GetComponentInChildren<Button>() != null) Content.GetComponentInChildren<Button>().Select();
        Time.timeScale = 0f;
        imageTemp = new Color(1,1,1,1);
        textTemp = new Color(0.9f,0.9f,0.9f,a: 0.83f);
        buttonTemp = new Color(0.3f,0.4f,1,1);
        imageTempGameObject.GetComponent<Image>().color = imageTemp;
        textTempGameObject.GetComponent<Text>().color = textTemp;
        cluesButton.GetComponent<Image>().color = buttonTemp;
    }

    public void CloseCluesInventory()
    {
        isHidden = true;
        cluesInventory.SetActive(!isHidden);
        SuspectsInventory.instance.suspectsInventory.SetActive(value: false);                
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
        imageTemp = new Color(0,0,0,0.4f);
        textTemp = new Color(0.9f,0.9f,0.9f,a: 0.4f);
        buttonTemp = new Color(0.3f,0.4f,1,0.2f);
        imageTempGameObject.GetComponent<Image>().color = imageTemp;
        textTempGameObject.GetComponent<Text>().color = textTemp;
        cluesButton.GetComponent<Image>().color = buttonTemp;
    }     

}
