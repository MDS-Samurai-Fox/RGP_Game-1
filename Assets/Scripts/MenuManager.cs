﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

public class MenuManager : MonoBehaviour {

    // public CanvasGroup menuPanel;
    // public CanvasGroup creditsPanel;

    private AudioSource audioSource;

    private static int sceneToChange;

    private int menuSelection = -1;

    public bool canUpdate = true;

    public float maxScrollResetTimer = 0.3f;
    private bool canScroll;
    private float scrollResetTimer = 0;

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

    private void Update()
    {
        if (canUpdate)
        {
            CanvasGroup creditsPanel = GameObject.Find("Credits Panel").GetComponent<CanvasGroup>();
            CanvasGroup menuPanel = GameObject.Find("Menu Panel").GetComponent<CanvasGroup>();
            
            menuPanel.GetComponentsInChildren<Image>()[0].color = Color.grey;
            menuPanel.GetComponentsInChildren<Image>()[1].color = Color.grey;
            menuPanel.GetComponentsInChildren<Image>()[2].color = Color.grey;

            if (menuSelection == -1)
            {
                menuPanel.GetComponentsInChildren<Image>()[0].color = Color.white;
                menuPanel.GetComponentsInChildren<Image>()[1].color = Color.white;
                menuPanel.GetComponentsInChildren<Image>()[2].color = Color.white;
            }
            if (menuSelection == 0)
            {
                menuPanel.GetComponentsInChildren<Image>()[menuSelection].color = Color.white;

            }
            else if (menuSelection == 1)
            {
                menuPanel.GetComponentsInChildren<Image>()[menuSelection].color = Color.white;

            }
            else if (menuSelection == 2)
            {
                menuPanel.GetComponentsInChildren<Image>()[menuSelection].color = Color.white;
            }
            else if (menuSelection == 3)
            {

            }

            if (XCI.GetButtonDown(XboxButton.A))
            {

                if (menuSelection == 0)
                {
                    LoadScene(1);

                }
                else if (menuSelection == 1)
                {
                    menuSelection = 3;
                    SetPanel(creditsPanel);

                }
                else if (menuSelection == 2)
                {
                    Exit();
                }
                else if (menuSelection == 3)
                {
                    SetPanel(menuPanel);
                    menuSelection = 0;
                }
            }

            if (XCI.GetAxisRaw(XboxAxis.LeftStickY) > 0 && canScroll)
            {

                canScroll = false;
                menuSelection--;

                if (menuSelection < 0)
                {
                    menuSelection = 2;
                }

                //print("Selection: " + menuSelection);

            }
            else if (XCI.GetAxisRaw(XboxAxis.LeftStickY) < 0 && canScroll)
            {

                canScroll = false;
                menuSelection++;

                if (menuSelection > 2)
                {
                    menuSelection = 0;
                }

                print("Selection: " + menuSelection);

            }

        }

        if (!canScroll)
        {

            scrollResetTimer += Time.deltaTime;

            if (scrollResetTimer >= maxScrollResetTimer)
            {
                canScroll = true;
                scrollResetTimer = 0;
            }

        }

    }

}