using System;
using UnityEngine;

public class GrapplePoint : MonoBehaviour {

    public static Action<GrapplePoint> OnPointEnter;
    public static Action<GrapplePoint> OnPointExit;

    private void OnMouseEnter() {
        OnPointEnter?.Invoke(this);
    }

    private void OnMouseExit() {
        OnPointExit?.Invoke(this);
    }

}
