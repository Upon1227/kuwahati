using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movedir = Vector3.zero;

    private float moveSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            movedir.z = -Input.GetAxis("Vertical") * moveSpeed;

            movedir.x =  Input.GetAxis("Horizontal") * moveSpeed;

            if (Input.GetButton("Jump"))
            {
                movedir.y = 150f;
            }
        }

        movedir.y -= 200f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.y = 0;
        }
    }
}
