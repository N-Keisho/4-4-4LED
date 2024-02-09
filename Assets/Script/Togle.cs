using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Togle : MonoBehaviour
{
    public int ownNumber = 0;
    LEDsManager ledsmanager;
    GameObject hexoutput;

    public Toggle toggle;
    public Text text;
    Image image;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("LEDsManager");
        ledsmanager = obj.GetComponent<LEDsManager>();
        text.text = name;
        ownNumber = int.Parse(name);
        image = transform.Find("Background").gameObject.GetComponent<Image>();

        hexoutput = GameObject.Find("HexOutput");
    }

    // Update is called once per frame
    void Update()
    {
        if (ledsmanager.leds[ownNumber-1]==1){
            toggle.isOn = true;
            image.color = Color.white;
        }
        else {
            toggle.isOn = false;
            image.color = Color.gray;
        }
    }

    public void OnToggleChanged(){
        if (toggle.isOn){
            ledsmanager.leds[ownNumber-1] = 1;
            image.color = Color.white;
        }
        else {
            ledsmanager.leds[ownNumber-1] = 0;
            image.color = Color.gray;
        }
        hexoutput.GetComponent<HexOutput>().Encode();
    }
}
