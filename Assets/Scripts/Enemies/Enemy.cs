using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine _SM;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public Transform enemyPos;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttack;
    
    public GameObject projectile;
    private Coroutine _delayCoroutine;
    //States
    private EnemyPatrolingState _patrolingState;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange; 

    void Awake()
    {
        player = PlayerController.Instance.transform;
        // player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _SM = new StateMachine();
        _patrolingState = new EnemyPatrolingState(this);
        _SM.Initialize(new EnemyPatrolingState(this));
    }

    void Update()
    {
        _SM.CurrentState.Update();
        enemyPos = transform;
        //Check for sight or attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) _SM.ChangeState(_patrolingState);
        if(playerInSightRange && !playerInAttackRange) _SM.ChangeState(new EnemyChasingState(this));
        // if(playerInSightRange && playerInAttackRange) _SM.ChangeState(new EnemyAttackingState(this));
        if(playerInSightRange && playerInAttackRange)
        {
            if(_delayCoroutine == null)_delayCoroutine = StartCoroutine(AttackDelay());
        } 
    }

    private IEnumerator AttackDelay()
    {
        _SM.ChangeState(new EnemyAttackingState(this));
        _delayCoroutine = null;
        yield return new WaitForSeconds(timeBetweenAttack);
        
    }
}
