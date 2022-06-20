using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SuspectsInventory : MonoBehaviour
{

    public List<Item> suspectList = new List<Item>();
    public List<InventorySlot> suspectInventorySlots = new List<InventorySlot>();
    public static SuspectsInventory instance;
    public Text itemNameUI;
    public Text itemDescriptionUI;
    public GameObject suspectsInventory;
    public GameObject suspectButton;
    Color buttonTemp;
    Color imageTemp;
    Color textTemp;
    public GameObject imageTempGameObject;
    public GameObject textTempGameObject;
    bool isHidden = false;
    public GameObject itemSlotObject;
    public GameObject Content;
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
        buttonTemp = suspectButton.GetComponent<Image>().color;       
        imageTemp = imageTempGameObject.GetComponent<Image>().color;
        textTemp = textTempGameObject.GetComponent<Text>().color;
        UpdateInventoryUI();
    }

    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.F))
        {
            imageTemp = new Color(0,0,0,0.4f);
            textTemp = new Color(0.9f,0.9f,0.9f,a: 0.4f);
            buttonTemp = new Color(0.3f,0.4f,1,0.2f);
            CluesInventory.instance.cluesButton.GetComponent<Image>().color = buttonTemp;            
            CluesInventory.instance.imageTempGameObject.GetComponent<Image>().color = imageTemp;
            CluesInventory.instance.textTempGameObject.GetComponent<Text>().color = textTemp;  
            newSuspectText.enabled = false;
            if(isHidden == true)
                {OpenSuspectsInventory();}
            else
                {CloseSuspectsInventory();}
        }
    }

    
    public bool Add(Item suspect)
    {
        suspectList.Add(suspect);
        AddItemSlots();
        for(int i = 0; i < suspectList.Count; i++)
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
        
    }

    private void AddItemSlots()
    {
        GameObject GO = Instantiate(itemSlotObject, Content.transform);
        InventorySlot newSuspectSlot = GO.GetComponent<InventorySlot>();
        suspectInventorySlots.Add(newSuspectSlot);
    }


    public void OpenSuspectsInventory()
    {
        isHidden = false;
        suspectsInventory.SetActive(!isHidden);
        CluesInventory.instance.cluesInventory.SetActive(value: false);
        if(Content.GetComponentInChildren<Button>() != null) Content.GetComponentInChildren<Button>().Select();
        Time.timeScale = 0f;
        imageTemp = new Color(1,1,1,1);
        textTemp = new Color(0.9f,0.9f,0.9f,a: 0.83f);
        buttonTemp = new Color(0.3f,0.9f,0.4f,1);
        imageTempGameObject.GetComponent<Image>().color = imageTemp;
        textTempGameObject.GetComponent<Text>().color = textTemp;
        suspectButton.GetComponent<Image>().color = buttonTemp;
    }

    public void CloseSuspectsInventory()
    {
        isHidden = true;
        suspectsInventory.SetActive(!isHidden);
        CluesInventory.instance.cluesInventory.SetActive(value: false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
        imageTemp = new Color(0,0,0,0.4f);
        textTemp = new Color(0.9f,0.9f,0.9f,a: 0.4f);
        buttonTemp = new Color(0.3f,0.9f,0.4f,0.2f);
        imageTempGameObject.GetComponent<Image>().color = imageTemp;
        textTempGameObject.GetComponent<Text>().color = textTemp;
        suspectButton.GetComponent<Image>().color = buttonTemp;
    }

}
