using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wheel : MonoBehaviour {

    private GameManager gameManager;
    Vector3 rotationVector;

    void Start() {
        rotationVector = new Vector3(0.0f, 0.0f, 4.0f);
    }
 
    void Awake () {
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        if (!gameManager.canUpdate)
            return;

        Vector3 newRotation = transform.rotation.eulerAngles + rotationVector;

        transform.DORotate(newRotation, 0.1f);

        if (gameManager.faceChecker.HasMatchedFace() == true)
        {
            gameManager.timeManager.StopTimer();
        }
    }
}
