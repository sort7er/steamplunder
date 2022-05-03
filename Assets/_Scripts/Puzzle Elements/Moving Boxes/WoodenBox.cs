using UnityEngine;

public class WoodenBox : MonoBehaviour, IInteractable {

    [SerializeField] private float raycastLength = 1.5f;

    public bool HoldToInteract => false;

    public void Interact() {
        AttemptMove();
    }

    public string GetDescription() {
        return "Push box";
    }
    
    private void AttemptMove() {
        var currentPlayer = Player.GetPlayer();
        if (currentPlayer == null) return;

        Vector3 moveDirection = GetMoveDirection(currentPlayer.transform.position);
        Debug.Log(moveDirection);
    }

    private Vector3 GetMoveDirection(Vector3 playerPosition) {
        Vector3 playerVector = (transform.position - playerPosition).normalized;
 
        var forwardDot = Vector3.Dot(playerVector, transform.forward);
        var rightDot = Vector3.Dot(playerVector, transform.right);

        if(Mathf.Abs(forwardDot) >= Mathf.Abs(rightDot)) {
            if (forwardDot > 0) return transform.forward;
            return -transform.forward;
        }

        if (rightDot > 0) return transform.right;
        return -transform.right;
    }

    //To visualize where the box will check for grid tiles
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        
        var t = transform;
        var position = t.position;
        Gizmos.DrawLine(position, position + t.forward * raycastLength);
        Gizmos.DrawLine(position, position - t.forward * raycastLength);
        Gizmos.DrawLine(position, position + t.right * raycastLength);
        Gizmos.DrawLine(position, position - t.right * raycastLength);
    }
}
