using DG.Tweening;
using UnityEngine;

public class Translate : MonoBehaviour {

    public ClipType clipToPlay;
    public bool translateFromPosition;
    public Vector3 position;
    public float fadeInTime = 1f;
    public float delay = 1f;
    public float fadeInScale = 1f;

    private GameManager gameManager;
    private RectTransform rt;

    void Awake() {

        gameManager = FindObjectOfType<GameManager> ();
        rt = GetComponent<RectTransform> ();

    }

    // Use this for initialization
    void Start() {

        gameManager.soundManager.Play(clipToPlay);
        
        fadeInTime = gameManager.soundManager.GetLength(clipToPlay);

        // Fade the object in by scaling from 0 to the desired scale value
        this.transform.DOScale(0, 0);
        this.transform.DOScale(fadeInScale, fadeInTime);
        this.transform.DOScale(1, 1).SetDelay(fadeInTime + delay);

        if (translateFromPosition) {

            if (rt == null) {
                this.transform.DOMove(position, 1).SetDelay(fadeInTime + delay).From();
            } else {
                rt.DOAnchorPos(position, 1).SetDelay(fadeInTime + delay).From();
            }

        } else {

            if (rt == null) {
                this.transform.DOMove(position, 1).SetDelay(fadeInTime + delay);
            } else {
                rt.DOAnchorPos(position, 1).SetDelay(fadeInTime + delay);
            }

        }

    }

}