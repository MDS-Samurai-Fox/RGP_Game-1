using DG.Tweening;
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

    /// <summary>
    /// 
    /// </summary>
    public void ChangeSprite() {

        spriteIndex++;

        if (spriteIndex > spriteArraySize - 1) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = Sprites[spriteIndex];
        
        this.transform.DOShakeScale(0.4f);
        // this.transform.DOScale(1.2f, 0.4f);
        // this.transform.DOScale(1, 0.4f).SetDelay(0.4f);

    }

    public void ChangeSpriteDebug()
    {

        spriteIndex++;

        if (spriteIndex > spriteArraySize - 1)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = Sprites[spriteIndex];

       // this.transform.DOShakeScale(0.4f);
        // this.transform.DOScale(1.2f, 0.4f);
        // this.transform.DOScale(1, 0.4f).SetDelay(0.4f);

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="_sprite">The image that will replace the current sprite</param>
    public void ChangeSprite(Sprite _sprite) {
        
        spriteRenderer.sprite = _sprite;
        
    }

}