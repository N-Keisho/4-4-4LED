using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LEDsManager : MonoBehaviour
{
    SaveData data;
    public int[] leds;
    GameObject hexoutput;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("DataManager");
        data = obj.GetComponent<DataManager>().data;
        leds = toBin(data.Flames[data.FlameNumber-1]);

        hexoutput = GameObject.Find("HexOutput");
    }

    // Update is called once per frame
    void Update()
    {
        data.Flames[data.FlameNumber-1] = toHex(leds);
    }


    // 2進数に変換
    public string toHex(int[] bin){
        char[] ch = new char[] {'0','0','0','0','0','0','0','0','0','0',
                                '0','0','0','0','0','0','0','0','0','0',
                                '0','0','0','0','0','0','0','0','0','0',
                                '0','0','0','0','0','0','0','0','0','0',
                                '0','0','0','0','0','0','0','0','0','0',
                                '0','0','0','0','0','0','0','0','0','0',
                                '0','0','0','0'};

        for (int i = 0 ; i < 64 ; i++)  if (leds[i]==1) ch[i] = '1';
        var in64 = Convert.ToInt64(new String(ch), 2);
        string hex = Convert.ToString(in64, 16);
        return hex;
    }

    // 16進数に変換
    public int[] toBin(string hex){
        int[] tmp = {0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0 };

        var in64 = Convert.ToInt64(hex, 16);
        string st = Convert.ToString(in64, 2);
        int len = st.Length;
        char[] ch = st.ToCharArray();
        for (int i = len-1; i >= 0 ; i--){
            if (ch[i] == '1'){
                tmp[63-(len-1-i)] = 1;
            }
        }
        return tmp;
    }

    // 全点灯
    public void AllOn(){
        int[] tmp = {1,1,1,1,1,1,1,1,1,1,
                    1,1,1,1,1,1,1,1,1,1,
                    1,1,1,1,1,1,1,1,1,1,
                    1,1,1,1,1,1,1,1,1,1,
                    1,1,1,1,1,1,1,1,1,1,
                    1,1,1,1,1,1,1,1,1,1,
                    1,1,1,1};
        leds = tmp;
        hexoutput.GetComponent<HexOutput>().Encode();
    }

    // 全消灯
    public void AllOff(){
        int[] tmp = {0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0 };
        leds = tmp;
        hexoutput.GetComponent<HexOutput>().Encode();
    }

    //各フロアの全点消灯
    public void F1on(){
        for (int i = 0 ; i < 16 ; i++) leds[i] = 1;
        hexoutput.GetComponent<HexOutput>().Encode();
    }
    public void F1off(){
        for (int i = 0 ; i < 16 ; i++) leds[i] = 0;
        hexoutput.GetComponent<HexOutput>().Encode();
    }

    public void F2on(){
        for (int i = 16 ; i < 32 ; i++) leds[i] = 1;
        hexoutput.GetComponent<HexOutput>().Encode();
    }
    public void F2off(){
        for (int i = 16 ; i < 32 ; i++) leds[i] = 0;
        hexoutput.GetComponent<HexOutput>().Encode();
    }

    public void F3on(){
        for (int i = 32 ; i < 48 ; i++) leds[i] = 1;
        hexoutput.GetComponent<HexOutput>().Encode();
    }
    public void F3off(){
        for (int i = 32 ; i < 48 ; i++) leds[i] = 0;
        hexoutput.GetComponent<HexOutput>().Encode();
    }

    public void F4on(){
        for (int i = 48 ; i < 64 ; i++) leds[i] = 1;
        hexoutput.GetComponent<HexOutput>().Encode();
    }
    public void F4off(){
        for (int i = 48 ; i < 64 ; i++) leds[i] = 0;
        hexoutput.GetComponent<HexOutput>().Encode();
    }
}
