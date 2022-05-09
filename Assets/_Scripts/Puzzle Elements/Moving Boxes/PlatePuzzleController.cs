using System;
using UnityEngine;
using UnityEngine.Events;

public class PlatePuzzleController : MonoBehaviour {

    [SerializeField] private PlateTile[] platesToCheck;
    [SerializeField] private UnityEvent onPuzzleCompletion;

    private bool _completed;
    
    private void Start() {
        foreach (var plateTile in platesToCheck) {
            plateTile.OnPressStateChanged += OnPlatePressStateChanged;
        }
    }

    private void OnDisable() {
        foreach (var plateTile in platesToCheck) {
            plateTile.OnPressStateChanged -= OnPlatePressStateChanged;
        }
    }

    private void OnPlatePressStateChanged() {
        if (_completed) return;
        foreach (var plateTile in platesToCheck) {
            if (!plateTile.IsPressed) return;
        }
        
        //All plates are pressed if this point is reached
        _completed = true;
        onPuzzleCompletion.Invoke();
    }
    
}
