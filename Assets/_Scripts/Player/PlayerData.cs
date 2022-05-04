using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class PlayerData {
    /*
     * Data which needs to travel between scenes gets stored here
    */

    private static bool _initialized;
    
    public static void Init(int maxHealth) {
        if (_initialized) return;

        if (Health == 0) SetHealth(maxHealth);
        SetupArtifactStatus();

        _initialized = true;
    }
    
    //Health
    public static int Health { get; private set; }

    public static void SetHealth(int amount) {
        Health = amount;
        OnHealthChanged?.Invoke(Health);
    }

    public static event Action<int> OnHealthChanged;

    //Gear
    public static Dictionary<Artifact, bool> ArtifactStatus { get; } = new();

    private static void SetupArtifactStatus() {
        var listOfArtifacts = Enum.GetValues(typeof(Artifact)).Cast<Artifact>();
        foreach (var artifactType in listOfArtifacts) {
            ArtifactStatus.Add(artifactType, true);//change back to false when done testing
        }
    }
    
    public static void UnlockArtifact(Artifact artifactType) {
        if (ArtifactStatus.ContainsKey(artifactType)) {
            ArtifactStatus[artifactType] = true;
            OnArtifactUnlocked?.Invoke(artifactType);
        } else {
            Debug.Log($"No {artifactType.ToString()} in the system yet!");
        }
    }

    public static event Action<Artifact> OnArtifactUnlocked;

}