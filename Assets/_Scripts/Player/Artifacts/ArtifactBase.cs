using System;
using System.Collections;
using UnityEngine;

public abstract class ArtifactBase : MonoBehaviour {

    [Header("Settings")]
    [SerializeField] protected Artifact artifactType;
    [SerializeField] protected KeyCode inputKey;
    [SerializeField] protected int damage;
    [SerializeField] protected float cooldown;
    [SerializeField] protected GameObject artifactObject;
    
    protected bool _ready = true;
    protected Animator _animator;
    
    public event Action OnActionFinished;

    private void Awake() => _animator = GetComponent<Animator>();

    public bool CheckInput() {
        bool canUse = PlayerData.ArtifactStatus[artifactType] && _ready;
        return Input.GetKeyDown(inputKey) && canUse;
    }
    
    private IEnumerator AttackCooldown() {
        //CooldownBar.OnCooldownStarted.Invoke(cooldown);
        yield return new WaitForSeconds(cooldown);
        _ready = true;
    }

    public virtual void Use() {
        _ready = false;
        artifactObject.SetActive(true);
    }

    private void ActionEnded() {
        artifactObject.SetActive(false);
        OnActionFinished?.Invoke();
        StartCoroutine(AttackCooldown());
    }
}
