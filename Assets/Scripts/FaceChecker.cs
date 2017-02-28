using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChecker : MonoBehaviour {

    [HeaderAttribute("Right Eye")]
    public Sprite[] rightEye;

    [HeaderAttribute("Right Eyebrow")]
    public Sprite[] rightEyebrow;

    [HeaderAttribute("Left Eye")]
    public Sprite[] leftEye;

    [HeaderAttribute("Left Eyebrow")]
    public Sprite[] leftEyebrow;

    [HeaderAttribute("Nose")]
    public Sprite[] nose;

    [HeaderAttribute("Mouth")]
    public Sprite[] mouth;

    private Sprite chosenRightEye, chosenRightEyebrow, chosenLeftEye, chosenLeftEyebrow, chosenNose, chosenMouth;

    private GameManager gameManager;

    void Awake() {

        gameManager = GetComponent<GameManager> ();

    }

    // Use this for initialization
    void Start() {
		
		// RANDOM
		// private int[] indexes = { 0, 1 };

        // int choices = indexes.Length;

        // chosenRightEye = rightEye[Random.Range(0, choices)];
        // chosenRightEyebrow = rightEyebrow[Random.Range(0, choices)];

        // chosenLeftEye = leftEye[Random.Range(0, choices)];
        // chosenLeftEyebrow = leftEyebrow[Random.Range(0, choices)];

        // chosenNose = nose[Random.Range(0, choices)];

        // chosenMouth = mouth[Random.Range(0, choices)];

        chosenLeftEye = leftEye[1];
        chosenLeftEyebrow = leftEyebrow[1];
        chosenNose = nose[1];
        chosenMouth = mouth[0];
        chosenRightEye = rightEye[0];
        chosenRightEyebrow = rightEyebrow[1];

        ChangeFace();

    }

    public bool CheckFace() {
        
        print("Checking face");
        print(">>> SPRITES");
        print("Left Eye: " + (gameManager.faceParent.GetChild(0).GetChild(0).GetComponent<SpriteRenderer> ().sprite == chosenLeftEye));
        print("Left Eyebrow: " + (gameManager.faceParent.GetChild(0).GetChild(1).GetComponent<SpriteRenderer> ().sprite == chosenLeftEyebrow));
        print("Nose: " + (gameManager.faceParent.GetChild(1).GetChild(0).GetComponent<SpriteRenderer> ().sprite == chosenNose));
        print("Mouth: " + (gameManager.faceParent.GetChild(1).GetChild(1).GetComponent<SpriteRenderer> ().sprite == chosenMouth));
        print("Right Eye: " + (gameManager.faceParent.GetChild(2).GetChild(0).GetComponent<SpriteRenderer> ().sprite == chosenRightEye));
        print("Right Eyebrow: " + (gameManager.faceParent.GetChild(2).GetChild(1).GetComponent<SpriteRenderer> ().sprite == chosenRightEyebrow));

        return (
            // Left side
            gameManager.faceParent.GetChild(0).GetChild(0).GetComponent<SpriteRenderer> ().sprite == chosenLeftEye &&
            gameManager.faceParent.GetChild(0).GetChild(1).GetComponent<SpriteRenderer> ().sprite == chosenLeftEyebrow &&

            // Nose
            gameManager.faceParent.GetChild(1).GetChild(0).GetComponent<SpriteRenderer> ().sprite == chosenNose &&

            // Mouth
            gameManager.faceParent.GetChild(1).GetChild(1).GetComponent<SpriteRenderer> ().sprite == chosenMouth &&

            // Right side
            gameManager.faceParent.GetChild(2).GetChild(0).GetComponent<SpriteRenderer> ().sprite == chosenRightEye &&
            gameManager.faceParent.GetChild(2).GetChild(1).GetComponent<SpriteRenderer> ().sprite == chosenRightEyebrow
        );

    }

    void ChangeFace() {

        // Left side
        gameManager.faceToMatch.GetChild(0).GetChild(0).GetComponent<SpriteRenderer> ().sprite = chosenLeftEye;
        gameManager.faceToMatch.GetChild(0).GetChild(1).GetComponent<SpriteRenderer> ().sprite = chosenLeftEyebrow;

        // Nose
        gameManager.faceToMatch.GetChild(1).GetChild(0).GetComponent<SpriteRenderer> ().sprite = chosenNose;

        // Mouth
        gameManager.faceToMatch.GetChild(1).GetChild(1).GetComponent<SpriteRenderer> ().sprite = chosenMouth;

        // Right side
        gameManager.faceToMatch.GetChild(2).GetChild(0).GetComponent<SpriteRenderer> ().sprite = chosenRightEye;
        gameManager.faceToMatch.GetChild(2).GetChild(1).GetComponent<SpriteRenderer> ().sprite = chosenRightEyebrow;

    }

}