using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private AudioSource audioSource;

    private static int sceneToChange;

    void Awake() {

        audioSource = GetComponent<AudioSource> ();

    }

	/// <summary>
	/// Loads the scene in an ordered manner
	/// </summary>
	/// <param name="_scene">The number of the scene in the hierarchy</param>
    public void LoadScene(int _scene) {
		
		sceneToChange = _scene;

        if (audioSource != null) {
			
			audioSource.PlayOneShot(audioSource.clip);
			Invoke("ChangeScene", audioSource.clip.length / 2);
			
		} else {
			
			Invoke("ChangeScene", 0);
			
		}

    }

    void ChangeScene() {
        SceneManager.LoadScene(sceneToChange);
    }

    public void Exit() {

        audioSource.PlayOneShot(audioSource.clip);

        Invoke("Quit", audioSource.clip.length - 0.2f);

    }

    void Quit() {
        Application.Quit();
    }

}