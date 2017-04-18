using System;
using System.Collections.Generic;
using UnityEngine;

public class CityLevel
{
    public CityLevel()
    {

    }

    public void Init()
    {
        ChooseLevelWnd wnd = WindowManager.Open<ChooseLevelWnd>();
        wnd.Init();
    }
}