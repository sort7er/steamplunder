using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData {
    //  Data which needs to travel between scenes gets stored here
    
    public static bool Axe1Unlocked { get; private set; }
    public static bool Axe2Unlocked { get; private set; }
    
    public static int Health { get; private set; }

    public static void AddHealth(int amount) {
        Health += amount;
    }
}