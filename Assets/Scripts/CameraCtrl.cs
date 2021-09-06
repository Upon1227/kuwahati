using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    private Vector3 mousePos;

    private Vector3 angle = new Vector3(0, 0, 0);

    private void Start()
    {
        mousePos = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += player.transform.position - mousePos;
        mousePos = player.transform.position;

        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(mousePos, Vector3.up, -mouseInputX * Time.deltaTime * 500f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            // transform.RotateAround(mousePos, transform.right, mouseInputY * Time.deltaTime * 300f);
        }
    }
}
