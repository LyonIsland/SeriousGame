using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall : MonoBehaviour
{
    public BallData_SO ballData;
    public float speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = ballData.speed;
        this.damage = ballData.damage;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moveAndRotate();
    }

    void moveAndRotate()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            this.transform.position.z - speed * Time.deltaTime);

        Vector3 angles = this.transform.localEulerAngles;
        angles.y += 260 * Time.deltaTime;
        this.transform.localEulerAngles = angles;
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
            GameManager.Instance.playerStats.TakeDamage(damage,GameManager.Instance.playerStats);
        }
    }
}
