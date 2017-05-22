using UnityEngine;

public class FaceCheckerNew : MonoBehaviour {

    public bool randomizeFace = false;

    [HeaderAttribute("Eyes")]
    public Sprite[] Eyes;

    [HeaderAttribute("Eyebrows")]
    public Sprite[] Eyebrows;

    [HeaderAttribute("Face")]
    public Sprite[] Face;

    [HeaderAttribute("Hair")]
    public Sprite[] Hair;

    [HeaderAttribute("Nose")]
    public Sprite[] nose;

    [HeaderAttribute("Mouth")]
    public Sprite[] mouth;

    [HeaderAttribute("LeftEar")]
    public Sprite[] LeftEar;

    [HeaderAttribute("RightEar")]
    public Sprite[] RightEar;

    [HeaderAttribute("Mustache")]
    public Sprite[] Mustache;

    [HeaderAttribute("Beard")]
    public Sprite[] Beard;

    private Sprite chosenEyes, chosenEyebrows, chosenFace, chosenHair, chosenNose, chosenMouth, chosenLeftEar, chosenRightEar, chosenMustache, chosenBeard;

    private GameManager gameManager;

    private Color[] skinColor = new Color[5];
    private Color[] eyeColor = new Color[5];
    private Color[] lipColor = new Color[5];
    private Color[] hairColor = new Color[5];

    void Awake()
    {

        gameManager = GetComponent<GameManager>();

    }

    // Use this for initialization
    void Start () {

        //skinColor[0] = new Color(60.0f / 255.0f, 46.0f / 255.0f, 40.0f / 255.0f);


        //Color skincolor1 = new Color(60.0f / 255.0f, 46.0f / 255.0f, 40.0f / 255.0f);
        //Color skincolor2 = new Color(105.0f / 255.0f, 80.0f / 255.0f, 70.0f / 255.0f);
        //Color skincolor3 = new Color(165.0f / 255.0f, 126.0f / 255.0f, 110.0f / 255.0f);
        //Color skincolor4 = new Color(240.0f / 255.0f, 184.0f / 255.0f, 160.0f / 255.0f);
        //Color skincolor5 = new Color(255.0f / 255.0f, 229.0f / 255.0f, 200.0f / 255.0f);

        //Color haircolor1 = new Color(9.0f / 255.0f, 8.0f / 255.0f, 6.0f / 255.0f);
        //Color haircolor2 = new Color(83.0f / 255.0f, 61.0f / 255.0f, 53.0f / 255.0f);
        //Color haircolor3 = new Color(233.0f / 255.0f, 206.0f / 255.0f, 168.0f / 255.0f);
        //Color haircolor4 = new Color(183.0f / 255.0f, 166.0f / 255.0f, 158.0f / 255.0f);
        //Color haircolor5 = new Color(141.0f / 255.0f, 74.0f / 255.0f, 67.0f / 255.0f);

        //Color eyecolor1 = new Color(25.0f / 255.0f, 23.0f / 255.0f, 188.0f / 255.0f);
        //Color eyecolor2 = new Color(69.0f / 255.0f, 24.0f / 255.0f, 0.0f / 255.0f);
        //Color eyecolor3 = new Color(119.0f / 255.0f, 101.0f / 255.0f, 54.0f / 255.0f);
        //Color eyecolor4 = new Color(48.0f / 255.0f, 88.0f / 255.0f, 6.0f / 255.0f);
        //Color eyecolor5 = new Color(61.0f / 255.0f, 69.0f / 255.0f, 80.0f / 255.0f);

        //Color lipcolor1 = new Color(222.0f / 255.0f, 15.0f / 255.0f, 13.0f / 255.0f);
        //Color lipcolor2 = new Color(186.0f / 255.0f, 6.0f / 255.0f, 78.0f / 255.0f);
        //Color lipcolor3 = new Color(227.0f / 255.0f, 93.0f / 255.0f, 106.0f / 255.0f);
        //Color lipcolor4 = new Color(153.0f / 255.0f, 88.0f / 255.0f, 106.0f / 255.0f);
        //Color lipcolor5 = new Color(238.0f / 255.0f, 193.0f / 255.0f, 173.0f / 255.0f);

        if (randomizeFace)
        {

            chosenEyes = Eyes[Random.Range(0, Eyes.Length)];
            chosenEyebrows = Eyebrows[Random.Range(0, Eyebrows.Length)];
            chosenNose = nose[Random.Range(0, nose.Length)];
            chosenMouth = mouth[Random.Range(0, mouth.Length)];
            chosenFace = Face[Random.Range(0, Face.Length)];
            chosenHair = Hair[Random.Range(0, Hair.Length)];
            int iEarIndex = Random.Range(0, RightEar.Length);
            chosenRightEar = RightEar[iEarIndex];
            chosenLeftEar = LeftEar[iEarIndex];
            chosenMustache = Mustache[Random.Range(0, Mustache.Length)];
            chosenBeard = Beard[Random.Range(0, Beard.Length)];

        }
        else
        {
            chosenEyes = Eyes[1];
            chosenEyebrows = Eyebrows[1];
            chosenNose = nose[1];
            chosenMouth = mouth[1];
            chosenFace = Face[1];
            chosenHair = Hair[1];
            chosenRightEar = RightEar[1];
            chosenLeftEar = LeftEar[1];
            chosenMustache = Mustache[1];
            chosenBeard = Beard[1];

        }

        Initialize();

    }

