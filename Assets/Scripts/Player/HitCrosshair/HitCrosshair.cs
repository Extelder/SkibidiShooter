using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HitCrosshair : MonoBehaviour
{
    [SerializeField] private AnimationCurve _hitAlphaAnimationCurve;
    [SerializeField] private Image _crosshair;

    private CompositeDisposable _disposable = new CompositeDisposable();
    private float _currentTime, _totalTime;

    public static HitCrosshair Instance { get; private set; }


    private void Start()
    {
        _totalTime = _hitAlphaAnimationCurve.keys[_hitAlphaAnimationCurve.keys.Length - 1].time;
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void EnemyHitted()
    {
        _disposable.Clear();
        _crosshair.color = Color.white;
        _currentTime = 0;

        Observable.EveryUpdate().Subscribe(_ =>
        {
            Color color = new Color(_crosshair.color.r, _crosshair.color.g, _crosshair.color.b,
                _hitAlphaAnimationCurve.Evaluate(_currentTime));
            _currentTime += Time.deltaTime;

            _crosshair.color = color;
            if (_currentTime >= _totalTime)
            {
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    public void EnemyKilled()
    {
        _disposable.Clear();
        _crosshair.color = Color.red;
        _currentTime = 0;

        Observable.EveryUpdate().Subscribe(_ =>
        {
            Color color = new Color(_crosshair.color.r, _crosshair.color.g, _crosshair.color.b,
                _hitAlphaAnimationCurve.Evaluate(_currentTime));
            _currentTime += Time.deltaTime;

            _crosshair.color = color;
            if (_currentTime >= _totalTime)
            {
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }
}