using System;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelWnd : BaseWindow
{
    public void Init()
    {
        _wndTran.GetComponent<ChooseLevel>().Init();
    }
}