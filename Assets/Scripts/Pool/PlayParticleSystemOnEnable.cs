using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystemOnEnable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _particleSystem.Play();
    }
}