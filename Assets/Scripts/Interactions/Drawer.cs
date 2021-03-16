using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{
    [SerializeField] bool canMove = false;

    [SerializeField] int drawerIndex;
    [SerializeField] float speed = 2f;

    [SerializeField] bool isOpen = false;
    [SerializeField] bool isLocked = false;
    [SerializeField] bool animated = false;

    Vector3 closedPos;
    Vector3 openedPos;
    
    [SerializeField] Transform opened;
    [SerializeField] Transform closed;

    [SerializeField] KeyType neededKey = KeyType.None;
    [SerializeField] ItemConfig itemToOpen;

    [SerializeField] string textToShowWhenOpen;
    [SerializeField] ItemConfig item;
    [SerializeField] AudioClip opening;
    [SerializeField] AudioClip locked;

    private void Start()
    {
        if(!animated) { return; }

        openedPos = opened.position;
        closedPos = transform.position;
    }

    private void Update()
    {
        if (!animated || !canMove) { return; }
        
        float step = speed * Time.deltaTime;
        if (isOpen)
        {
            CloseDrawer(step);
        }
        else
        {
            OpenDrawer(step);
        }
    }
    
    private void OpenDrawer(float step)
    {
       transform.position = Vector3.MoveTowards(transform.position, openedPos, step);
        if (transform.position == openedPos)
        {
            canMove = false;
            isOpen = true;
        }
    }

    private void CloseDrawer(float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, closedPos, step);
        if (transform.position == closedPos)
        {
            canMove = false;
            isOpen = false;
        }
    }

    public void Interact()
    {
        if (isLocked)
        {
            if (itemToOpen)
            {
                if(Inventory.instance.HasThisItem(itemToOpen))
                {
                    isLocked = false;
                    UIHandler.instance.WarningRoutine("Usando " + itemToOpen.itemName + ", conseguiu abrir a gaveta");
                    return;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(locked, transform.position);
                    UIHandler.instance.WarningRoutine("A gaveta esta emperrada");
                    return;
                }
            }
            else
            {
                if (Inventory.instance.HasThisKey(neededKey))
                {
                    UIHandler.instance.WarningRoutine("A gaveta foi destrancada");
                    isLocked = false;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(locked, transform.position);
                    UIHandler.instance.WarningRoutine("Esta gaveta esta trancada, procure pela chave");
                    return;
                }
            }
        }

        if (animated)
        {
            canMove = true;
            AudioSource.PlayClipAtPoint(opening, transform.position);
        }
        else
        {
            if(item != null)
            {
                Inventory.instance.AddItem(item);
                item = null;
            }
            else if(textToShowWhenOpen != null)
            {
                UIHandler.instance.WarningRoutine(textToShowWhenOpen);
            }
        }
    }
}
