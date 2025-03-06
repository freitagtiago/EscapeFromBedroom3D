using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private KeyType _neededKey = KeyType.None;
    [SerializeField] private bool _isLocked = true;
    [SerializeField] private AudioClip _doorSFX;
    Animator anim;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void Interact()
    {
        if (!_isLocked) 
        { 
            return; 
        }

        if (Inventory.Instance.HasThisKey(_neededKey))
        {
            UIHandler.Instance.WarningRoutine("A porta foi destrancada");
            if(_neededKey == KeyType.ExitDoor)
            {
                AudioSource.PlayClipAtPoint(_doorSFX, transform.position);
                anim.SetTrigger("exitDoorOpen");
            }
            else
            {
                AudioSource.PlayClipAtPoint(_doorSFX, transform.position);
                anim.SetTrigger("open");
            }
        }
        else
        {
            UIHandler.Instance.WarningRoutine("A porta está trancada, procure pela chave correta");
        }
    }
}
