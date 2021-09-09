using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInsManager : MonoBehaviour
{
    public float span = 5;
    public GameObject[] enemy;
    private int i;
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(span);

            i = Random.Range(0,3);
            Instantiate(enemy[i], gameObject.transform.position,Quaternion.identity);
            span = Random.Range(5, 20);

        }
    }
}
