using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action<int, int> updateHealthBarOnAttack;

    public PlayerData_SO templateData;

    public PlayerData_SO playerData;
    
    #region Read from Data_SO
    public int MaxHealth
        {
            get { if (playerData != null) return playerData.maxHealth; else return 0; }
            set { playerData.maxHealth = value; }
        }
        public int CurrentHealth
        {
            get { if (playerData != null) return playerData.currentHealth; else return 0; }
            set { playerData.currentHealth = value; }
        }
    #endregion
    private void Awake()
    {
        if (templateData != null)
            playerData = Instantiate(templateData);
    }
    
    public void TakeDamage(int damage, PlayerStats player)
    {
        //int currentDamage = Mathf.Max((damage - player.CurrentDefence), 0); 后续可能会有增加防御力的buff
        int currentDamage = damage;
        CurrentHealth = Mathf.Max(CurrentHealth - currentDamage, 0);
        updateHealthBarOnAttack?.Invoke(CurrentHealth, MaxHealth);
    }

    public void AddScore(int score, PlayerStats player)
    {
        player.playerData.score += score;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
