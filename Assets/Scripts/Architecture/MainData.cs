using System;
using UnityEngine;

public class MainData
{
    public String State { get; set; }
    
    public MainData()
    {
        Load();
    }
    
    public void Save()
    {
        PlayerPrefs.SetString("LoppyPoppyState",State);
    }

    private void  Load()
    {
        State = PlayerPrefs.GetString("LoppyPoppyState");
    }
}
