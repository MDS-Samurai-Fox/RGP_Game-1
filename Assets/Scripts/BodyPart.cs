using DG.Tweening;
using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {

    public Sprite[] Sprites;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;
    private int spriteArraySize = 0;

    private Material originalMaterial;

    private GameManager gameManager;

    void Awake() {

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start() {

        Debug.Log(originalMaterial);

        spriteArraySize = Sprites.Length;

        spriteRenderer.sprite = Sprites[spriteIndex];

    }

    /// <summary>
    /// 
    /// </summary>
    public void ChangeSprite() {

        StartCoroutine(AnimateSpriteChange(0.05f));
        StartCoroutine(Utils.Pause(0.05f));

        spriteIndex++;

        if (spriteIndex > spriteArraySize - 1) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = Sprites[spriteIndex];

        this.transform.DOShakeScale(0.4f);
        // this.transform.DOScale(1.2f, 0.4f);
        // this.transform.DOScale(1, 0.4f).SetDelay(0.4f);

        if (gameManager.bNewGameManager)
        {
            ParticleSystem smokeParticles;
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            if (!smokeParticles.isPlaying)
            {
                smokeParticles.Play();
            }
        }
        
    }

    public void ChangeScale(float fScale)
    {
        this.transform.DOScale(fScale, 0.4f).SetEase(Ease.InSine);
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

    private IEnumerator AnimateSpriteChange(float length) {

        spriteRenderer.material = Resources.Load("Material_White") as Material;

        yield return new WaitForSeconds(length);

        spriteRenderer.material = originalMaterial;

    }

}