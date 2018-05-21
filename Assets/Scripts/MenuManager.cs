using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// using XboxCtrlrInput;

public class MenuManager : MonoBehaviour
{
    private AudioSource audioSource;

    private static int sceneToChange;

    private int menuSelection = -1;

    public bool canUpdate = true;

    public float maxScrollResetTimer = 0.3f;
    private bool canScroll;
    private float scrollResetTimer = 0;

    // [System.Serializable]
    [SerializeField] private List<Image> Buttons = new List<Image> ();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake ()
    {
        if (null == audioSource)
        {
            audioSource = GetComponent<AudioSource> ();
        }
    }

    /// <summary>
    /// Loads the scene in an ordered manner
    /// </summary>
    /// <param name="_scene">The number of the scene in the hierarchy</param>
    public void LoadScene (int _scene)
    {
        sceneToChange = _scene;

        if (audioSource != null)
        {
            audioSource.PlayOneShot (audioSource.clip);
            Invoke ("ChangeScene", audioSource.clip.length / 2);
        }
        else
        {
            Invoke ("ChangeScene", 0);
        }

    }

    void ChangeScene ()
    {
        SceneManager.LoadScene (sceneToChange);
    }

    public void Exit ()
    {
        audioSource.PlayOneShot (audioSource.clip);

        Invoke ("Quit", audioSource.clip.length - 0.2f);
    }

    void Quit ()
    {
        Application.Quit ();
    }

    public void SetPanel (CanvasGroup _panel)
    {
        EventSystem.current.SetSelectedGameObject (null);

        audioSource.PlayOneShot (audioSource.clip);

        _panel.DOFade (1, 0.35f);
        _panel.blocksRaycasts = true;

        foreach (CanvasGroup cg in GameObject.FindObjectsOfType<CanvasGroup> ())
        {
            if (cg != _panel)
            {
                cg.alpha = 0;
                cg.blocksRaycasts = true;
            }

        }

    }

    private void Update ()
    {
        if (canUpdate)
        {
#if UNITY_PS4 || UNITY_PSP2
            if (Input.GetButtonDown ("Fire1"))
            {
                LoadScene (1);
            }
#elif UNITY_ANDROID || UNITY_IOS
            if (Input.GetMouseButtonDown(1))
            {
                LoadScene(1);
            }
#else
            if (Input.GetButtonDown ("Fire1"))
            {
                switch (menuSelection)
                {
                    case 0:
                        LoadScene (1);
                        break;
                    case 1:
                        Exit ();
                        break;
                }
            }

            if (((XCI.GetAxisRaw (XboxAxis.LeftStickY) > 0) || (XCI.GetDPadDown (XboxDPad.Up))) && canScroll)
            {
                canScroll = false;
                menuSelection--;

                if (menuSelection < 0)
                {
                    menuSelection = Buttons.Count - 1;
                }

                print ("Selection: " + menuSelection);
            }
            if (((XCI.GetAxisRaw (XboxAxis.LeftStickY) < 0) || (XCI.GetDPadDown (XboxDPad.Down))) && canScroll)
            {
                canScroll = false;
                menuSelection++;

                if (menuSelection > Buttons.Count - 1)
                {
                    menuSelection = 0;
                }

                print ("Selection: " + menuSelection);
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

        for (int i = 0; i < Buttons.Count; i++)
        {
            if (menuSelection == -1)
            {
                Buttons[i].color = Color.white;
            }
            else
            {
                if (i == menuSelection)
                {
                    Buttons[i].color = Color.white;
                }
                else
                {
                    Buttons[i].color = Color.grey;
                }
            }
#endif
        }

    }

}