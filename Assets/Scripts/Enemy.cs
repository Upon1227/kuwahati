using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
        Move();
    }
    private void Ray()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, 0, -1));

        RaycastHit hit;

        //Rayの飛ばせる距離
        int distance = 100;

        Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

        if (Physics.Raycast(ray, out hit, distance))
        {
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "Player")
                Debug.Log("RayがPlayerに当たった");
        }
    }
    private void Move()
    {
        float moveArea = 50f;

        transform.position = new Vector3(Mathf.Sin(Time.time) * moveArea, transform.position.y, transform.position.z);
    }
}
