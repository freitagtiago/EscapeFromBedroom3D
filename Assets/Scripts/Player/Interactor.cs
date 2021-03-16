using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] float interactableDistance = 4.5f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                Debug.Log(hit.collider.name);
            if (Vector3.Distance(transform.position, hit.transform.position) <= interactableDistance)
                hit.collider.GetComponent<IInteractable>()?.Interact();
        }
    }
}
