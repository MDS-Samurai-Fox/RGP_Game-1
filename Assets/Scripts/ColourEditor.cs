using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourEditor : MonoBehaviour {

    float fRed;
    float fGreen;
    float fBlue;

	// Use this for initialization
	void Start () {
        
        fRed = 255.0f;
        fGreen = 255.0f;
        fBlue = 255.0f;
    }
	
	// Update is called once per frame
	void Update () {

       if (Input.GetKey(KeyCode.R)) {
            fRed -= 1.0f;

            if (fRed < 0.0f)
                fRed = 0.0f;
        }

        if (Input.GetKey(KeyCode.I))
        {
            fRed += 1.0f;

            if (fRed > 255.0f)
                fRed = 255.0f;
        }

        if (Input.GetKey(KeyCode.O))
        {
            fGreen += 1.0f;

            if (fGreen < 255.0f)
                fGreen = 255.0f;
        }

        if (Input.GetKey(KeyCode.P))
        {
            fBlue += 1.0f;

            if (fBlue < 255.0f)
                fBlue = 255.0f;
        }

        if (Input.GetKey(KeyCode.G))
        {
            fGreen -= 1.0f;

            if (fGreen < 0.0f)
                fGreen = 0.0f;
        }

        if (Input.GetKey(KeyCode.B))
        {
            fBlue -= 1.0f;

            if (fBlue < 0.0f)
                fBlue = 0.0f;
        }

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(fRed / 255.0f, fGreen / 255.0f, fBlue / 255.0f, 1.0f);
    }
}
