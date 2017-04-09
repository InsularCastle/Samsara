using System.Collections.Generic;
using UnityEngine;

public class BaseWindow
{
    protected Transform _wndTran;
    public void InitWnd(string wndName, Transform canvas)
    {
        string path = "UI/" + wndName;

        Object obj = Resources.Load(path);
        _wndTran = (GameObject.Instantiate(obj) as GameObject).transform;
        _wndTran.name = wndName;
        _wndTran.parent = canvas;
        _wndTran.localPosition = Vector3.zero;
        _wndTran.localScale = Vector3.one;
    }

    public void Close()
    {
        GameObject.Destroy(_wndTran.gameObject);
    }
}