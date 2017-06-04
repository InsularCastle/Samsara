using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private Dictionary<string, AudioClip> _soundDictionary;
    private AudioSource[] _audioSources;
    private AudioSource _audioSourceBg;
    private AudioSource _audioSourceSFX;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this);

        _soundDictionary = new Dictionary<string, AudioClip>();
        AudioClip[] audioArray = Resources.LoadAll<AudioClip>("Audios");
        foreach (var audio in audioArray)
        {
            _soundDictionary.Add(audio.name, audio);
        }

        _audioSources = GetComponents<AudioSource>();
        _audioSourceBg = _audioSources[0];
        _audioSourceSFX = _audioSources[1];

        _audioSourceBg.volume = PlayerPrefs.GetFloat("VoiceVolume", 1f);
        _audioSourceSFX.volume = PlayerPrefs.GetFloat("SoundVolume", 1f);
    }

    public void SetBgVolume(float volume)
    {
        _audioSourceBg.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        _audioSourceSFX.volume = volume;
    }

    public void PlayAudioBg(string audioName)
    {
        if (_soundDictionary.ContainsKey(audioName))
        {
            _audioSourceBg.clip = _soundDictionary[audioName];
            _audioSourceBg.Play();
        }
    }

    public void PlayAudioSFX(string audioName)
    {
        if (_soundDictionary.ContainsKey(audioName))
        {
            _audioSourceSFX.clip = _soundDictionary[audioName];
            _audioSourceSFX.Play();
        }
    }
}
