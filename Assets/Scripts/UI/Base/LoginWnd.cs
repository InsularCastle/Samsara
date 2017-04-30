using UnityEngine;
using System.Collections;

public class LoginWnd : BaseWindow
{
    public void Init()
    {
        _wndTran.GetComponent<Login>().Init();
    }
}
