using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesWeapon : WeaponBase
{
    
    private Transform _targetBulletPosition;
    private EnemyAttackingState _enemyAttackingState;
    private float _timeBetweenAttack = 0.5f;
    [SerializeField] private GameObject _enemyBulletPrefub;

    public EnemiesWeapon(EnemyAttackingState enemyAttackingState)
    {
        _enemyAttackingState = enemyAttackingState;
    }
    private void Start()
    {
        _targetBulletPosition = PlayerController.Instance.transform;
        // _enemyBulletPrefub = _enemyAttackingState.enemyBulletPrefub;
    }

    private void Update()
    {
        if(!EnemyAttackingState.alreadyAttacked)
        {
            Debug.Log("!already attacked");
            Shoot();
        }
        else Debug.Log("already attacked");
        
    }

    /* public override void Shoot()
    {
        InstantiateBullet(_enemyAttackingState.enemyBulletPrefub, this.transform, _enemyAttackingState.player, Quaternion.identity);
    } */
    public override void Shoot()
    {
        InstantiateBullet(_enemyBulletPrefub, this.transform, _targetBulletPosition, Quaternion.identity);
    }
}