    /// <summary>
    /// Changes the face's sprites to the chosen ones
    /// </summary>
    void Initialize()
    {
        Transform t = gameManager.faceToMatch;
        Transform d = gameManager.faceToMatch.GetChild(0);
        SpriteRenderer u = gameManager.faceToMatch.GetChild(0).GetComponent<SpriteRenderer>();
        gameManager.faceToMatch.GetChild(0).GetComponent<SpriteRenderer>().sprite = chosenFace;
        gameManager.faceToMatch.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = chosenEyes;
        gameManager.faceToMatch.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = chosenEyebrows;
        gameManager.faceToMatch.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().sprite = chosenRightEar;
        gameManager.faceToMatch.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().sprite = chosenLeftEar;
        gameManager.faceToMatch.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().sprite = chosenNose;
        gameManager.faceToMatch.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().sprite = chosenMouth;
        gameManager.faceToMatch.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().sprite = chosenHair;
        gameManager.faceToMatch.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().sprite = chosenMustache;
        gameManager.faceToMatch.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().sprite = chosenBeard;

    }

    /// <summary>
    /// Checks the sprites of each face element to determine whether or not they match the final face
    /// </summary>
    /// <returns>true if face to check equals face to match</returns>
    public bool HasMatchedFace()
    {

        return (
            gameManager.faceParent.GetChild(0).GetComponent<SpriteRenderer>().sprite == chosenFace &&
            gameManager.faceParent.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite == chosenEyes &&
            gameManager.faceParent.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite == chosenEyebrows &&
            gameManager.faceParent.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().sprite == chosenRightEar &&
            gameManager.faceParent.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().sprite == chosenLeftEar &&
            gameManager.faceParent.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().sprite == chosenNose &&
            gameManager.faceParent.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().sprite == chosenMouth &&
            gameManager.faceParent.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().sprite == chosenHair &&
            gameManager.faceParent.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().sprite == chosenMustache &&
            gameManager.faceParent.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().sprite == chosenBeard
        );

    }
}


//{



//        if (spriteType == type.Skin)    {

//            colorArray[0] = skincolor1;
//            colorArray[1] = skincolor2;
//            colorArray[2] = skincolor3;
//            colorArray[3] = skincolor4;
//            colorArray[4] = skincolor5;

//        }
//        else if (spriteType == type.Hair)   {

//            colorArray[0] = haircolor1;
//            colorArray[1] = haircolor2;
//            colorArray[2] = haircolor3;
//            colorArray[3] = haircolor4;
//            colorArray[4] = haircolor5;

//        }
//        else if (spriteType == type.Eyes)   {

//            colorArray[0] = eyecolor1;
//            colorArray[1] = eyecolor2;
//            colorArray[2] = eyecolor3;
//            colorArray[3] = eyecolor4;
//            colorArray[4] = eyecolor5;

//        }
//        else if (spriteType == type.Lips)   {

//            colorArray[0] = lipcolor1;
//            colorArray[1] = lipcolor2;
//            colorArray[2] = lipcolor3;
//            colorArray[3] = lipcolor4;
//            colorArray[4] = lipcolor5;

//        }
//}