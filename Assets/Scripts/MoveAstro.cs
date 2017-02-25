﻿using UnityEngine;

public class MoveAstro : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameManager gameManager;
    public int version;

    void Awake() {

        rigidBody = GetComponent<Rigidbody2D> ();
        gameManager = FindObjectOfType<GameManager> ();

    }

    void Update() {

        if (!gameManager.canUpdate)
            return;

        if (version == 1) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                rigidBody.AddForce(10 * transform.up);
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                rigidBody.AddForce(-10 * transform.right);
            }

            if (Input.GetKey(KeyCode.DownArrow)) {
                rigidBody.AddForce(-10 * transform.up);
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                rigidBody.AddForce(10 * transform.right);
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
                //rb.AddForce(new Vector2(50, 100));
                //transform.Rotate(0, 0, 1.0f);

            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                
                rigidBody.AddTorque(0.5f);
                rigidBody.AddForce(-1 * transform.up);
                
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                
                rigidBody.AddTorque(-0.5f);
                rigidBody.AddForce(1 * transform.right);
                //transform.Rotate(0, 0, -1.0f);
                
            }

        }

    }

}