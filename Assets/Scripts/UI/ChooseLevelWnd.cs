using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 选择关卡界面
/// </summary>
public class ChooseLevelWnd : BaseWindow
{
    public void Init()
    {
        Transform _OptionBtnParent = _wndTran.FindChild("Scroll View/Viewport/Content");
        Transform _OptionBtn = _wndTran.FindChild("Scroll View/Option");

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
        }
    }
}