using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] KeyType neededKey = KeyType.None;
    [SerializeField] bool isLocked = true;
    [SerializeField] AudioClip clip;
    Animator anim;    

    private void Awake() => anim = GetComponentInParent<Animator>();

    public void Interact()
    {
        if (!isLocked) { return; }

        if (Inventory.instance.HasThisKey(neededKey))
        {
            UIHandler.instance.WarningRoutine("A porta foi destrancada");
            if(neededKey == KeyType.ExitDoor)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position);
                anim.SetTrigger("exitDoorOpen");
            }
            else
            {
                AudioSource.PlayClipAtPoint(clip, transform.position);
                anim.SetTrigger("open");
            }
        }
        else
        {
            UIHandler.instance.WarningRoutine("A porta esta trancada, procure pela chave correta");
        }
    }
}
