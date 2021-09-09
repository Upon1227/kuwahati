using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public static bool isLock;
    [SerializeField]
    private GameObject Eye;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLock)
        {
            Eye.SetActive(true);
        }
        else
        {
            Eye.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            isLock = true;
        }
        else
        {
            isLock = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            isLock = false;
        }
    }
}
