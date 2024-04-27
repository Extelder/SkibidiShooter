using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    public UnityEvent Death;

    public override void TakeDamage(float value)
    {
        Debug.Log("DamageTaken");
        if (!Dead)
        {
            HitCrosshair.Instance.EnemyHitted();
        }

        base.TakeDamage(value);
    }

    public override void HealthBelowOrEqualsZero()
    {
        if (!Dead)
        {
            HitCrosshair.Instance.EnemyKilled();
            Death?.Invoke();
            EnemyKilled.Instance.OnEnemyKilled();
        }

        base.HealthBelowOrEqualsZero();
    }
}