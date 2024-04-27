using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _menuCanvas.SetActive(!_menuCanvas.activeSelf);
        }
    }
}