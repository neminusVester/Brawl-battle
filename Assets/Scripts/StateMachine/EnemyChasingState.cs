using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : State
{
    private Enemy _enemy;
    public EnemyChasingState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public override void Update()
    {
        base.Update();
        _enemy.agent.SetDestination(_enemy.player.position);
    }
}
