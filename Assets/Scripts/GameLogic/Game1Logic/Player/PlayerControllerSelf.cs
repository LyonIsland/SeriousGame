using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// 坑：Unity当中的Gyroscope类有两种，
// 第一种：访问到陀螺仪偏转的角速度信息
// using Gyroscope = UnityEngine.InputSystem.Gyroscope;
// 第二种：访问到陀螺仪偏转的角度信息（设备空间）、以及角速度
// using Gyroscope = UnityEngine.Gyroscope;


public class PlayerControllerSelf : MonoBehaviour
{
    private PlayerStats playerStats;
    public float movingSpeed;
    public float edgeAbs;
    //public KeyCode left;
    //public KeyCode right;
    private bool isMove;

    [Header("PC端逻辑测试选项")] 
    public bool isPCTesting;
    CharacterController characterController;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        //left = KeyCode.A;
        //right = KeyCode.D;
        GameManager.Instance.RigisterPlayer(playerStats);

        isMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isPCTesting)
        {
            Vector3 acc = Accelerometer.current.acceleration.ReadValue();
            if ((acc.x < -0.3 && acc.y > -1.0) || (acc.x > 0.3 && acc.y > -1.0))
            {
                if (Mathf.Abs(transform.position.x) < edgeAbs)
                {
                    isMove = true;
                }

                if (Mathf.Abs(transform.position.x) >= edgeAbs)
                {
                    if (acc.x * transform.position.x > 0)
                    {
                        isMove = false;
                    }
                    else
                        isMove = true;
                }
            }
            if (isMove)
            {
                this.transform.position = new Vector3(this.transform.position.x + movingSpeed * acc.x * Time.fixedDeltaTime,
                    this.transform.position.y, this.transform.position.z);

            }
        }
        else
        {
            var horizontal = Input.GetAxis("Horizontal");
            var move = transform.right * movingSpeed * horizontal * Time.deltaTime;
            characterController.Move(move);
            this.transform.GetChild(0).Rotate(Vector3.forward * Time.deltaTime*-10 * horizontal, Space.World);
        }

    }

}
