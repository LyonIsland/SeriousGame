using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthSlide;
    private PlayerStats currentStats;

    private Image healthSlider;

    private void Awake()
    {
        healthSlider = transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        float sliderPercent = (float)GameManager.Instance.playerStats.CurrentHealth / GameManager.Instance.playerStats.MaxHealth;
        healthSlider.fillAmount = sliderPercent;    
    }
}
