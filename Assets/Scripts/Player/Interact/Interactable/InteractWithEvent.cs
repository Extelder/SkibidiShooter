using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractWithEvent : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _destroyAfterInteract;
    
    public UnityEvent Interacted;
    
    public void Interact()
    {
        Interacted?.Invoke();
        if (_destroyAfterInteract)
        {
            Destroy(gameObject);
        }
    }
}
