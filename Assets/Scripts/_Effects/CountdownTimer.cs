using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    private SoundManager soundManager;
    private FaceSideSplitter faceSideSplitter;

    public Text timerText;

    public float time;

    private bool shouldUpdateTime = false;

    void Awake() {

        soundManager = GameObject.FindObjectOfType<SoundManager> ();
        faceSideSplitter = GameObject.FindObjectOfType<FaceSideSplitter> ();

    }

    void Start() {

        Invoke("Initialize", soundManager.GetLength(ClipType.Split));

    }

    // Update is called once per frame
    void Update() {

        if (shouldUpdateTime) {

            time -= Time.deltaTime;
            timerToText();

            if ((int) time <= 0 && shouldUpdateTime) {

                timerText.text = "0:00";

                soundManager.StopMusicSource();

                faceSideSplitter.DisableBuoyancy();
                faceSideSplitter.ToggleJoin();

                shouldUpdateTime = false;

            }

        }

    }

    void timerToText() {

        timerText.text = string.Format("{0:#0}:{1:00}", Mathf.Floor(time / 60), Mathf.Floor(time) % 60);
        
    }

    void Initialize() {

        shouldUpdateTime = true;
        StartCoroutine(tickingSound());

    }

    IEnumerator tickingSound() {

        while (shouldUpdateTime) {

            soundManager.Play(ClipType.Timer);
            yield return new WaitForSeconds(1.0f);

        }

    }

}