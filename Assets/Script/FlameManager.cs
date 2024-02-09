using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlameManager : MonoBehaviour
{
    SaveData data;
    public TMP_Dropdown dropdown;
    GameObject ledsmanager;
    GameObject hexoutput;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("DataManager");
        data = obj.GetComponent<DataManager>().data;
        ledsmanager = GameObject.Find("LEDsManager");
        hexoutput = GameObject.Find("HexOutput");

        UpdateList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValueChanged()
    {
        //「Dropdown」というGameObjectのDropDownコンポーネントを操作するために取得
        TMP_Dropdown ddtmp = dropdown.GetComponent<TMP_Dropdown>();

        //DropDownコンポーネントのoptionsから選択されてているvalueをindexで指定し、
        //選択されている文字を樹徳
        string selectedvalue = ddtmp.options[ddtmp.value].text;
        selectedvalue = selectedvalue.Replace("flame", "");

        //ログに出力
        //Debug.Log(selectedvalue);
        data.FlameNumber = int.Parse(selectedvalue);
        ledsmanager.GetComponent<LEDsManager>().leds = ledsmanager.GetComponent<LEDsManager>().toBin(data.Flames[data.FlameNumber-1]);
    }

    public void AddFlame(){
        data.len++;
        ledsmanager.GetComponent<LEDsManager>().leds = ledsmanager.GetComponent<LEDsManager>().toBin(data.Flames[data.FlameNumber-1]);
        UpdateList();
        hexoutput.GetComponent<HexOutput>().Encode();
    }

    public void DeleteFlame(){
        if (data.len <= 1){
            Debug.Log("これ以上は削除できません！");
        }
        else{
            int deleted = data.FlameNumber;
            string[] flames = data.Flames;
            for (int i = deleted-1 ; i < data.len ; i++){
                flames[i] = flames[i+1];
            }
            flames[data.max-1] = "0";
            data.len--;
            data.Flames = flames;
            ledsmanager.GetComponent<LEDsManager>().leds = ledsmanager.GetComponent<LEDsManager>().toBin(data.Flames[data.FlameNumber-1]);
            UpdateList();
            hexoutput.GetComponent<HexOutput>().Encode();
        }
    }

    void UpdateList(){
        data.FlameNumber = 1;
        List<string> optionlist = new List<string>();
        for (int i = 1 ; i <= data.len ; i++){
            optionlist.Add("flame" + i);
        }
        TMP_Dropdown ddtmp = dropdown.GetComponent<TMP_Dropdown>();
        ddtmp.ClearOptions();
        ddtmp.AddOptions(optionlist);
    }
}
