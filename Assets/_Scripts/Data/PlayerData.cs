public static class PlayerData {
    /*
     * Data which needs to travel between scenes gets stored here
    */
    
    //Health
    public static int Health { get; private set; }

    public static void AddHealth(int amount) {
        Health += amount;
    }
    
    //Gear Unlocks
    public static bool[] GearUnlocked { get; private set; } = new bool[6];
    
    //public static void UpdateGearUnlock
    
}

public enum GearType {
    Axe,
    Cog,
    Gun,
    Hammer,
    Grapple,
    Steamer
}