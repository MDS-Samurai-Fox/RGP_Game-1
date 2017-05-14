using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wheel : MonoBehaviour {

    public GameObject objectToChange;
    private GameManager gameManager;
    private Vector3 rotationVector;
    private ColourEditor colourEditor;
    private float timer = 0.0f;

    void Start() {
        rotationVector = new Vector3(0.0f, 0.0f, 4.0f);
    }
 
    void Awake () {
        gameManager = FindObjectOfType<GameManager>();
        colourEditor = objectToChange.GetComponent<ColourEditor>();
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (!gameManager.canUpdate)
            return;

        if (!colourEditor)
        {
            Debug.LogError("No Colour Editor on " + objectToChange + "!");
            return;
        }

        if (timer > 1.0f)
        {
            colourEditor.ChangeColor();
            timer = 0.0f;
        }

        Vector3 newRotation = transform.rotation.eulerAngles + rotationVector;
        transform.DORotate(newRotation, 0.1f);

        if (gameManager.faceChecker.HasMatchedFace() == true)
        {
            gameManager.timeManager.StopTimer();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<CameraEffectController>().Shake(0.2f, 0.7f);
    }
}
