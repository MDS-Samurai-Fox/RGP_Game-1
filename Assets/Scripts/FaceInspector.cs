using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FaceDebugging))]
public class FaceInspector : Editor {

    private FaceDebugging faceDebugging;
    private BodyPart LeftEye;
    private BodyPart LeftEyebrow;
    private BodyPart Nose;
    private BodyPart Mouth;
    private BodyPart RightEye;
    private BodyPart RightEyebrow;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    override public void OnInspectorGUI()
    {
        FaceDebugging faceDebugging = (FaceDebugging)target;

        if (GUILayout.Button("Left Eye"))
        {
            LeftEye = faceDebugging.LeftEye;
            LeftEye.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Left Eyebrow"))
        {
            LeftEyebrow = faceDebugging.LeftEyebrow;
            LeftEyebrow.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Right Eye"))
        {
            RightEye = faceDebugging.RightEye;
            RightEye.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Nose"))
        {
            Nose = faceDebugging.Nose;
            Nose.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Mouth"))
        {
            Mouth = faceDebugging.Mouth;
            Mouth.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Right Eye"))
        {
            RightEye = faceDebugging.RightEye;
            RightEye.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Right Eyebrow"))
        {
            RightEyebrow = faceDebugging.RightEyebrow;
            RightEyebrow.ChangeSpriteDebug();
        }

        DrawDefaultInspector();
    }
}
