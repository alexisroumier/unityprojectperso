using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InteractiveDecoration : MonoBehaviour
{

    public Text interactUIA;
    public Text interactUIB;
    public GameObject objectToSwitch;
    private bool isInRange;
    public bool isSwitchOn;
    public AudioClip soundToPlay;
    Camera cam;
    public Transform objectToFollow;
    private float wait; 
    public static InteractiveDecoration instance;

    private void Awake()
    {
        instance = this;   
    }

void Start()
{
    cam = Camera.main;
}

    void Update()
    {

        
        if(Input.GetKeyDown(KeyCode.E) && isInRange && isSwitchOn)
        {
            objectToSwitch.SetActive(false);
            interactUIA.enabled = false;
            interactUIB.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.E) && isInRange && !isSwitchOn)
        {
            objectToSwitch.SetActive(true);
            interactUIA.enabled = false;
            interactUIB.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {    
            if(objectToSwitch.activeSelf == false)
            {
                interactUIA.enabled = true;
                interactUIA.rectTransform.position = RectTransformUtility.WorldToScreenPoint(cam, objectToFollow.position) + new Vector2(0f, 40f);
                isSwitchOn = false;
            }
            if(objectToSwitch.activeSelf == true)
            {
                interactUIB.enabled = true;
                interactUIB.rectTransform.position = RectTransformUtility.WorldToScreenPoint(cam, objectToFollow.position) + new Vector2(0f, 40f);
                isSwitchOn = true;
            }
            if (!objectToFollow) return;
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {    
            interactUIA.enabled = false;
            interactUIB.enabled = false;
            isInRange = false;
        }
    }

}
