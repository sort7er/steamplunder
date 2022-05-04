using System;
using UnityEngine;
using UnityEngine.Events;

public class ArtifactCollider : MonoBehaviour, IInteractable, IHittable {

    [SerializeField] private Artifact artifact;
    [SerializeField] private UnityEvent onArtifactHit;

    public bool HoldToInteract { get; }
    public void Interact() { }

    public string GetDescription() {
        return $"Use {artifact}";
    }

    public void Hit(int damage, Artifact source) {
        if (source == artifact) onArtifactHit.Invoke();
    }
}
