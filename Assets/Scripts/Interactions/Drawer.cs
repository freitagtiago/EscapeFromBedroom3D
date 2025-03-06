using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _canMove = false;

    [SerializeField] private int _drawerIndex;
    [SerializeField] private float _speed = 2f;

    [SerializeField] private bool _isOpen = false;
    [SerializeField] private bool _isLocked = false;
    [SerializeField] private bool _animated = false;

    private Vector3 _closedPos;
    private Vector3 _openedPos;
    
    [SerializeField] private Transform _opened;
    [SerializeField] private Transform _closed;

    [SerializeField] private KeyType _neededKey = KeyType.None;
    [SerializeField] private ItemConfig _itemToOpen;

    [SerializeField] private string _textToShowWhenOpen;
    [SerializeField] private ItemConfig _item;
    [SerializeField] private AudioClip _opening;
    [SerializeField] private AudioClip _locked;

    private void Start()
    {
        if(!_animated) 
        { 
            return; 
        }

        _openedPos = _opened.position;
        _closedPos = transform.position;
    }

    private void Update()
    {
        if (!_animated 
            || !_canMove) 
        { 
            return; 
        }
        
        float step = _speed * Time.deltaTime;
        if (_isOpen)
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
       transform.position = Vector3.MoveTowards(transform.position, _openedPos, step);
        if (transform.position == _openedPos)
        {
            _canMove = false;
            _isOpen = true;
        }
    }

    private void CloseDrawer(float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, _closedPos, step);
        if (transform.position == _closedPos)
        {
            _canMove = false;
            _isOpen = false;
        }
    }

    public void Interact()
    {
        if (_isLocked)
        {
            if (_itemToOpen)
            {
                if(Inventory.Instance.HasThisItem(_itemToOpen))
                {
                    _isLocked = false;
                    UIHandler.Instance.WarningRoutine("Usando " + _itemToOpen._itemName + ", conseguiu abrir a gaveta");
                    return;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(_locked, transform.position);
                    UIHandler.Instance.WarningRoutine("A gaveta está emperrada");
                    return;
                }
            }
            else
            {
                if (Inventory.Instance.HasThisKey(_neededKey))
                {
                    UIHandler.Instance.WarningRoutine("A gaveta foi destrancada");
                    _isLocked = false;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(_locked, transform.position);
                    UIHandler.Instance.WarningRoutine("Esta gaveta está trancada, procure pela chave");
                    return;
                }
            }
        }

        if (_animated)
        {
            _canMove = true;
            AudioSource.PlayClipAtPoint(_opening, transform.position);
        }
        else
        {
            if(_item != null)
            {
                Inventory.Instance.AddItem(_item);
                _item = null;
            }
            else if(_textToShowWhenOpen != null)
            {
                UIHandler.Instance.WarningRoutine(_textToShowWhenOpen);
            }
        }
    }
}
