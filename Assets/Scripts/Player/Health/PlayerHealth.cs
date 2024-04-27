using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public UnityEvent Death;

    public override void HealthBelowOrEqualsZero()
    {
        Death?.Invoke();
    }
}