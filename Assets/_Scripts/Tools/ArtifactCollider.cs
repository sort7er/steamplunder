using System;
using UnityEngine;
using UnityEngine.Events;

public class ArtifactCollider : MonoBehaviour, IInteractable {

    [SerializeField] private Artifact artifact;
    [SerializeField] private UnityEvent onArtifactHit;

    public void OnHit(Artifact type) {
        if (type == artifact) onArtifactHit.Invoke();
    }

    public bool HoldToInteract { get; }
    public void Interact() {
        onArtifactHit.Invoke();
    }

    public string GetDescription() {
        return $"Use {artifact}";
    }
}
