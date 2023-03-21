using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private float _rightSideOfMap;
    private float _upSideOfMap;
    private float _enemiesCount = 5;
    [SerializeField] private GameObject enemyPrefub;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Transform upWall;
    void Awake()
    {
        _rightSideOfMap = rightWall.position.x;
        _upSideOfMap = upWall.position.z;
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        for(int i = 0; i < _enemiesCount; i++)
        {
            float randomX = Random.Range(-_rightSideOfMap, _rightSideOfMap);
            float randomZ = Random.Range(-_upSideOfMap, _upSideOfMap);
            Vector3 enemyPosition = new Vector3(randomX, 0f, randomZ);
            Instantiate(enemyPrefub, enemyPosition, Quaternion.identity);
        }
    }
}
