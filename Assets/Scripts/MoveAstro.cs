using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAstro : MonoBehaviour {

    public Rigidbody2D rb;
    public AudioSource audio;
    public int version;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (version == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audio.Play();
                rb.AddForce(10 * transform.up);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audio.Play();
                rb.AddForce(-10 * transform.right);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audio.Play();
                rb.AddForce(-10 * transform.up);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                audio.Play();
                rb.AddForce(10 * transform.right);
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                audio.Play();
                rb.AddTorque(-0.5f);
                rb.AddForce(1 * transform.up);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                audio.Play();
                rb.AddTorque(0.5f);
                rb.AddForce(-1 * transform.right);
                //rb.AddForce(new Vector2(50, 100));
                //transform.Rotate(0, 0, 1.0f);

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                audio.Play();
                rb.AddTorque(0.5f);
                rb.AddForce(-1 * transform.up);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                audio.Play();
                rb.AddTorque(-0.5f);
                rb.AddForce(1 * transform.right);
                //transform.Rotate(0, 0, -1.0f);
            }
        }

    }
}