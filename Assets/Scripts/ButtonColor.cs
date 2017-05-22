using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColor : MonoBehaviour {

    public Color color1;
    public Color color2;
    private SpriteRenderer spriteRenderer;
    private float timer = 0.0f;

    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color1;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer > 1.0f)
        {
            if (spriteRenderer.color == color1)
                spriteRenderer.color = color2;
            else
                spriteRenderer.color = color1;
            timer = 0.0f;

            print("Color change" + this);
        }     
    }
}
