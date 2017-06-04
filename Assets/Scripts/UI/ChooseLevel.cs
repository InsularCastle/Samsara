﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public Transform optionBtnParent;
    public Transform optionBtn;
    public Transform SettingPanel;

    //Setting
    public Text volume;
    public Slider soundSlider;
    public Text soundText;
    public Slider voiceSlider;
    public Text voiceText;
    public Button closeSetting;
    public Dropdown languagesDropdown;
    public Button confirmSetting;
    public Text confirmSettingText;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        foreach (var option in GameController.config.options)
        {
            Transform optionTrans = GameObject.Instantiate<GameObject>(optionBtn.gameObject).transform;
            optionTrans.parent = optionBtnParent;
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

        //Setting
        volume.text = Localization.Get("Volume");
        soundText.text = Localization.Get("Sound");
        voiceText.text = Localization.Get("Voice");
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
        voiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume", 1f);
        UIEventListener.Get(closeSetting.gameObject).onPointerClick = OnCloseSettingClick;
        UpdateLanguageDropdown();
        UIEventListener.Get(confirmSetting.gameObject).onPointerClick = OnConfirmSettingClick;
        confirmSettingText.text = Localization.Get("Confirm");
    }

    private void OnNewGameClick(PointerEventData ped)
    {

    }

    private void OnLoadingClick(PointerEventData ped)
    {

    }

    private void OnSettingClick(PointerEventData ped)
    {
        SettingPanel.gameObject.SetActive(true);
    }

    private void OnExitClick(PointerEventData ped)
    {
        Application.Quit();
    }

    private void OnCloseSettingClick(PointerEventData ped)
    {
        SettingPanel.gameObject.SetActive(false);
    }

    private void UpdateLanguageDropdown()
    {
        languagesDropdown.options.Clear();
        foreach (var language in GameController.config.languages)
        {
            var tempData = new Dropdown.OptionData();
            tempData.text = Localization.Get(language);
            languagesDropdown.options.Add(tempData);
        }
        var curLanguage = PlayerPrefs.GetString("Language", "English");
        languagesDropdown.value = languagesDropdown.options.FindIndex(option => option.text == curLanguage);
    }

    private void OnConfirmSettingClick(PointerEventData ped)
    {
        PlayerPrefs.SetString("Language", GameController.config.languages[languagesDropdown.value]);
        Localization.language = PlayerPrefs.GetString("Language", "English");
        SettingPanel.gameObject.SetActive(false);
        WindowManager.Close(UIMenu.ChooseLevelWnd);
        WindowManager.Open(UIMenu.ChooseLevelWnd);
    }

    void Update()
    {
        if (soundSlider.value != PlayerPrefs.GetFloat("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", soundSlider.value);
            SoundManager.instance.SetSFXVolume(soundSlider.value);
        }

        if (voiceSlider.value != PlayerPrefs.GetFloat("VoiceVolume"))
        {
            PlayerPrefs.SetFloat("VoiceVolume", voiceSlider.value);
            SoundManager.instance.SetBgVolume(voiceSlider.value);
        }
    }
}
