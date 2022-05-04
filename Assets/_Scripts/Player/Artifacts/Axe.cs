using System;
using UnityEngine;

public class Axe : ArtifactBase {

    [SerializeField] private float comboQueueTime = .5f;

    private float _queuedTime;

    public override void Use() {
        base.Use();
        _animator.SetTrigger("Attack 1");
    }

    private void Update() {
        if (_ready) return;

        _queuedTime -= Time.deltaTime;
        if (Input.GetKeyDown(inputKey)) _queuedTime = comboQueueTime;
    }
}
