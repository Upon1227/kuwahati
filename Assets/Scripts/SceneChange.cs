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
        FadeManager.Instance.LoadScene ("SampleScene", 1.0f);
    }
    public void GameOver()
    {
        FadeManager.Instance.LoadScene ("GameOver", 1.0f);
    }
    public void Clear()
    {
        FadeManager.Instance.LoadScene ("Clear", 1.0f);
    }
    public void Retry()
    {
        FadeManager.Instance.LoadScene ("Title", 1.0f);
    }
    
}
