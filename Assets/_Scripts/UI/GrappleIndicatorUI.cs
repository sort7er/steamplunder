using System;
using UnityEngine;
using UnityEngine.UI;

public class GrappleIndicatorUI : MonoBehaviour {

    [SerializeField] private Image grappleIndicator;

    private Camera _cam;

    private void Awake() {
        _cam = Camera.main;
        GrapplePoint.OnStateChanged += OnGrapplePointStateChanged;
    }

    private void OnDestroy() {
        GrapplePoint.OnStateChanged -= OnGrapplePointStateChanged;
    }

    private void Update() {
        if (GrapplePoint.CurrentGrapplePoint != null) {
            grappleIndicator.transform.position = 
                _cam.WorldToScreenPoint(GrapplePoint.CurrentGrapplePoint.transform.position);
            grappleIndicator.color = Grapple.CanGrappleToPoint ? Color.green : Color.red;
        }
    }
    
    private void OnGrapplePointStateChanged(bool state) {
        grappleIndicator.gameObject.SetActive(state);
    }

}
