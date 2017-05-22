using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wheel : MonoBehaviour {

    public enum type { Skin, Hair, Eyes, Lips, Other };
    public type spriteType;
    public GameObject objectToChange;
    private GameManager gameManager;
    private Vector3 rotationVector;
    //private ColourEditor colourEditor;
    private float timer = 0.0f;

    private ColourEditor EyeColour;
    private ColourEditor EyebrowColour;
    private ColourEditor NoseColour;
    private ColourEditor MouthColour;
    private ColourEditor RightEarColour;
    private ColourEditor LeftEarColour;
    private ColourEditor HairColour;
    private ColourEditor MustacheColour;
    private ColourEditor BeardColour;
    private ColourEditor FaceColour;

    void Start() {
        rotationVector = new Vector3(0.0f, 0.0f, 4.0f);
    }
 
    void Awake () {
        gameManager = FindObjectOfType<GameManager>();
        //colourEditor = objectToChange.GetComponent<ColourEditor>();

        EyeColour = objectToChange.transform.Find("Face Parts").transform.Find("Eyes").gameObject.GetComponent<ColourEditor>();
        EyebrowColour = objectToChange.transform.Find("Face Parts").transform.Find("Eyebrows").gameObject.GetComponent<ColourEditor>();
        NoseColour = objectToChange.transform.Find("Face Parts").transform.Find("Nose").gameObject.GetComponent<ColourEditor>();
        MouthColour = objectToChange.transform.Find("Face Parts").transform.Find("Mouth").gameObject.GetComponent<ColourEditor>();
        RightEarColour = objectToChange.transform.Find("Face Parts").transform.Find("Right Ear").gameObject.GetComponent<ColourEditor>();
        LeftEarColour = objectToChange.transform.Find("Face Parts").transform.Find("Left Ear").gameObject.GetComponent<ColourEditor>();
        HairColour = objectToChange.transform.Find("Face Parts").transform.Find("Hair").gameObject.GetComponent<ColourEditor>();
        MustacheColour = objectToChange.transform.Find("Face Parts").transform.Find("Mustache").gameObject.GetComponent<ColourEditor>();
        BeardColour = objectToChange.transform.Find("Face Parts").transform.Find("Beard").gameObject.GetComponent<ColourEditor>();
        FaceColour = objectToChange.transform.Find("Face Parts").gameObject.GetComponent<ColourEditor>();

    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (!gameManager.canUpdate)
            return;

        //if (!colourEditor)
        //{
        //    Debug.LogError("No Colour Editor on " + objectToChange + "!");
        //    return;
        //}

        if (!FaceColour | !NoseColour | !RightEarColour | !LeftEarColour | !HairColour | !MustacheColour | !BeardColour | !EyebrowColour | !EyeColour | !MouthColour)
        {
            Debug.LogError("No Colour Editor on " + objectToChange + "!");
            return;
        }

        if (timer > 1.0f)
        {
            if (spriteType == type.Skin)
            {
                FaceColour.ChangeColor();
                NoseColour.ChangeColor();
                RightEarColour.ChangeColor();
                LeftEarColour.ChangeColor();
            }
            else if (spriteType == type.Hair)
            {
                HairColour.ChangeColor();
                MustacheColour.ChangeColor();
                BeardColour.ChangeColor();
                EyebrowColour.ChangeColor();
            }
           else if (spriteType == type.Eyes)
            {
                EyeColour.ChangeColor();
            }
            else if (spriteType == type.Lips)
            {
                MouthColour.ChangeColor();
            }
            //colourEditor.ChangeColor();
            timer = 0.0f;
        }

        Vector3 newRotation = transform.rotation.eulerAngles + rotationVector;
        transform.DORotate(newRotation, 0.1f);

        if (gameManager.faceCheckerNew.HasMatchedFace() == true)
        {
            gameManager.timeManager.StopTimer();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<CameraEffectController>().Shake(0.2f, 0.7f);
    }
}
