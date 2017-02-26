using UnityEngine;

public class MoveAstro : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameManager gameManager;
    public int version;

    void Awake() {

        rigidBody = GetComponent<Rigidbody2D> ();
        gameManager = FindObjectOfType<GameManager> ();

    }

    void FixedUpdate() {

        if (!gameManager.canUpdate)
            return;

        if (version == 1) {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                //rigidBody.AddForce(10 * transform.up);
                rigidBody.AddForce(10 * new Vector3(0, 1, 0));
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //rigidBody.AddForce(-10 * transform.right);
                rigidBody.AddForce(-10 * new Vector3(1, 0, 0));
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
               //rigidBody.AddForce(-10 * transform.up);
                rigidBody.AddForce(-10 * new Vector3(0, 1, 0));
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //rigidBody.AddForce(10 * transform.right);
                rigidBody.AddForce(10 * new Vector3(1, 0, 0));
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

}