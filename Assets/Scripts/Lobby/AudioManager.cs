using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;
    public const string BGM_KEY = "BgmVolume";
    public const string SFX_KEY = "SfxVolume";

    void Awake(){
        if(instance == null){
            instance = this;

            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        LoadVolume();
    }

    void LoadVolume(){  //볼륨은 SetVol.cs에 저장됨
        float bmgVol = PlayerPrefs.GetFloat(BGM_KEY,1f);
        float sfxVol = PlayerPrefs.GetFloat(SFX_KEY,1f);

        mixer.SetFloat(SetVol.MIXER_BGM, Mathf.Log10(bmgVol) * 20);
        mixer.SetFloat(SetVol.MIXER_SFX, Mathf.Log10(sfxVol) * 20);
    }
}
