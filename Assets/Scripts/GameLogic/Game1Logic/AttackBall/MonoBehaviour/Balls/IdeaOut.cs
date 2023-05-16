using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeaOut : BaseBall
{
    public string BuffName;
    // Start is called before the first frame update
    void Start()
    {
        this.BuffName = ballData.BuffName;
        this.speed = ballData.speed;
        this.damage = ballData.damage;
        
    }

    protected override void doBuff()
    {
        Debug.Log(BuffName+"doing Buff Logic");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
