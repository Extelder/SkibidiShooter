using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryNSecondsAdd : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        StartCoroutine(ShowingAdd());

        YandexSDK.instance.onInterstitialShown += OnInternationShown;
        YandexSDK.instance.onInterstitialFailed += OnInternationShown;
    }
    
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnInternationShown()
    {
        Time.timeScale = 1;
        _audioSource.Play();
    }

    private void OnInternationShown(string error)
    {
        OnInternationShown();
    }

    private IEnumerator ShowingAdd()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(5f);
            YandexSDK.instance.ShowInterstitial();
            Time.timeScale = 0.01f;
            _audioSource.Stop();
        }
    }
}