using UnityEngine;

public class Lever : MonoBehaviour {

    public BodyPart bodypart;
    private Animator animator;
    private GameManager gameManager;
    private float time;

    void Awake() {

        animator = GetComponent<Animator> ();
        gameManager = FindObjectOfType<GameManager> ();

    }

    void Update() {

        time += Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (time > 0.6f) {

            // Play either a lever or button sound depending on the value
            if (Random.Range(1, 0) == 1) {

                gameManager.soundManager.Play(ClipType.Lever);

            } else {

                gameManager.soundManager.Play(ClipType.Button);

            }

            bodypart.ChangeSprite();
            animator.SetTrigger("Lever_On");
            time = 0f;

        }

    }

}