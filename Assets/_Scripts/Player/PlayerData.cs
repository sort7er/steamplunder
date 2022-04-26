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
        SetupGear();

        _initialized = true;
    }
    
    //Health
    public static int Health { get; private set; }

    public static void SetHealth(int amount) => Health = amount;

    //Gear
    public static Dictionary<Gear, bool> GearStatus { get; } = new();

    private static void SetupGear() {
        var listOfGear = Enum.GetValues(typeof(Gear)).Cast<Gear>();
        foreach (var gearType in listOfGear) {
            GearStatus.Add(gearType, false);
        }
    }
    
    public static void UnlockGear(Gear gearType) {
        if (GearStatus.ContainsKey(gearType)) {
            GearStatus[gearType] = true;
        } else {
            Debug.Log($"No {gearType.ToString()} in the system yet!");
        }
    }

}

public enum Gear {
    Axe,
    Spin,
    Gun,
    Hammer,
    Grapple,
    Steamer
}