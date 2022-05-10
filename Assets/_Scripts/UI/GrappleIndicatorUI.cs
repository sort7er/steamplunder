using System;
using UnityEngine;

public class GrappleIndicatorUI : MonoBehaviour {

    [SerializeField] private GameObject grappleIndicator;

    private GrapplePoint _currentGrapplePoint;
    private Camera _cam;

    private void Awake() {
        _cam = Camera.main;
        GrapplePoint.OnPointEnter += OnPointEnter;
        GrapplePoint.OnPointExit += OnPointExit;
    }

    private void Update() {
        if (_currentGrapplePoint != null) {
            grappleIndicator.transform.position = _cam.WorldToScreenPoint(_currentGrapplePoint.transform.position);
        }
    }

    private void OnPointEnter(GrapplePoint point) {
        _currentGrapplePoint = point;
        grappleIndicator.SetActive(true);
    }
    
    private void OnPointExit(GrapplePoint point) {
        if (_currentGrapplePoint == point) {
            grappleIndicator.SetActive(false);
            _currentGrapplePoint = null;
        }
    }

}
