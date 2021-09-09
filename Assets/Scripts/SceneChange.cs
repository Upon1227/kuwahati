using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    
    // public static SceneChange instance;

    /*void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/


    public void OnClickStartButton()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Uho);
        FadeManager.Instance.LoadScene ("SampleScene", 1.0f);
        StartCoroutine(ChangeBGM("SampleScene"));
    }
    public void GameOver()
    {
        FadeManager.Instance.LoadScene ("GameOver", 1.0f);
        StartCoroutine(ChangeBGM("GameOver"));
    }
    public void Clear()
    {
        FadeManager.Instance.LoadScene ("Clear", 1.0f);
        StartCoroutine(ChangeBGM("Clear"));

    }
    public void Retry()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Uho);
        FadeManager.Instance.LoadScene ("Title", 1.0f);
        StartCoroutine(ChangeBGM("Title"));
    }



    IEnumerator ChangeBGM(string sceneName)
    {
        SoundManager.instance.StopBGM();
        yield return new WaitForSeconds(0.7f);
        if (sceneName== "SampleScene")
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM.Field);
        }
        else if(sceneName == "GameOver")
        {
            SoundManager.instance.PlaySE(SoundManager.SE.GameOver);
        }
        else if (sceneName == "Clear")
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM.End);
        }
        else if (sceneName == "Title")
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM.OPTheme);
        }
    }
    
}
