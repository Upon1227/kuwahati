using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    private Vector3 mousePos;

    private Vector3 angle = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            angle = player.transform.localEulerAngles;
            mousePos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(1))
        {
            angle.y -= (Input.mousePosition.x - mousePos.x) * 0.1f;
            angle.x -= (Input.mousePosition.y - mousePos.y) * 0.1f;

            player.gameObject.transform.localEulerAngles = angle;

            mousePos = Input.mousePosition;
        }
    }
}
