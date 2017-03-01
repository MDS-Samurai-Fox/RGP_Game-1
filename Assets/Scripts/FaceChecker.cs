using UnityEngine;

public class FaceChecker : MonoBehaviour {

    public bool randomizeFace = false;

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

        if (randomizeFace) {

            chosenLeftEye = leftEye[Random.Range(0, leftEye.Length)];
            chosenLeftEyebrow = leftEyebrow[Random.Range(0, leftEyebrow.Length)];

            chosenNose = nose[Random.Range(0, nose.Length)];

            chosenMouth = mouth[Random.Range(0, mouth.Length)];

            chosenRightEye = rightEye[Random.Range(0, rightEye.Length)];
            chosenRightEyebrow = rightEyebrow[Random.Range(0, rightEyebrow.Length)];

        } else {

            chosenLeftEye = leftEye[1];
            chosenLeftEyebrow = leftEyebrow[1];
            chosenNose = nose[1];
            chosenMouth = mouth[0];
            chosenRightEye = rightEye[0];
            chosenRightEyebrow = rightEyebrow[1];

        }

        Initialize();

    }

    /// <summary>
    /// Changes the face's sprites to the chosen ones
    /// </summary>
    void Initialize() {

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

    /// <summary>
    /// Checks the sprites of each face element to determine whether or not they match the final face
    /// </summary>
    /// <returns>true if face to check equals face to match</returns>
    public bool HasMatchedFace() {

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

}