using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HexOutput : MonoBehaviour
{
    SaveData data;
    public TMP_InputField inputfield;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("DataManager");
        data = obj.GetComponent<DataManager>().data;
        Encode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Encode(){
        inputfield.text = "";
        for (int i = 0 ; i < data.len ; i++)
        {
            inputfield.text += '"';
            int len = data.Flames[i].Length;
            for (int j = 0 ; j < 16-len ; j++) inputfield.text += '0';
            inputfield.text += data.Flames[i] + '"' +",\n";
        }
    }
}
