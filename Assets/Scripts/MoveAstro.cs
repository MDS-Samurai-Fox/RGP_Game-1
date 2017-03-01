using UnityEngine;

public class MoveAstro : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameManager gameManager;
    private Animator animator;
    private float time;
    private bool bCollision = false;
    public GameObject particleEffect;

    private bool canPlaySound = true;
    private float jetpackSoundTimer = 0;

    void Awake() {

        rigidBody = GetComponent<Rigidbody2D> ();
        gameManager = FindObjectOfType<GameManager> ();
        animator = GetComponent<Animator> ();
    }

    void FixedUpdate()
    {

        if (!gameManager.canUpdate)
            return;

        if (!canPlaySound)
        {
            jetpackSoundTimer += Time.deltaTime;
        }

        if (jetpackSoundTimer > 1f)
        {
            // StopJetpack();
            print(">> CAN PLAY SOUND");
            canPlaySound = true;
            jetpackSoundTimer = 0;
        }

        int StartingForce = 4;

        if (canPlaySound)
        {

            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            {

                gameManager.soundManager.Play(ClipType.Jetpack);
                canPlaySound = false;

            }
            else if (Input.GetButtonUp("Horizontal"))
            {

                gameManager.soundManager.StopJetpackSource();

            }
            // else if (!Input.GetButton("Horizontal")) {
            //     // Invoke("StopJetpack", 0.5f);
            //     // gameManager.soundManager.StopJetpackSource();
            // }

        }
        else
        {

            print("<< CAN'T PLAY SOUND");
            // gameManager.soundManager.StopJetpackSource();

        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(StartingForce * new Vector3(0, 1, 0));
            Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 180));
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(-StartingForce * new Vector3(1, 0, 0));
            Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, -90));

            if (!bCollision)
            {
                animator.Play("thrustLeft");

                if (transform.eulerAngles.z < 91.0f && transform.rotation.z > -91.0f) { }
                else
                {
                    // animator.Play("thrustLeft");
                }
            }

        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            rigidBody.AddForce(-StartingForce * new Vector3(0, 1, 0));
            Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            rigidBody.AddForce(StartingForce * new Vector3(1, 0, 0));
            Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 90));

            if (!bCollision)
            {
                animator.Play("thrustRight");

                if (transform.eulerAngles.z < 89.0f && transform.rotation.z > -89.0f)
                {
                    // animator.Play("thrustRight");
                }
                else
                {
                    // animator.Play("thrustLeft");
                }
            }
        }


        // Handing the idle animations
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("thrustLeft") || animator.GetCurrentAnimatorStateInfo(0).IsName("collideLeft"))
            {
                animator.Play("idleLeft");
            }
            else
            {
                animator.Play("idleRight");
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("thrustLeft") || animator.GetCurrentAnimatorStateInfo(0).IsName("collideLeft"))
            {
                animator.Play("idleLeft");
            }
            else
            {
                animator.Play("idleRight");
            }
        }
    }
        

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.transform.parent.name == "Borders") {
            bCollision = true;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleLeft")) {
                animator.Play("collideLeft");
            } else if (animator.GetCurrentAnimatorStateInfo(0).IsName("thrustLeft")) {
                animator.Play("collideLeft");
            } else if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleRight")) {
                animator.Play("collideRight");
            } else if (animator.GetCurrentAnimatorStateInfo(0).IsName("thrustRight")) {
                animator.Play("collideRight");
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        bCollision = false;

    }
    
    void StopJetpack() {
        
        gameManager.soundManager.StopJetpackSource();
        
    }

}