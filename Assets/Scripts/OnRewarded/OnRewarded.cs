using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnRewarded : MonoBehaviour
{
    [SerializeField] private YandexSDK _yandexSdk;

    public UnityEvent Added;

    private void OnEnable()
    {
        _yandexSdk.onRewardedAdReward += YandexSdkOnonRewardedAdReward;
    }

    private void YandexSdkOnonRewardedAdReward(string obj)
    {
        Added?.Invoke();
    }

    private void OnDisable()
    {
        _yandexSdk.onRewardedAdReward -= YandexSdkOnonRewardedAdReward;
    }
}