using UnityEditor;

public static class CheatMenu {

    [MenuItem("DevTools/100 HP")]
    public static void MaxHP() {
        PlayerData.SetHealth(100);
    }
    
    [MenuItem("DevTools/1 HP")]
    public static void OneHP() {
        PlayerData.SetHealth(1);
    }
    
    [MenuItem("DevTools/Unlock Axe")]
    public static void UnlockAxe() {
        PlayerData.UnlockArtifact(Artifact.Axe);
    }

}
