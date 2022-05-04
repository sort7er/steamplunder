using System;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactHitbox : MonoBehaviour {

    private List<IHittable> _entities;
    private bool _triggerEnabled;

    private void OnEnable() {
        _entities = new List<IHittable>();
        _triggerEnabled = false;
        Invoke(nameof(EnableTrigger), .2f);
    }

    private void EnableTrigger() => _triggerEnabled = true;

    private void OnTriggerEnter(Collider other) {
        if (!_triggerEnabled) return;
        if (other.TryGetComponent<IHittable>(out var hittable)) {
            if (_entities.Contains(hittable)) return;
            
            hittable.Hit(20, Artifact.Axe);
            _entities.Add(hittable);
        }
    }
}
