using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public Transform _OptionBtnParent;
    public Transform _OptionBtn;

    public void Init()
    {
        foreach (var option in GameController.config.options)
        {
            Transform optionTrans = GameObject.Instantiate<GameObject>(_OptionBtn.gameObject).transform;
            optionTrans.parent = _OptionBtnParent;
            optionTrans.localPosition = Vector3.zero;
            optionTrans.localScale = Vector3.one;
            optionTrans.gameObject.SetActive(true);
            optionTrans.name = option;
            Text text = optionTrans.FindChild("Text").GetComponent<Text>();
            text.text = Localization.Get(option);

            switch (option)
            {
                case "NewGame":
                    UIEventListener.Get(optionTrans.gameObject).onPointerClick = OnNewGameClick;
                    break;
                case "Loading":
                    UIEventListener.Get(optionTrans.gameObject).onPointerClick = OnLoadingClick;
                    break;
                case "Setting":
                    UIEventListener.Get(optionTrans.gameObject).onPointerClick = OnSettingClick;
                    break;
                case "Exit":
                    UIEventListener.Get(optionTrans.gameObject).onPointerClick = OnExitClick;
                    break;
            }
        }
    }

    private void OnNewGameClick(PointerEventData ped)
    {

    }

    private void OnLoadingClick(PointerEventData ped)
    {

    }

    private void OnSettingClick(PointerEventData ped)
    {

    }

    private void OnExitClick(PointerEventData ped)
    {
        Application.Quit();
    }
}
