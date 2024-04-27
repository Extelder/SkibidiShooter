using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasing : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private string _enemyAttackingAnimationBool = "IsAttacking";
    [SerializeField] private float _checkPlayerPositionRate;

    [SerializeField] private NavMeshAgent _agent;

    public bool IsChasing { get; private set; }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        StartChase();
    }

    public void StartChase()
    {
        if (IsChasing)
            return;
        IsChasing = true;
        _agent.isStopped = false;
        _enemyAnimator.SetBool(_enemyAttackingAnimationBool, false);
        StartCoroutine(Chasing());
    }

    public void StopChase()
    {
        IsChasing = false;
        _agent.isStopped = true;
        _enemyAnimator.SetBool(_enemyAttackingAnimationBool, true);
        StopAllCoroutines();
    }

    private IEnumerator Chasing()
    {
        while (true)
        {
            _agent.SetDestination(_player.position);

            yield return new WaitForSecondsRealtime(_checkPlayerPositionRate);
        }
    }
}