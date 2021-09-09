using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public bool isStop;
    public float movespeed;
    private void Update()
    {
        if(isStop == false)
        {
            transform.position -= new Vector3(movespeed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stop")
        {
            anim.SetBool("isStop", true);
            isStop = true;
            StartCoroutine(startmove());
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (other.gameObject.tag == "Des")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator startmove()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("isStop", false);
        isStop = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
