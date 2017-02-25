using UnityEngine;

public class BodyPart : MonoBehaviour {

    public Sprite[] Sprites;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;
    private int spriteArraySize = 0;

    void Awake() {

        spriteRenderer = GetComponent<SpriteRenderer> ();

    }

    // Use this for initialization
    void Start() {

        spriteArraySize = Sprites.Length;

        spriteRenderer.sprite = Sprites[spriteIndex];

    }

    public void ChangeSprite() {

        spriteIndex++;

        if (spriteIndex > spriteArraySize - 1) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = Sprites[spriteIndex];

    }

}