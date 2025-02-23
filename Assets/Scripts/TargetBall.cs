using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : Ball
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void InPocket()
    {
        base.InPocket();

        gameManager.Respawn(ballIdx);
    }
}
