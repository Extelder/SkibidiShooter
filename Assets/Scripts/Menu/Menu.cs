using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private UnityEvent OnRewardedError;
    [SerializeField] private UnityEvent OnRewardedShowed;

    private bool _menuOpened;

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("BiggerEnemies"))
        {
            OnRewardedShowed?.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenCloseMenu();
        }
    }

    private void OpenCloseMenu()
    {
        _menuOpened = !_menuOpened;
        if (_menuOpened)
        {
            Time.timeScale = 0.1f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void LoadArenaScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenGamesUrl()
    {
        Application.ExternalEval("window.open(\"" + "https://yandex.ru/games/developer?name=IRS" + "\")");
    }

    public void ShowRewarded()
    {
        YandexSDK.instance.ShowRewarded("placement");
        YandexSDK.instance.onRewardedAdReward += RewardShowedSucsesfull;
        YandexSDK.instance.onRewardedAdError += RewardShowedError;
    }

    public void RewardShowedSucsesfull(string param)
    {
        OnRewardedShowed?.Invoke();
        PlayerPrefs.SetString("BiggerEnemies", "Showed");
    }

    public void RewardShowedError(string param)
    {
        OnRewardedError?.Invoke();
    }
}