using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAstro : MonoBehaviour {

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public GameManager gameManager;
    public int version;

    // Use this for initialization
    void Awake() {

        rb = GetComponent<Rigidbody2D> ();
        audioSource = GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update() {

        if (!gameManager.canUpdate)
            return;
            
        print(">");

        if (version == 1) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                audioSource.Play();
                rb.AddForce(10 * transform.up);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                audioSource.Play();
                rb.AddForce(-10 * transform.right);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                audioSource.Play();
                rb.AddForce(-10 * transform.up);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                audioSource.Play();
                rb.AddForce(10 * transform.right);
            }
        } else {
            
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
                // audio.Play();
                rb.AddTorque(-0.5f);
                rb.AddForce(1 * transform.up);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
                // audio.Play();
                rb.AddTorque(0.5f);
                rb.AddForce(-1 * transform.right);
                //rb.AddForce(new Vector2(50, 100));
                //transform.Rotate(0, 0, 1.0f);

            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                // audio.Play();
                rb.AddTorque(0.5f);
                rb.AddForce(-1 * transform.up);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                // audio.Play();
                rb.AddTorque(-0.5f);
                rb.AddForce(1 * transform.right);
                //transform.Rotate(0, 0, -1.0f);
            }
            
        }

    }
    
}