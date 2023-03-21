using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolingState : State
{
    private Enemy _enemy;

    public EnemyPatrolingState(Enemy enemy)
    {
        _enemy = enemy;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!_enemy.walkPointSet) SearchWalkPoint();
        if (_enemy.walkPointSet)
        {
            _enemy.agent.SetDestination(_enemy.walkPoint);

        }
        Vector3 distanceToWalkPoint = _enemy.transform.position - _enemy.walkPoint;

        //Walk point reached
        if (distanceToWalkPoint.magnitude < 1f)
            _enemy.walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-_enemy.walkPointRange, _enemy.walkPointRange);
        float randomX = Random.Range(-_enemy.walkPointRange, _enemy.walkPointRange);
        _enemy.walkPoint = new Vector3(_enemy.transform.position.x + randomX, _enemy.transform.position.y, _enemy.transform.position.z + randomZ);
        if (Physics.Raycast(_enemy.walkPoint, -_enemy.transform.up, 2f, _enemy.whatIsGround))
            _enemy.walkPointSet = true;
    }
}
