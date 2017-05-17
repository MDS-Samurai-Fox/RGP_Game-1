using UnityEngine;
using XboxCtrlrInput;
using DG.Tweening;

public class MoveAstro : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameManager gameManager;
    private Animator animator;
    private float time;
    private bool bCollision = false;
    public GameObject particleEffect;

    private bool canPlaySound = true;
    private float jetpackSoundTimer = 0;

    private ParticleSystem movementParticles;

    void Awake() {

        rigidBody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        movementParticles = GetComponentInChildren<ParticleSystem>();

    }

    void FixedUpdate() {

        if (!gameManager.canUpdate)
            return;

        if (!canPlaySound) {
            jetpackSoundTimer += Time.deltaTime;
        }

        if (jetpackSoundTimer > 1f) {
            // StopJetpack();
            //print(">> CAN PLAY SOUND");
            canPlaySound = true;
            jetpackSoundTimer = 0;
        }

        int StartingForce = 4;

        if (canPlaySound) {

            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") || XCI.GetAxisRaw(XboxAxis.LeftStickX) != 0 || XCI.GetAxisRaw(XboxAxis.LeftStickY) != 0) {

                gameManager.soundManager.Play(ClipType.Jetpack);
                canPlaySound = false;

            }
            else if (Input.GetButtonUp("Horizontal") || XCI.GetAxisRaw(XboxAxis.LeftStickX) == 0) {

                gameManager.soundManager.StopJetpackSource();

            }
            // else if (!Input.GetButton("Horizontal")) {
            //     // Invoke("StopJetpack", 0.5f);
            //     // gameManager.soundManager.StopJetpackSource();
            // }

        }
        else {

            //print("<< CAN'T PLAY SOUND");
            // gameManager.soundManager.StopJetpackSource();

        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || XCI.GetAxisRaw(XboxAxis.LeftStickY) > 0) {
            rigidBody.AddForce(StartingForce * new Vector3(0, 1, 0));
            //movementParticles.Play();
            //Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 180));
            if (!movementParticles.isPlaying) {
                movementParticles.Play();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || XCI.GetAxisRaw(XboxAxis.LeftStickX) < 0) {
            rigidBody.AddForce(-StartingForce * new Vector3(1, 0, 0));
            //Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
            if (!movementParticles.isPlaying) {
                movementParticles.Play();
            }

            if (!bCollision) {
                animator.Play("newThrustLeft");

                if (transform.eulerAngles.z < 91.0f && transform.rotation.z > -91.0f) {
                }
                else {
                    // animator.Play("thrustLeft");
                }
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || XCI.GetAxisRaw(XboxAxis.LeftStickX) > 0)
        {
            //print("LeftStickX > 0, Down");
            rigidBody.AddForce(StartingForce * new Vector3(1, 0, 0));
            //Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
            if (!movementParticles.isPlaying)
            {
                movementParticles.Play();
            }

            if (!bCollision)
            {
                animator.Play("newThrustRight");

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
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || XCI.GetAxisRaw(XboxAxis.LeftStickY) < 0) {

            rigidBody.AddForce(-StartingForce * new Vector3(0, 1, 0));
            //Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            if (!movementParticles.isPlaying) {
                movementParticles.Play();
            }
        }
        


        // Handing the idle animations
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || XCI.GetButtonUp(XboxButton.X)) {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("newThrustLeft") || animator.GetCurrentAnimatorStateInfo(0).IsName("collideLeft")) {
                animator.Play("newIdleLeft");
            }
            else {
                animator.Play("newIdleRight");
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || XCI.GetButtonUp(XboxButton.B)) {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("newThrustLeft") || animator.GetCurrentAnimatorStateInfo(0).IsName("collideLeft")) {
                animator.Play("newIdleLeft");
            }
            else {
                animator.Play("newIdleRight");
            }
        }
    }


    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.transform.parent.name == "Borders") {
            bCollision = true;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("newIdleLeft")) {
                //animator.Play("collideLeft");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("newThrustLeft")) {
                //animator.Play("collideLeft");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("newIdleRight")) {
                //animator.Play("collideRight");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("newThrustRight")) {
               //animator.Play("collideRight");
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