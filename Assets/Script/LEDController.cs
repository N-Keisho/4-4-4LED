using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LEDController : MonoBehaviour, IPointerClickHandler
{
    public int ownNumber = 0;
    public Material onColor;
    public Material offColor;
    LEDsManager ledsmanager;
   

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("LEDsManager");
        ledsmanager = obj.GetComponent<LEDsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ledsmanager.leds[ownNumber-1]==1){
            GetComponent<Renderer>().material.color = onColor.color;
        }
        else {
            GetComponent<Renderer>().material.color = offColor.color;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ledsmanager.leds[ownNumber-1]==1){
            ledsmanager.leds[ownNumber-1] = 0;
        }
        else {
            ledsmanager.leds[ownNumber-1] = 1;
        }
        
    }
}
