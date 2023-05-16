using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    public GameObject attack1Prefab;

    public float attackFrequency;
    private float lastAttackTime;
    public float randomXSize;

    // Start is called before the first frame update
    void Start()
    {
        lastAttackTime = attackFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        //计时器，循环在攻击空间内激发一个attackball
        lastAttackTime -= Time.deltaTime;
        if (lastAttackTime <= 0)
        {
            attack();
        }
    }

    //随机生成攻击球
    void attack()
    {
        //TOTO：选择攻击球类型
        Vector3 startPos = new Vector3(transform.position.x+Random.Range(-randomXSize,randomXSize),transform.position.y,transform.position.z);
        Quaternion startRot = Quaternion.Euler(transform.rotation.eulerAngles);

        GameObject newAttackBall = Instantiate(attack1Prefab, startPos,startRot);
        lastAttackTime = attackFrequency;
    }
}
