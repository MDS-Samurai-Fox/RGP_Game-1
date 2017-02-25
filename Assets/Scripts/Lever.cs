using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public BodyPart bodypart;
    private Animator animator;
    private float time;

    // Use this for initialization
    void Start ()
    {
        animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;     
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (time > 0.6f)
        {
            bodypart.ChangeSprite();
            animator.SetTrigger("Lever_On");
            time = 0f;
        }
        
    }
}
