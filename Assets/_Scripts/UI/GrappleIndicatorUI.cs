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
        if (GrapplePoint.Current != null) {
            grappleIndicator.transform.position = 
                _cam.WorldToScreenPoint(GrapplePoint.Current.transform.position);
            grappleIndicator.color = Grapple.CanGrappleToPoint ? Color.green : Color.red;
        }
    }
    
    private void OnGrapplePointStateChanged(bool state) {
        grappleIndicator.gameObject.SetActive(state);
    }

}
