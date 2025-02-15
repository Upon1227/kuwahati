﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField]
    private GameObject Balu;

    [SerializeField]
    public GameObject text_g,text_g1,text_g2;

    public Slider slid;
    public float v = 0;

    bool isY, isJ, isS, isMove;

    public GameObject ti;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.P)) // ゲームオーバー遷移仮
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            sceneChange.GameOver();
        }*/
        slid.value = v;

        if(slid.value >= 100)
        {
            GameObject S = GameObject.Find("Scenechange");
            S.GetComponent<SceneChange>().GameOver();
        }
        if (isBreak)
        {
            Balu.SetActive(true);
           
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            //3秒後
            
            SoundManager.instance.PlaySE(SoundManager.SE.Dance1);
            if (LockManager.isLock && isJ == false)
            {
                StartCoroutine(StopJ());   
                isJ = true;
                v -= Random.Range(5, 10);
                SoundManager.instance.PlaySE(SoundManager.SE.FeelGood);
            }
            anim.SetTrigger("JDance");
            
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //5秒後
            
            SoundManager.instance.PlaySE(SoundManager.SE.Dance2);
            if (LockManager.isLock && isY == false)
            {
                StartCoroutine(StopY());
                isY = true;
                v -= Random.Range(5, 10);
                SoundManager.instance.PlaySE(SoundManager.SE.FeelGood);
            }
            anim.SetTrigger("YDance");
            
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            //16秒
            
            SoundManager.instance.PlaySE(SoundManager.SE.Dance3);
            if (LockManager.isLock && isS == false)
            {
                StartCoroutine(StopS());
                isS = true;
                v -= Random.Range(5, 10);
                SoundManager.instance.PlaySE(SoundManager.SE.FeelGood);
            }
            anim.SetTrigger("SDance");
            
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SoundManager.instance.PlaySE(SoundManager.SE.Uho);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SoundManager.instance.PlaySE(SoundManager.SE.Uki);
        }

        SetMoveAnim();
    }
    
    IEnumerator StopJ()
    {
        yield return new WaitForSeconds(3);
        isJ = false;
    }
    IEnumerator StopY()
    {
        yield return new WaitForSeconds(3);
        isY = false;
    }
    IEnumerator StopS()
    {
        yield return new WaitForSeconds(3);
        isS = false;
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
        if(isJ == false && isY == false && isS == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
            vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

            if (horizontal == 0 && vertical == 0) // アイドル
            {
                anim.SetFloat("Speed", 0f);
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift)) // ダッシュ
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
                    anim.SetFloat("Speed", 2f); // 歩く
                }
            }
        }
    
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "BreakStone")
        {
            
            if (isBreak)
            {
                text_g.SetActive(true);
            }
            Debug.Log("Stone");
            // 武器を持っていて、スペースボタンを押したとき
            if (Input.GetKeyDown(KeyCode.Space) && isBreak && isMove == false)
            {
                isMove = true;
                if (LockManager.isLock)
                {
                    SoundManager.instance.PlaySE(SoundManager.SE.Booing);
                    v += Random.Range(10, 15);
                }
                // ここに殴るモーションアニメ入れる
                anim.SetTrigger("isattack");
                StartCoroutine(Blake(collision.gameObject));
            }         
        }
        if (collision.gameObject.tag == "Youmuin")
        {
            text_g1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("isBreakがTrue");
                anim.SetTrigger("isattack");

                StartCoroutine(Attack(collision.gameObject));
            }
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Youmuin")
        {
            if (LockManager.isLock)
            {
                GameObject S = GameObject.Find("Scenechange");
                S.GetComponent<SceneChange>().GameOver();
            }
            else
            {
                text_g1.SetActive(false);
            }
          
        }
        if (collision.gameObject.tag == "BreakStone")
        {
            text_g.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
  
    }
    float impulse = 300;
    IEnumerator Attack(GameObject collison)
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Uki);
        yield return new WaitForSeconds(1.2f);
        SoundManager.instance.PlaySE(SoundManager.SE.Damage);
        yield return new WaitForSeconds(0.2f);
        SoundManager.instance.PlaySE(SoundManager.SE.KnockOut);
        yield return new WaitForSeconds(0.6f);
        Destroy(collison.gameObject);
        Instantiate(ti, new Vector3(collison.transform.position.x,collison.transform.position.y + 10, collison.transform.position.z), Quaternion.identity);
        text_g1.SetActive(false);
        text_g2.SetActive(true);
        //Rigidbody rb2 = collison.gameObject.GetComponent<Rigidbody>();
        //  rb2.AddForce(Vector3.up * impulse, ForceMode.Impulse);
        isBreak = true; // 用務員を殴ると武器が手に入る
        yield return new WaitForSeconds(2);
        text_g2.SetActive(false);
    }
    IEnumerator Blake(GameObject collision)
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Uki);
        yield return new WaitForSeconds(1.5f);
        SoundManager.instance.PlaySE(SoundManager.SE.Break);
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        text_g.SetActive(false);
        isMove = false;
    }
}

