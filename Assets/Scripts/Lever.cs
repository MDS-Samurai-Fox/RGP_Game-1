using UnityEngine;

public class Lever : MonoBehaviour {
    
    public ButtonType buttonType;

    public BodyPart bodypart;
    private Animator animator;
    private GameManager gameManager;
    private float time;

    void Awake() {

        animator = GetComponent<Animator> ();
        gameManager = FindObjectOfType<GameManager> ();

    }

    void Update() {

        if (!gameManager.canUpdate)
            return;
            
        time += Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collider) {
        
        if (!gameManager.canUpdate)
            return;

        if (time > 0.6f) {

            switch (buttonType) {
                
                case ButtonType.Lever:
                    gameManager.soundManager.Play(ClipType.Lever);
                break;
                case ButtonType.Button:
                    gameManager.soundManager.Play(ClipType.Button);
                break;
                
            }

            bodypart.ChangeSprite();
            animator.SetTrigger("Lever_On");
            time = 0f;
            
            // Do something with the facechecker script
            if (gameManager.faceChecker.CheckFace() == true) {
                gameManager.StopGame();
            }

        }

    }

}