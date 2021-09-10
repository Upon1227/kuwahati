using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public AudioSource seAudioSource;
    public AudioClip[] bgmClips;
    public AudioClip[] seClips;
    BGM currentBgm;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum BGM
    {
        OPTheme,//
        Field,
        End,
        
    }

    public enum SE
    {
        Uho,
        Uki,
        Damage,
        GameOver,
        KnockOut,
        Break,  //
        FeelGood,
        Booing,
        Walk,
        Bike,
        BikeRun,
        Dance1,
        Dance2,
        Dance3,


    }


    public void SetBGMVolume(float volume)
    {
        AudioParamsSO.Entity.BGMVolume = volume;
        bgmAudioSource.volume = AudioParamsSO.Entity.GetVolume(currentBgm);

    }
    public void SetSEVolume(float volume)
    {
        seAudioSource.volume = volume;
        AudioParamsSO.Entity.SEVolume = volume;
    }

    

    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
    public void StopSE()
    {
        seAudioSource.Stop();
    }


    public void PlayBGM(BGM bgm)
    {
        int index = (int)bgm;
        currentBgm = bgm;
        bgmAudioSource.volume = AudioParamsSO.Entity.GetVolume(currentBgm);
        bgmAudioSource.clip = bgmClips[index];
        bgmAudioSource.Play();
        Debug.Log(bgmAudioSource.volume);
    }

    public void PlaySE(SE se)
    {
        int index = (int)se;
        seAudioSource.volume = AudioParamsSO.Entity.GetVolume(se);
        seAudioSource.PlayOneShot(seClips[index]);
    }


    public bool IsPlaySE()
    {
        return seAudioSource.isPlaying;
    }


}
