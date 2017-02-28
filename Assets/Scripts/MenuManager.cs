using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private AudioSource audioSource;
	
	private static int sceneToChange;

    void Awake() {

        audioSource = GetComponent<AudioSource> ();

    }

    public void LoadScene(int _scene) {
		
		audioSource.PlayOneShot(audioSource.clip);
		
		sceneToChange = _scene;

        Invoke("ChangeScene", audioSource.clip.length / 2);

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