using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifacts : MonoBehaviour {

    private ArtifactBase[] _artifacts;
    private bool _actionOngoing;

    private void Awake() {
        _artifacts = GetComponents<ArtifactBase>();

        foreach (var artifact in _artifacts) {
            artifact.OnActionFinished += ArtifactActionEnded;
            Debug.Log($"Found {artifact.GetType()}");
        }
    }

    private void Update() {
        if (_actionOngoing) return;
        
        foreach (var artifact in _artifacts) {
            if (artifact.CheckInput()) UseArtifact(artifact);
        }
    }

    private void UseArtifact(ArtifactBase artifact) {
        _actionOngoing = true;
        artifact.Use();
    }

    private void ArtifactActionEnded() {
        _actionOngoing = false;
    }
    
}
