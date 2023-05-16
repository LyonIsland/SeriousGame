using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "AttackBall/Data")]
public class BallData_SO : ScriptableObject
{
    [Header("BasicAttribute")]
    public float speed;
    public int damage;
    public int score;

    [Header("Buff")]
    public string BuffName;
    public string BuffDescription;
    public string BuffTime;
}