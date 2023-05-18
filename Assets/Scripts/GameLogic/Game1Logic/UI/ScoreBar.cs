using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBar : MonoBehaviour
{
    TMP_Text score;

    private void Awake()
    {
        score = this.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    private void Update()
    {
        score.text = GameManager.Instance.playerStats.playerData.score.ToString();
    }
}
