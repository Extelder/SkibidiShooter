using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeaponShoot : Raycaster
{
    [SerializeField] private Animator _weaponAnimator;
    [SerializeField] private string _weaponShootAnimationBoolName = "IsShooting";
    [SerializeField] private Pool _hitEffectPool;
    [SerializeField] private float _hitDamage;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _weaponAnimator.SetBool(_weaponShootAnimationBoolName, true);
            return;
        }


        _weaponAnimator.SetBool(_weaponShootAnimationBoolName, false);
    }

    public void Shoot()
    {
        if (GetHitCollider(out Collider collider))
        {
            if (collider == null)
                return;
            if (collider.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(_hitDamage);
                _hitEffectPool.GetFreeElement(GetRaycastHit().point, Quaternion.identity, collider.transform);
            }
        }
    }
}