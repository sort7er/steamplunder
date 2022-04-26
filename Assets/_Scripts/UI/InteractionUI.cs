using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour {

    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private TMP_Text keyText;
    [SerializeField] private GameObject holdIndicator;

    public void SetPosition(Vector3 pos) {
        transform.position = pos;
    }

    public void SetIndicator(InteractableBase interactable) {
        interactionText.text = interactable.GetDescription();
        keyText.text = interactable.InteractKey.ToString();
        holdIndicator.SetActive(interactable.holdToInteract);
    }
    
}