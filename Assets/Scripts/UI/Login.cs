using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Transform loginBtn;
    public Transform loginText;

    public void Init()
    {
        
        UIEventListener.Get(loginBtn.gameObject).onPointerClick = OnLogin;
        loginText.GetComponent<Text>().text = Localization.Get("StartGame");
    }

    private void OnLogin(PointerEventData ped)
    {
        WindowManager.Close<LoginWnd>();
        GameController.levelName = "City";
        Application.LoadLevelAsync("Loading");
    }
}
