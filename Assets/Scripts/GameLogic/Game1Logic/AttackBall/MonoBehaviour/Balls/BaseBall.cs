using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall : MonoBehaviour
{
    public BallData_SO ballData;
    Transform model;

    // Start is called before the first frame update


    // Update is called once per frame


    protected virtual void FixedUpdate()
    {
        moveAndRotate();

    }

    void moveAndRotate()
    {
        this.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * ballData.speed, Space.World);   
        transform.GetChild(0).transform.Rotate(Vector3.up, 220 * Time.deltaTime, Space.World);
        if (this.transform.position.z < GameObject.Find("mainCamera").transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void doBuff()
    {
        Debug.Log("执行增益或减益");
        //具体方法由子类函数重写
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        doBuff();
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.playerStats.AddScore(ballData.score, GameManager.Instance.playerStats);
            GameManager.Instance.playerStats.TakeDamage(ballData.damage,GameManager.Instance.playerStats);
            Destroy(gameObject);
        }
    }
}
