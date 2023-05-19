using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    public GameObject[] attackPrefabs;

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
            attack(pickBallByChance());
        }
    }

    //随机生成攻击球
    void attack(GameObject attackPrefab)
    {
        Vector3 startPos = new Vector3(transform.position.x+Random.Range(-randomXSize,randomXSize),transform.position.y,transform.position.z);
        Quaternion startRot = Quaternion.Euler(transform.rotation.eulerAngles);

        GameObject newAttackBall = Instantiate(attackPrefab, startPos,startRot);
        lastAttackTime = attackFrequency;
    }

    GameObject pickBallByChance()
    {
        int nowSeed = Random.Range(0,100);
        int nowChoose = 0;
        Debug.Log(nowSeed);
        GameObject attackPrefab1 = attackPrefabs[0];
        foreach(GameObject attackPrefab in attackPrefabs)
        {           
            int chance = attackPrefab.GetComponent<BaseBall>().ballData.chance;
            Debug.Log(attackPrefab.name + chance);
            nowChoose += chance;
            if (nowSeed < nowChoose)
                return attackPrefab;        
        }
        return attackPrefab1;
    }
}
