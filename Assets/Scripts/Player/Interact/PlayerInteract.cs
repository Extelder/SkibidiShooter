using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : Raycaster
{
    [SerializeField] private AudioSource _audioSource;

    private IInteractable _currentDetectedInteractable;

    public event Action<IInteractable> InteractableDetected;
    public event Action InteractableLost;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            TryInteract();
        if (CheckColliderHasComponent<IInteractable>(out Collider collider))
        {
            _currentDetectedInteractable = collider.GetComponent<IInteractable>();

            InteractableDetected?.Invoke(_currentDetectedInteractable);
        }
        else
        {
            _currentDetectedInteractable = null;
            InteractableLost?.Invoke();
        }
    }

    public void TryInteract()
    {
        _currentDetectedInteractable?.Interact();
        if (_currentDetectedInteractable != null)
        {
            _audioSource?.Play();
        }
    }
}