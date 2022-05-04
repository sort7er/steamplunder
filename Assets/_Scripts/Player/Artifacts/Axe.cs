using UnityEngine;

public class Axe : ArtifactBase {

    public override void Use() {
        base.Use();
        _animator.SetTrigger("Attack 1");
    }
}
