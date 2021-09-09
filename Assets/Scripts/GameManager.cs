using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
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

    private float clearTime;

    public bool isClear = false;

   

    // Update is called once per frame
    void Update()
    { 
        if(SceneManager.GetActiveScene().name == "Clear" && isClear)
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking ((int) Mathf.Ceil(clearTime));
            isClear = false;
        }     
        else if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            Debug.Log(clearTime);
            clearTime += Time.deltaTime;
        }  
        else if(SceneManager.GetActiveScene().name == "Title")
        {
            clearTime = 0f;
            isClear = false;
        }
    }
}
