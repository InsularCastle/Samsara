using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Transform loginBtn;

    void Start()
    {
        Init();
        GameSoundManager.Instance.PlayCustomBGMConnnection("Title");
    }

    public void Init()
    {
        UIEventListener.Get(loginBtn.gameObject).onPointerClick = OnLogin;
    }

    private void OnLogin(PointerEventData ped)
    {
        WindowManager.Close(UIMenu.LoginWnd);
        GameController.levelName = "City";
        Application.LoadLevelAsync("Loading");
    }
}
