using UnityEngine;

public class Hammer : ArtifactBase {
    
    /*
     * 1. Write out hammer functionality
     * 2. Find similarities to axe and abstract them
     * 3. Add support for double interaction indicator
     * 4. No cooldown on puzzle element hit
     */

    public override void Use() {
        base.Use();
        _animator.SetTrigger("Hammer");
    }
}
