using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    private GameManager gameManager;

    public Text timerText;

    public float time;

    private bool shouldUpdateTime = false;

    void Awake() {

        gameManager = FindObjectOfType<GameManager> ();

    }

    void Update() {

        if (!shouldUpdateTime)
            return;

        time -= Time.deltaTime;
        timerToText();

        if ((int) time <= 0) {

            timerText.text = "0:00";

            shouldUpdateTime = false;

            gameManager.soundManager.StopMusicSource();
            gameManager.soundManager.StopJetpackSource();

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

    /// <summary>
    /// Plays the ticking sound every second
    /// </summary>
    IEnumerator tickingSound() {

        while (shouldUpdateTime) {

            gameManager.soundManager.Play(ClipType.Timer);
            
            if ((int)time < 10) {
                yield return new WaitForSeconds(0.75f);
            }
            else {
                yield return new WaitForSeconds(1.0f);
            }

        }

    }

}