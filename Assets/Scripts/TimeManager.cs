using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour {

    private GameManager gameManager;

    //public Text timerText;
    public TextMeshProUGUI countdownText;

    public float currentTime;

    private bool shouldUpdateTime = false;

    void Awake() {

        gameManager = FindObjectOfType<GameManager> ();

    }
    
    void Start() {
        
        timerToText();
        
    }

    void Update() {

        if (!shouldUpdateTime)
            return;

        currentTime -= Time.deltaTime;
        timerToText();

        if ((int) currentTime <= 0) {
            
            StopTimer();

        }

    }

    public void Initialize() {

        shouldUpdateTime = true;
        StartCoroutine(tickingSound());

    }

    public void StopTimer() {

        shouldUpdateTime = false;
        gameManager.StopGame();

    }

    void timerToText() {

            countdownText.text = string.Format("{0:#0}:{1:00}", Mathf.Floor(currentTime / 60), Mathf.Floor(currentTime) % 60);

    }

    /// <summary>
    /// Plays the ticking sound every second
    /// </summary>
    IEnumerator tickingSound() {

        while (shouldUpdateTime) {

            gameManager.soundManager.Play(ClipType.Timer);

            if ((int) currentTime < 10) {
                yield return new WaitForSeconds(0.75f);
            } else {
                yield return new WaitForSeconds(1.0f);
            }

        }

    }

}