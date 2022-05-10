using System;
using UnityEngine;

public class Grapple : ArtifactBase {

    [SerializeField] private float grappleRange = 8f;
    [SerializeField] private float maxHeightDifference = 3.5f;
    [SerializeField] private float extendSpeed = 10f;
    [SerializeField] private float retractSpeed = 5f;

    [SerializeField] private Transform clawTransform;
    [SerializeField] private Transform clawGearTransform;
    [SerializeField] private Transform tipTransform;
    [SerializeField] private LineRenderer lineRenderer;

    public static bool CanGrappleToPoint { get; private set; }

    private float _sqrGrappleRange;
    private PlayerMovement _playerMovement;
    private bool _isExtending;
    private Vector3 _lerpTo;
    
    protected override void Awake() {
        base.Awake();
        _sqrGrappleRange = Mathf.Pow(grappleRange, 2);
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        CanGrappleToPoint = CheckCanGrappleToPoint();

        if (_isExtending) {
            clawTransform.position = 
                Vector3.MoveTowards(clawTransform.position, _lerpTo, extendSpeed * Time.deltaTime);
            DrawRope();
        }
    }
    
    public override void Use() {
        if (GrapplePoint.Current == null || !CanGrappleToPoint) return;
        
        _lerpTo = GrapplePoint.Current.transform.position;
        lineRenderer.positionCount = 0;
        _playerMovement.SetFreeze(true);
        _playerMovement.LookAt(_lerpTo);
        _animator.SetTrigger("Grapple");
        base.Use();
    }

    private bool CheckCanGrappleToPoint() {
        if (GrapplePoint.Current == null) return false;
        
        var grapplePointPos = GrapplePoint.Current.transform.position;
        var vectorToGrapplePoint = grapplePointPos - transform.position;
        
        //Use squared values to avoid sqrt calculation
        var sqrDistance = vectorToGrapplePoint.sqrMagnitude;
        bool inRange = sqrDistance < _sqrGrappleRange;
        bool inHeight = vectorToGrapplePoint.y <= maxHeightDifference;
        return inRange && inHeight && InClearPath(vectorToGrapplePoint);
    }

    private bool InClearPath(Vector3 vectorToGrapplePoint) {
        Ray ray = new Ray(transform.position, vectorToGrapplePoint);
        int layerMask = 1 | 1 << 6; //bit shifting. Means that it will look at layers 1 (default) and 6 (ground)
        
        Debug.DrawLine(transform.position, GrapplePoint.Current.transform.position);
        if (Physics.Raycast(ray, out var hit, grappleRange, layerMask)) {
            if (hit.collider.TryGetComponent<GrapplePoint>(out _)) return true;
        }
        return false;
    }

    private void Extend() {
        Debug.Log("EXTEND");
        _isExtending = true;
    }

    private void DrawRope() {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, tipTransform.position);
        lineRenderer.SetPosition(1, clawGearTransform.position);
    }
    
}
