using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private void Start() {
        //Additive mode adds the Scene to the current loaded Scenes, in this case Gameplay scene
        SceneManager.LoadSceneAsync("Gameplay");
        SceneManager.LoadSceneAsync("Scene1x", LoadSceneMode.Additive);
    }
}
