using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private InteractionUI interactionUI;

    private Camera _cam;

    private void Awake() {
        _cam = Camera.main;
    }

    private void LateUpdate() {
        InteractionRay();
    }

    private void InteractionRay() {
        Ray ray = new Ray(transform.position, transform.forward);
        bool hitSomething = false;

        if (Physics.Raycast(ray, out var hit, interactionDistance)) {
            var interactable = hit.collider.GetComponent<InteractableBase>();

            if (interactable != null) {
                hitSomething = true;
                interactionUI.SetIndicator(interactable);
                interactionUI.SetPosition(_cam.WorldToScreenPoint(hit.collider.transform.position));

                if (interactable.holdToInteract && Input.GetKey(interactable.InteractKey)) {
                    interactable.Interact();
                    return;
                }

                if (Input.GetKeyDown(interactable.InteractKey)) {
                    interactable.Interact();
                    interactionUI.gameObject.SetActive(false);
                    return;
                }
            }
        }
        
        interactionUI.gameObject.SetActive(hitSomething);
    }
}