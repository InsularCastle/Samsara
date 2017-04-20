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
        _wndTran.gameObject.AddComponent<UIMaskLayer>();
    }

    public void Close()
    {
        GameObject.Destroy(_wndTran.gameObject);
    }
}

public class UIMaskLayer : MonoBehaviour
{
    void Start()
    {
        int width = Screen.width;
        int height = Screen.height;
        int designWidth = 1920;//开发时分辨率宽
        int designHeight = 1080;//开发时分辨率高
        float s1 = (float)designWidth / (float)designHeight;
        float s2 = (float)width / (float)height;
        if (s1 < s2)
        {
            designWidth = (int)Mathf.FloorToInt(designHeight * s2);
        }
        else if (s1 > s2)
        {
            designHeight = (int)Mathf.FloorToInt(designWidth / s2);
        }
        float contentScale = (float)designWidth / (float)width;
        RectTransform rectTransform = this.transform as RectTransform;
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(designWidth, designHeight);
        }
    }
}