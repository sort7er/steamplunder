using System.Collections.Generic;
using UnityEngine;

public static class PlayerData {
    /*
     * Data which needs to travel between scenes gets stored here
    */
    
    //Health
    public static int Health { get; private set; }

    public static void AddHealth(int amount) => Health += amount;
    public static void SetHealth(int amount) => Health = amount;

    //Gear
    public static Dictionary<Gear, bool> GearStatus { get; private set; } = new();

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