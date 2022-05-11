using UnityEngine;
using UnityEngine.Events;

public class GrappleLever : GrapplePoint {

    [SerializeField] private UnityEvent onLeverPulled;

    public void PullLever() {
        onLeverPulled.Invoke();
        Destroy(this);
    }

}
