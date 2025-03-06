using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _interactableDistance = 4.5f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(transform.position, hit.transform.position) <= _interactableDistance)
                {
                    hit.collider.GetComponent<IInteractable>()?.Interact();
                }   
            }
        }
    }
}
