using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginWnd : BaseWindow
{
    public void Init()
    {
        Transform loginBtn = _wndTran.FindChild("BtnLogin");
        Transform loginText = _wndTran.FindChild("BtnLogin/Text");
        UIEventListener.Get(loginBtn.gameObject).onPointerClick = OnLogin;
        loginText.GetComponent<Text>().text = Localization.Get("StartGame");
    }

    private void OnLogin(PointerEventData ped)
    {
        WindowManager.Close<LoginWnd>();
        Application.LoadLevelAsync("Loading");
        LoadingLevel.levelName = "City";
    }
}
