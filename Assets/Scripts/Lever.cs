using UnityEngine;

public class Lever : MonoBehaviour {
    
    public ButtonType buttonType;

    public BodyPart[] bodypart;
    //public BodyPart bodypart;
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

        if (time > 1.35f) {

            switch (buttonType) {
                
                case ButtonType.Lever:
                    gameManager.soundManager.Play(ClipType.Lever);
                break;
                case ButtonType.Button:
                    gameManager.soundManager.Play(ClipType.Button);
                break;
                
            }

            for (int i = 0; i < bodypart.Length; i++)
            {
                bodypart[i].ChangeSprite();
            }
            
            if (animator)
                animator.SetTrigger("Lever_On");

            time = 0f;

            if (gameManager.bNewGameManager)
            {
                if (gameManager.faceCheckerNew.HasMatchedFace() == true)
                {
                    gameManager.timeManager.StopTimer();
                }
            }
            else
            {
                // Do something with the facechecker script
                if (gameManager.faceChecker.HasMatchedFace() == true)
                {
                    gameManager.timeManager.StopTimer();
                }
            }


            FindObjectOfType<CameraEffectController>().Shake(0.2f, 0.7f);

        }

    }

}