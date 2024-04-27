using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask _checkMask;
    [SerializeField] private EnemyChasing _enemyChasing;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _checkRange;
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private float _checkRate;

    [SerializeField] private float _damage;

    private void OnEnable()
    {
        StartCoroutine(CheckingPlayerHealth());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator CheckingPlayerHealth()
    {
        while (true)
        {
            Collider[] other = new Collider[1];
            Physics.OverlapSphereNonAlloc(_checkPoint.position, _checkRange, other, _checkMask);
            if (other[0] != null)
                _enemyChasing.StopChase();
            else
                _enemyChasing.StartChase();
            yield return new WaitForSecondsRealtime(_checkRate);
        }
    }

    private void TryAttackPlayer()
    {
        Collider[] other = new Collider[1];
        Physics.OverlapSphereNonAlloc(_checkPoint.position, _checkRange, other, _checkMask);
        if (other[0] != null)
            _playerHealth.TakeDamage(_damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_checkPoint.position, _checkRange);
    }
}