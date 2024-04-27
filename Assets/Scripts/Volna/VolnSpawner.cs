using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VolnSpawner : MonoBehaviour
{
    [SerializeField] private float _minSpawmRate;
    [SerializeField] private float _maxSpawmRate;

    [SerializeField] private Pool VolnPool;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BiggerEnemies"))
        {
            _minSpawmRate -= 4f;
            _maxSpawmRate -= 4f;
        }

        StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            VolnPool.GetFreeElement(transform.position);
            yield return new WaitForSeconds(Random.Range(_minSpawmRate, _maxSpawmRate));
        }
    }
}