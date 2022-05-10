using System;
using UnityEngine;

public class GrapplePoint : MonoBehaviour {

    public static event Action<bool> OnStateChanged;

    public static GrapplePoint CurrentGrapplePoint { get; private set; }

    private void OnMouseEnter() {
        CurrentGrapplePoint = this;
        OnStateChanged?.Invoke(true);
    }

    private void OnMouseExit() {
        if (CurrentGrapplePoint == this) CurrentGrapplePoint = null;
        OnStateChanged?.Invoke(false);
    }

}
