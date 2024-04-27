using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyKilled : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public static EnemyKilled Instance { get; private set; }

    private int _enemiesDead;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    private void Start()
    {
        _enemiesDead = PlayerPrefs.GetInt("EnemyKilled");
        _text.text = _enemiesDead.ToString();
    }

    public void OnEnemyKilled()
    {
        _enemiesDead += 1;
        _text.text = _enemiesDead.ToString();
        PlayerPrefs.SetInt("EnemyKilled", _enemiesDead);
    }
}