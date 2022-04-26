using UnityEngine;

public class ColorConsole : InteractableBase {
    private bool hit;
    public override void Interact() {
        GetComponent<MeshRenderer>().material.color = hit ? Color.red : Color.green;

        hit = !hit;
    }

    public override string GetDescription() {
        return hit ? "Make cube red" :"Make cube green";
    }
}