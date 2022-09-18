using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent _agent;

    public Transform _player;

    public LayerMask WhatIsGround, WhatIsPlayer;

    public Vector3 _walkPoint;
    bool _walkPointSet;
    public float _walkPointRange;

    public float _sightRange, _attackRange;
    public bool _playerInSightRange, _playerInAttackRange;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, WhatIsPlayer);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, WhatIsPlayer);

        if (!_playerInSightRange && !_playerInAttackRange) 
        {
            Patrolling();
        }
        if (_playerInSightRange && !_playerInAttackRange)
        {
            ChasePlayer();
        }
        if (_playerInSightRange && _playerInAttackRange)
        {
            AttackPlayer();
        }

    }

    private void Patrolling()
    {
        if (!_walkPointSet)
        {
            SearchWalkPoint();
        }
        if (_walkPointSet)
        {
            _agent.SetDestination(_walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            _walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_walkPoint,-transform.up,2f, WhatIsGround))
        {
            _walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    private void AttackPlayer()
    {

    }

}
