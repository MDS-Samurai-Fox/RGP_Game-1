using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    private SoundManager soundManager;
    private GameManager gameManager;

    public Text timerText;

    public float time;

    private bool shouldUpdateTime = false;

    void Awake() {

        soundManager = GameObject.FindObjectOfType<SoundManager> ();
        gameManager = GameObject.FindObjectOfType<GameManager> ();

    }

    void Start() {

        // Invoke("Initialize", soundManager.GetLength(ClipType.Split));

    }

    // Update is called once per frame
    void Update() {

        if (!shouldUpdateTime)
            return;

        time -= Time.deltaTime;
        timerToText();

        if ((int) time <= 0) {

            timerText.text = "0:00";

            shouldUpdateTime = false;

            soundManager.StopMusicSource();

            gameManager.StopGame();

        }

    }

    public void Initialize() {

        shouldUpdateTime = true;
        StartCoroutine(tickingSound());

    }

    void timerToText() {

        timerText.text = string.Format("{0:#0}:{1:00}", Mathf.Floor(time / 60), Mathf.Floor(time) % 60);

    }

    IEnumerator tickingSound() {

        while (shouldUpdateTime) {

            soundManager.Play(ClipType.Timer);
            yield return new WaitForSeconds(1.0f);

        }

    }

}