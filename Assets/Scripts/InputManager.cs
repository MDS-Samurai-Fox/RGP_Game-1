using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private SoundManager sm;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        sm = GameObject.FindObjectOfType<SoundManager> ();
    }
    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Jump")) {
            sm.Play(ClipType.Jetpack);
        } else if (Input.GetButtonUp("Jump")) {
            sm.StopJetpackSource();
        }

    }

}