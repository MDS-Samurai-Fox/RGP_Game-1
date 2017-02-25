using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {

    public Sprite[] Sprites;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;
    private int spriteArraySize = 0;
   
	// Use this for initialization
	void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteArraySize = Sprites.Length;

        spriteRenderer.sprite = Sprites[spriteIndex];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSprite ()
    {
        spriteIndex++;

        if (spriteIndex > spriteArraySize - 1)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = Sprites[spriteIndex];
    }
}
