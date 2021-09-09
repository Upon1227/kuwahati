using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    [SerializeField]
    private SceneChange sceneChange;


    private  void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            sceneChange.Clear();
            GameManager.instance.isClear = true;
        }
        
            
        
    }
}
