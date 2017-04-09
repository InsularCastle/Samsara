using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}

public class WindowManager
{
    private static Dictionary<string, BaseWindow> _windows = new Dictionary<string, BaseWindow>();

    private static Transform _canvas;

    public WindowManager()
    {
        Object obj = Resources.Load("UI/UI");
        Transform uiTran = (GameObject.Instantiate(obj) as GameObject).transform;
        uiTran.gameObject.AddComponent<DontDestroyOnLoad>();

        _canvas = uiTran.FindChild("Canvas");
    }

    /// <summary>
    /// 打开界面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Open<T>() where T : BaseWindow, new()
    {
        string wndName = typeof(T).Name;
        if (_windows.ContainsKey(wndName))
        {
            return _windows[wndName] as T;
        }
        else
        {
            T wnd = new T();
            wnd.InitWnd(wndName, _canvas);
            _windows.Add(wndName, wnd);

            return wnd;
        }
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static void Close<T>() where T : BaseWindow
    {
        string wndName = typeof(T).Name;
        if (_windows.ContainsKey(wndName))
        {
            T wnd = _windows[wndName] as T;
            wnd.Close();
            _windows.Remove(wndName);
        }
    }

    /// <summary>
    /// 获取界面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetWnd<T>() where T : BaseWindow
    {
        string wndName = typeof(T).Name;
        if (_windows.ContainsKey(wndName))
        {
            return _windows[wndName] as T;
        }
        else
        {
            return null;
        }
    }
}

