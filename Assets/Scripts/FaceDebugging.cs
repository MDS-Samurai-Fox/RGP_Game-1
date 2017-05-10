using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDebugging : MonoBehaviour {

    [HideInInspector]
    public BodyPart LeftEye;
    [HideInInspector]
    public BodyPart LeftEyebrow;
    [HideInInspector]
    public BodyPart Nose;
    [HideInInspector]
    public BodyPart Mouth;
    [HideInInspector]
    public BodyPart RightEye;
    [HideInInspector]
    public BodyPart RightEyebrow;

    //public int LeftEyeIndex;
    //public int LeftEyebrowIndex;
    //public int NoseIndex;
    //public int MouthIndex;
    //public int RightEyeIndex;
    //public int RightEyebrowIndex;


    // Use this for initialization
    void Start () {

        LeftEye = transform.Find("Left Face Side").transform.Find("Left Eye").gameObject.GetComponent<BodyPart>();
        LeftEyebrow = transform.Find("Left Face Side").transform.Find("Left Eyebrow").gameObject.GetComponent<BodyPart>();
        Nose = transform.Find("Middle Face Side").transform.Find("Nose").gameObject.GetComponent<BodyPart>();
        Mouth = transform.Find("Middle Face Side").transform.Find("Mouth").gameObject.GetComponent<BodyPart>();
        RightEye = transform.Find("Right Face Side").transform.Find("Right Eye").gameObject.GetComponent<BodyPart>();
        RightEyebrow = transform.Find("Right Face Side").transform.Find("Right Eyebrow").gameObject.GetComponent<BodyPart>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
