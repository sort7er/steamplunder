using System;
using UnityEngine;

public class Grapple : ArtifactBase {

    [SerializeField] private float grappleRange = 8f;
    [SerializeField] private float maxHeightDifference = 3.5f;

    public static bool CanGrappleToPoint { get; private set; }

    private float _sqrGrappleRange;
    
    public override void Use() {
        if (GrapplePoint.CurrentGrapplePoint == null || !CanGrappleToPoint) return;
        base.Use();
        
    }

    protected override void Awake() {
        base.Awake();
        _sqrGrappleRange = Mathf.Pow(grappleRange, 2);
    }

    private void Update() {
        CanGrappleToPoint = InRangeOfGrapplePoint() && IsPathClear();
    }

    private bool InRangeOfGrapplePoint() {
        if (GrapplePoint.CurrentGrapplePoint == null) return false;
        var grapplePointPos = GrapplePoint.CurrentGrapplePoint.transform.position;
        var vectorToGrapplePoint = grapplePointPos - transform.position;
        //Use squared values to avoid sqrt calculation
        var sqrDistance = vectorToGrapplePoint.sqrMagnitude;
        bool inRange = sqrDistance < _sqrGrappleRange;
        bool inHeight = vectorToGrapplePoint.y <= maxHeightDifference;
        return inRange && inHeight;
    }

    private bool IsPathClear() {
        if (GrapplePoint.CurrentGrapplePoint == null) return false;
        //raycast stuff
        return true;
    }
    
}
