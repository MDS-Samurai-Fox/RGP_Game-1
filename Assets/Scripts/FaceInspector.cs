using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FaceDebugging))]
public class FaceInspector : Editor
{

    private FaceDebugging faceDebugging;
    //private BodyPart LeftEye;
    //private BodyPart LeftEyebrow;
    private BodyPart Nose;
    private BodyPart Mouth;
    //private BodyPart RightEye;
    //private BodyPart RightEyebrow;

    private BodyPart Eyes;
    private BodyPart Eyebrows;
    private BodyPart Hair;
    private BodyPart RightEar;
    private BodyPart LeftEar;
    private BodyPart Mustache;
    private BodyPart Beard;
    private BodyPart Face;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void OnInspectorGUI()
    {
        //FaceDebugging faceDebugging = (FaceDebugging)target;
        faceDebugging = (FaceDebugging)target;

        //if (GUILayout.Button("Left Eye"))
        //{
        //    LeftEye = faceDebugging.LeftEye;
        //    LeftEye.ChangeSpriteDebug();
        //}
        //if (GUILayout.Button("Left Eyebrow"))
        //{
        //    LeftEyebrow = faceDebugging.LeftEyebrow;
        //    LeftEyebrow.ChangeSpriteDebug();
        //}
        //if (GUILayout.Button("Right Eye"))
        //{
        //    RightEye = faceDebugging.RightEye;
        //    RightEye.ChangeSpriteDebug();
        //}
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
        //if (GUILayout.Button("Right Eye"))
        //{
        //    RightEye = faceDebugging.RightEye;
        //    RightEye.ChangeSpriteDebug();
        //}
        //if (GUILayout.Button("Right Eyebrow"))
        //{
        //    RightEyebrow = faceDebugging.RightEyebrow;
        //    RightEyebrow.ChangeSpriteDebug();
        //}


        if (GUILayout.Button("Eyes"))
        {
            Eyes = faceDebugging.Eyes;
            Eyes.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Eyebrows"))
        {
            Eyebrows = faceDebugging.Eyebrows;
            Eyebrows.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Right Ear"))
        {
            RightEar = faceDebugging.RightEar;
            RightEar.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Left Ear"))
        {
            LeftEar = faceDebugging.LeftEar;
            LeftEar.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Hair"))
        {
            Hair = faceDebugging.Hair;
            Hair.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Face"))
        {
            Face = faceDebugging.Face;
            Face.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Mustache"))
        {
            Mustache = faceDebugging.Mustache;
            Mustache.ChangeSpriteDebug();
        }
        if (GUILayout.Button("Beard"))
        {
            Beard = faceDebugging.Beard;
            Beard.ChangeSpriteDebug();
        }

        DrawDefaultInspector();
    }
}
