using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class OutWorldTrigger : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out Character playerController))
        {
            playerController.enabled = false;
            playerController.transform.position = _respawnPoint.position;
            playerController.enabled = true;
        }
    }
}