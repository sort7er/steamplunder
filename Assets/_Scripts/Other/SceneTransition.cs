using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    public string sceneToLoad;
    public Vector2 playerPosition;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Awake() {
        if (fadeInPanel != null) {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(FadeCo());
        }
    }

    private IEnumerator FadeCo() {
        if (fadeOutPanel != null) {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone) {
            yield return null;
        }
    }
}