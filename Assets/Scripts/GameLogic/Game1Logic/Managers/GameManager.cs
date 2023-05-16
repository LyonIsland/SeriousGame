using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    public PlayerStats playerStats;
    
    private CinemachineFreeLook followCamera;

    public List<IEndGameObserver> endGameObservers = new List<IEndGameObserver>();
    // Start is called before the first frame update
    
    public void RigisterPlayer(PlayerStats player)
    {
        Debug.Log("register");
        playerStats = player;

        followCamera = FindObjectOfType<CinemachineFreeLook>();
        if (followCamera != null)
        {
            followCamera.Follow = playerStats.transform.GetChild(0);
            followCamera.LookAt = playerStats.transform.GetChild(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
