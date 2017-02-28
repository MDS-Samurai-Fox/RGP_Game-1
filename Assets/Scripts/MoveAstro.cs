using UnityEngine;

public class MoveAstro : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameManager gameManager;
    private Animator animator;
    private float time;
    private bool bCollision = false;
    public int version;

    void Awake() {

        rigidBody = GetComponent<Rigidbody2D> ();
        gameManager = FindObjectOfType<GameManager> ();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {

        if (!gameManager.canUpdate)
            return;

        int StartingForce = 4;

        if (version == 1) {
            
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                //rigidBody.AddForce(10 * transform.up);
                rigidBody.AddForce(StartingForce * new Vector3(0, 1, 0));
                //animator.Play("thrustLeft");
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //rigidBody.AddForce(-10 * transform.right);
                rigidBody.AddForce(-StartingForce * new Vector3(1, 0, 0));
                if (!bCollision)
                {
                        animator.Play("thrustLeft");
                    //if (transform.rotation.z <  91.0f * Mathf.PI / 180.0f && transform.rotation.z > -91.0f * Mathf.PI / 180.0f)
                    if (transform.eulerAngles.z < 91.0f && transform.rotation.z > -91.0f )
                    {
                    }
                    else
                    {
                        // animator.Play("thrustLeft");
                    }
                }
               
            }

            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
               //rigidBody.AddForce(-10 * transform.up);
                rigidBody.AddForce(-StartingForce * new Vector3(0, 1, 0));
                    
            }

            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //rigidBody.AddForce(10 * transform.right);
                rigidBody.AddForce(StartingForce * new Vector3(1, 0, 0));
                if (!bCollision)
                {
                    animator.Play("thrustRight");
                    //if(transform.rotation.z < 45.0f * Mathf.PI/180.0f && transform.rotation.z > -45.0f * Mathf.PI / 180.0f)
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
        // Version 2
        else {

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
                
                rigidBody.AddTorque(-0.5f);
                rigidBody.AddForce(1 * transform.up);
                
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
                
                rigidBody.AddTorque(0.5f);
                rigidBody.AddForce(-1 * transform.right);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                
                rigidBody.AddTorque(0.5f);
                rigidBody.AddForce(-1 * transform.up);
                
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                
                rigidBody.AddTorque(-0.5f);
                rigidBody.AddForce(1 * transform.right);
                
            }

        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.parent.name == "Borders")
        {
            bCollision = true;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleLeft"))
            {
                animator.Play("collideLeft");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("thrustLeft"))
            {
                animator.Play("collideLeft");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleRight"))
            {
                animator.Play("collideRight");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("thrustRight"))
            {
                animator.Play("collideRight");
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        bCollision = false;

    }

}

