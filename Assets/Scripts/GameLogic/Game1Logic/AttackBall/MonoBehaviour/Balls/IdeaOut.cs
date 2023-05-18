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
    }

    protected override void doBuff()
    {
        Debug.Log(BuffName+"doing Buff Logic");
    }

}
