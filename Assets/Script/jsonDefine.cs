using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public string[] Flames = new string[]{"0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0",
                                        "0","0","0","0","0","0","0","0","0","0" };
    public int FlameNumber;
    public int len;
    public int max = 100;
};