using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    private Animator anim;

    [SerializeField]
    private Camera cameraCtrl;

    private float moveSpeed = 6f;

    private float horizontal, vertical;

    private float maxMoveSpeed = 9f;

    private bool isBreak = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetMoveAnim();
    }
    private void FixedUpdate()
    {     
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(cameraCtrl.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * vertical + cameraCtrl.transform.right * horizontal;


        rb.velocity = moveForward * moveSpeed + new Vector3(0, -10, 0);
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }      
    }
    private void SetMoveAnim()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

        if (horizontal == 0 && vertical == 0)　// アイドル
        {
            anim.SetFloat("Speed", 0f);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))　// ダッシュ
            {
                anim.SetFloat("Speed", 8f);
                moveSpeed = maxMoveSpeed;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = 6f;
            }
            else
            {
                anim.SetFloat("Speed", 2f);　// 歩く
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "BreakStone")
        {
            // 武器を持っていて、スペースボタンを押したとき
            if (Input.GetKeyDown(KeyCode.Space) && isBreak)
            {
                // ここに殴るモーションアニメ入れる
                collision.gameObject.SetActive(false);
            }         
        }
        
        if (collision.gameObject.tag == "Youmuin")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("isBreakがTrue");
                isBreak = true;　// 用務員を殴ると武器が手に入る
            }           
            // 用務員殴る　
            // 武器のセットアクティブをtrueにする
        }
    }

}

