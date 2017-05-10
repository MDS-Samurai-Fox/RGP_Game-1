using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColourEditor : MonoBehaviour {

    public Color[] colorArray = new Color[5];

    public enum type { Skin, Hair, Eyes, Lips, Other };

    public type spriteType;

    int i = 0;


    // Use this for initialization
    void Start () {

        
        Color skincolor1 = new Color(60.0f / 255.0f, 46.0f / 255.0f, 40.0f / 255.0f);
        Color skincolor2 = new Color(105.0f / 255.0f, 80.0f / 255.0f, 70.0f / 255.0f);
        Color skincolor3 = new Color(165.0f / 255.0f, 126.0f / 255.0f, 110.0f / 255.0f);
        Color skincolor4 = new Color(240.0f / 255.0f, 184.0f / 255.0f, 160.0f / 255.0f);
        Color skincolor5 = new Color(255.0f / 255.0f, 229.0f / 255.0f, 200.0f / 255.0f);

        Color haircolor1 = new Color(60.0f / 255.0f, 46.0f / 255.0f, 40.0f / 255.0f);
        Color haircolor2 = new Color(105.0f / 255.0f, 80.0f / 255.0f, 70.0f / 255.0f);
        Color haircolor3 = new Color(165.0f / 255.0f, 126.0f / 255.0f, 110.0f / 255.0f);
        Color haircolor4 = new Color(240.0f / 255.0f, 184.0f / 255.0f, 160.0f / 255.0f);
        Color haircolor5 = new Color(255.0f / 255.0f, 229.0f / 255.0f, 200.0f / 255.0f);

        Color eyecolor1 = new Color(255.0f / 255.0f, 0.0f / 255.0f, 40.0f / 255.0f);
        Color eyecolor2 = new Color(255.0f / 0.0f, 255.0f / 255.0f, 70.0f / 255.0f);
        Color eyecolor3 = new Color(0.0f / 255.0f, 255.0f / 255.0f, 110.0f / 255.0f);
        Color eyecolor4 = new Color(100.0f / 100.0f, 100.0f / 255.0f, 160.0f / 255.0f);
        Color eyecolor5 = new Color(0.0f / 0.0f, 0.0f / 255.0f, 200.0f / 255.0f);

        Color lipcolor1 = new Color(60.0f / 255.0f, 46.0f / 255.0f, 40.0f / 255.0f);
        Color lipcolor2 = new Color(105.0f / 255.0f, 80.0f / 255.0f, 70.0f / 255.0f);
        Color lipcolor3 = new Color(165.0f / 255.0f, 126.0f / 255.0f, 110.0f / 255.0f);
        Color lipcolor4 = new Color(240.0f / 255.0f, 184.0f / 255.0f, 160.0f / 255.0f);
        Color lipcolor5 = new Color(255.0f / 255.0f, 229.0f / 255.0f, 200.0f / 255.0f);

        if (spriteType == type.Skin)    {

            colorArray[0] = skincolor1;
            colorArray[1] = skincolor2;
            colorArray[2] = skincolor3;
            colorArray[3] = skincolor4;
            colorArray[4] = skincolor5;

        }
        else if (spriteType == type.Hair)   {

            colorArray[0] = haircolor1;
            colorArray[1] = haircolor2;
            colorArray[2] = haircolor3;
            colorArray[3] = haircolor4;
            colorArray[4] = haircolor5;

        }
        else if (spriteType == type.Eyes)   {

            colorArray[0] = eyecolor1;
            colorArray[1] = eyecolor2;
            colorArray[2] = eyecolor3;
            colorArray[3] = eyecolor4;
            colorArray[4] = eyecolor5;

        }
        else if (spriteType == type.Lips)   {

            colorArray[0] = lipcolor1;
            colorArray[1] = lipcolor2;
            colorArray[2] = lipcolor3;
            colorArray[3] = lipcolor4;
            colorArray[4] = lipcolor5;

        }

       
    }
	
	// Update is called once per frame
	void Update () {

       if (Input.GetKey(KeyCode.R)) {

            ChangeColor();
        }      

    }

    public void ChangeColor()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //renderer.color = new Color(fRed / 255.0f, fGreen / 255.0f, fBlue / 255.0f, 1.0f);
        renderer.DOColor(colorArray[i], 1.0f).SetEase(Ease.InSine);

        i++;
        if (i > 4)
            i = 0;
    }
}
