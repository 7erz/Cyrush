using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVol : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    public const string MIXER_BGM = "BgmVolume";
    public const string MIXER_SFX = "SfxVolume";
    void Awake() {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    void Start(){
        bgmSlider.value = PlayerPrefs.GetFloat(AudioManager.BGM_KEY,1f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY,1f);
    }

    void OnDisable() {
        PlayerPrefs.SetFloat(AudioManager.BGM_KEY,bgmSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY,sfxSlider.value);
    }

    void SetBGMVolume(float value)
    {
        mixer.SetFloat(MIXER_BGM,Mathf.Log10(value) * 20);
    }
    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX,Mathf.Log10(value) * 20);
    }
}
