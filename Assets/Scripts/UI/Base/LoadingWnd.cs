using UnityEngine;
using System.Collections;

public class LoadingWnd : BaseWindow
{
    public void Init()
    {
        _wndTran.GetComponent<Loading>().Init();
    }
}