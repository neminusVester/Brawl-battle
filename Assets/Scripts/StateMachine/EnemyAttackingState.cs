using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : State
{
    private Enemy _enemy;
    private EnemiesWeapon _enemiesWeapon;
    public GameObject enemyBulletPrefub;
    public Transform player;
    public static bool alreadyAttacked = true;
    public EnemyAttackingState(Enemy enemy)
    {
        _enemy = enemy;
    }
    private void Start()
    {
        _enemiesWeapon = new EnemiesWeapon(this);
        enemyBulletPrefub = _enemy.projectile;
        player = _enemy.player;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("enter to attack state");
        alreadyAttacked = false;
        
    }

    public override void Update()
    {
        base.Update();
        
        //Make sure enemy doesn't move
        _enemy.agent.SetDestination(_enemy.transform.position);
        _enemy.transform.LookAt(player);
      /*   if (!alreadyAttacked)
        {
            Debug.Log("not attacked in attacking state");
            _enemiesWeapon.Shoot();
            alreadyAttacked = true;
            _enemy.Invoke(nameof(ResetAttack), _enemy.timeBetweenAttack);
        } */
    }

    public override void Exit()
    {
        base.Exit();
        alreadyAttacked = true;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

 
    
}
