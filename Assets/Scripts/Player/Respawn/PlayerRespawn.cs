using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;

    private void Start()
    {
        transform.position = _respawnPoint.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position = _respawnPoint.position;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position = _respawnPoint.position;
        }
    }
}