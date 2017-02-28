﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    // public CanvasGroup menuPanel;
    // public CanvasGroup creditsPanel;

    private AudioSource audioSource;

    private static int sceneToChange;

    void Awake() {

        audioSource = GetComponent<AudioSource> ();

    }

    void Start() {

        if (SceneManager.GetActiveScene().name == "Menu") {
            CanvasGroup creditsPanel = GameObject.Find("Credits Panel").GetComponent<CanvasGroup> ();
            creditsPanel.alpha = 0;
            creditsPanel.blocksRaycasts = false;
        }

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

    public void SetPanel(CanvasGroup _panel) {

        EventSystem.current.SetSelectedGameObject(null);

        audioSource.PlayOneShot(audioSource.clip);

        _panel.DOFade(1, 0.35f);
        _panel.blocksRaycasts = true;

        foreach(CanvasGroup cg in GameObject.FindObjectsOfType<CanvasGroup> ()) {

            if (cg != _panel) {

                cg.alpha = 0;
                cg.blocksRaycasts = true;

            }

        }

        // if (_panel == menuPanel) {
        //     creditsPanel.alpha = 0;
        //     creditsPanel.blocksRaycasts = false;
        // } else {
        //     menuPanel.alpha = 0;
        //     menuPanel.blocksRaycasts = false;
        // }

    }

}