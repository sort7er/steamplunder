using UnityEngine;

public class Player : MonoBehaviour, IDamageable {

    [SerializeField] private int maxHealth = 100;
    
    
    private void Awake() {
        PlayerData.Init(maxHealth);
    }

    public void Damage(int amount) {
        PlayerData.SetHealth(PlayerData.Health - amount);
        if (PlayerData.Health <= 0) Die();
    }

    public void Heal(int amount) {
        int healthToSet = PlayerData.Health + amount;
        if (healthToSet > maxHealth) healthToSet = maxHealth;
        PlayerData.SetHealth(healthToSet);
    }

    private void Die() {
        
    }
}
