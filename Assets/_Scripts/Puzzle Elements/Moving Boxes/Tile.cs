using UnityEngine;

public class Tile : MonoBehaviour {

    private WoodenBox _currentBox = null;

    public bool TileOccupied => _currentBox != null;

    public Vector3 TakeTile(WoodenBox box) {
        _currentBox = box;
        return transform.position;
    }
    
}
