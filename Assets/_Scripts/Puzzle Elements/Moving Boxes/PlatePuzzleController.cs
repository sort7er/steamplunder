using System;
using UnityEngine;
using UnityEngine.Events;

public class PlatePuzzleController : MonoBehaviour {

    [SerializeField] private bool canUndoPuzzle;
    [SerializeField] private PlateTile[] platesToCheck;
    [SerializeField] private UnityEvent onPuzzleCompletion;
    [SerializeField] private UnityEvent onPuzzleUndone;

    private bool _completed;
    
    private void Start() {
        foreach (var plateTile in platesToCheck) {
            plateTile.OnPressStateChanged += OnPlatePressStateChanged;
        }
    }

    private void OnDestroy() {
        foreach (var plateTile in platesToCheck) {
            plateTile.OnPressStateChanged -= OnPlatePressStateChanged;
        }
    }

    private void OnPlatePressStateChanged() {
        foreach (var plateTile in platesToCheck) {
            if (plateTile.IsPressed) continue;
            if (canUndoPuzzle) {
                if (_completed) onPuzzleUndone.Invoke();
                _completed = false;
            }
            return;
        }
        
        //All plates are pressed if this point is reached
        if (_completed) return;
        _completed = true;
        onPuzzleCompletion.Invoke();
    }
    
}
