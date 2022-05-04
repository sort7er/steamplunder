using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] private KeyCode defaultInteractionKey = KeyCode.E;
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private InteractionIndicator interactionIndicator;

    private Camera _cam;

    private void Awake() {
        _cam = Camera.main;
    }

    private void LateUpdate() {
        InteractionRay();
    }

    private void InteractionRay() {
        var rayOrigin = transform.position + transform.up * .5f;
        Ray ray = new Ray(rayOrigin, transform.forward);
        bool hitSomething = false;

        if (Physics.Raycast(ray, out var hit, interactionDistance)) {
            var interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null) {
                hitSomething = true;
                interactionIndicator.SetIndicator(interactable, defaultInteractionKey.ToString());
                interactionIndicator.SetPosition(_cam.WorldToScreenPoint(hit.collider.transform.position));

                if (Input.GetKeyDown(defaultInteractionKey)) {
                    interactable.Interact();
                    interactionIndicator.gameObject.SetActive(false);
                    return;
                }
                
                if (interactable.HoldToInteract && Input.GetKey(defaultInteractionKey)) {
                    interactable.Interact();
                }
            }
        }
        
        interactionIndicator.gameObject.SetActive(hitSomething);
    }
}