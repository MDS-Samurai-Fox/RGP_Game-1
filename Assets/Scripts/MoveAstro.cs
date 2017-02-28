using UnityEngine;

public class MoveAstro : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameManager gameManager;
    private Animator animator;
    private float time;
    public int version;

    void Awake() {

        rigidBody = GetComponent<Rigidbody2D> ();
        gameManager = FindObjectOfType<GameManager> ();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {

        if (!gameManager.canUpdate)
            return;

        if (version == 1) {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                //rigidBody.AddForce(10 * transform.up);
                rigidBody.AddForce(5 * new Vector3(0, 1, 0));
                //animator.Play("thrustLeft");
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //rigidBody.AddForce(-10 * transform.right);
                rigidBody.AddForce(-5 * new Vector3(1, 0, 0));
                animator.Play("thrustLeft");
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
               //rigidBody.AddForce(-10 * transform.up);
                rigidBody.AddForce(-5 * new Vector3(0, 1, 0));
               
                //if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleLeft"))
                //{
                //    animator.Play("thrustLeft");
                //}
                //else if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleRight"))
                //{
                //    animator.Play("thrustRight");
                //}
                //else
                //{
                //    animator.Play("thrustLeft");
                //}
                    
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //rigidBody.AddForce(10 * transform.right);
                rigidBody.AddForce(5 * new Vector3(1, 0, 0));
                animator.Play("thrustRight");
            }


            //if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            //{
            //    animator.Play("idleLeft");
            //}
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                animator.Play("idleLeft");
            }
            //if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            //{
            //    animator.Play("idleLeft");
            //}
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                animator.Play("idleRight");
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

    void Update()
    {

        time += Time.deltaTime;

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //if (time > 0.6f)
        //  {
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



        //    time = 0f;
        // }

    }

}

