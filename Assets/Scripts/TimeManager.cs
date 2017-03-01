using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    private GameManager gameManager;

    public Text timerText;

    public float currentTime;
    
    [HideInInspector]
    public float originalTime, remainingTime;

    private bool shouldUpdateTime = false;

    void Awake() {

        gameManager = FindObjectOfType<GameManager> ();

    }
    
    void Start() {
        
        originalTime = currentTime;
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
        remainingTime = (originalTime - currentTime);
        gameManager.StopGame();

    }

    void timerToText() {

        timerText.text = string.Format("{0:#0}:{1:00}", Mathf.Floor(currentTime / 60), Mathf.Floor(currentTime) % 60);

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