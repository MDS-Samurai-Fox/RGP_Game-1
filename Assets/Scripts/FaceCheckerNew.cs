using UnityEngine;
using DG.Tweening;

public class FaceCheckerNew : MonoBehaviour {

    public bool randomizeFace = false;

    [HeaderAttribute("Eyes")]
    public Sprite[] Eyes;

    [HeaderAttribute("Eyeballs")]
    public Sprite[] Eyeballs;

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

    [HeaderAttribute("Teeth")]
    public Sprite[] Teeth;

    private Sprite chosenEyeballs, chosenEyes, chosenEyebrows, chosenFace, chosenHair, chosenNose, chosenMouth, chosenLeftEar, chosenRightEar, chosenMustache, chosenBeard, chosenTeeth;

    private GameManager gameManager;

    private Color[] skinColorArray = new Color[5];
    private Color[] eyeColorArray = new Color[5];
    private Color[] lipColorArray = new Color[5];
    private Color[] hairColorArray = new Color[5];

    private Color chosenSkincolor, chosenEyecolor, chosenLipcolor, chosenHaircolor;

    void Awake()
    {

        gameManager = GetComponent<GameManager>();

    }

    // Use this for initialization
    void Start () {

        skinColorArray[0] = new Color(60.0f / 255.0f, 46.0f / 255.0f, 40.0f / 255.0f);
        skinColorArray[1] = new Color(105.0f / 255.0f, 80.0f / 255.0f, 70.0f / 255.0f);
        skinColorArray[2] = new Color(165.0f / 255.0f, 126.0f / 255.0f, 110.0f / 255.0f);
        skinColorArray[3] = new Color(240.0f / 255.0f, 184.0f / 255.0f, 160.0f / 255.0f);
        skinColorArray[4] = new Color(255.0f / 255.0f, 229.0f / 255.0f, 200.0f / 255.0f);

        hairColorArray[0] = new Color(9.0f / 255.0f, 8.0f / 255.0f, 6.0f / 255.0f);
        hairColorArray[1] = new Color(83.0f / 255.0f, 61.0f / 255.0f, 53.0f / 255.0f);
        hairColorArray[2] = new Color(233.0f / 255.0f, 206.0f / 255.0f, 168.0f / 255.0f);
        hairColorArray[3] = new Color(183.0f / 255.0f, 166.0f / 255.0f, 158.0f / 255.0f);
        hairColorArray[4] = new Color(141.0f / 255.0f, 74.0f / 255.0f, 67.0f / 255.0f);

        eyeColorArray[0] = new Color(25.0f / 255.0f, 23.0f / 255.0f, 188.0f / 255.0f);
        eyeColorArray[1] = new Color(69.0f / 255.0f, 24.0f / 255.0f, 0.0f / 255.0f);
        eyeColorArray[2] = new Color(119.0f / 255.0f, 101.0f / 255.0f, 54.0f / 255.0f);
        eyeColorArray[3] = new Color(48.0f / 255.0f, 88.0f / 255.0f, 6.0f / 255.0f);
        eyeColorArray[4] = new Color(61.0f / 255.0f, 69.0f / 255.0f, 80.0f / 255.0f);

        lipColorArray[0] = new Color(222.0f / 255.0f, 15.0f / 255.0f, 13.0f / 255.0f);
        lipColorArray[1] = new Color(186.0f / 255.0f, 6.0f / 255.0f, 78.0f / 255.0f);
        lipColorArray[2] = new Color(227.0f / 255.0f, 93.0f / 255.0f, 106.0f / 255.0f);
        lipColorArray[3] = new Color(153.0f / 255.0f, 88.0f / 255.0f, 106.0f / 255.0f);
        lipColorArray[4] = new Color(238.0f / 255.0f, 193.0f / 255.0f, 173.0f / 255.0f);

        if (randomizeFace)
        {
            int iEyeIndex = Random.Range(0, Eyes.Length);
            chosenEyes = Eyes[iEyeIndex];
            chosenEyeballs = Eyeballs[iEyeIndex];
            chosenEyebrows = Eyebrows[Random.Range(0, Eyebrows.Length)];
            chosenNose = nose[Random.Range(0, nose.Length)];
            int iMouthIndex = Random.Range(0, mouth.Length);
            chosenMouth = mouth[iMouthIndex];
            chosenTeeth = Teeth[iMouthIndex];
            chosenFace = Face[Random.Range(0, Face.Length)];
            chosenHair = Hair[Random.Range(0, Hair.Length)];
            int iEarIndex = Random.Range(0, RightEar.Length);
            chosenRightEar = RightEar[iEarIndex];
            chosenLeftEar = LeftEar[iEarIndex];
            chosenMustache = Mustache[Random.Range(0, Mustache.Length)];
            chosenBeard = Beard[Random.Range(0, Beard.Length)];

            chosenSkincolor = skinColorArray[Random.Range(0, skinColorArray.Length)];
            chosenEyecolor = eyeColorArray[Random.Range(0, eyeColorArray.Length)];
            chosenHaircolor = hairColorArray[Random.Range(0, hairColorArray.Length)];
            chosenLipcolor = lipColorArray[Random.Range(0, lipColorArray.Length)];

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
            chosenEyeballs = Eyeballs[1];
            chosenTeeth = Teeth[1];

            chosenSkincolor = skinColorArray[0];
            chosenEyecolor = eyeColorArray[0];
            chosenHaircolor = hairColorArray[0];
            chosenLipcolor = lipColorArray[0];

        }

        Initialize();

    }

    /// <summary>
    /// Changes the face's sprites to the chosen ones
    /// </summary>
    void Initialize()
    {
        SpriteRenderer faceRenderer = gameManager.faceToMatch.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer eyeRenderer = gameManager.faceToMatch.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer browRenderer = gameManager.faceToMatch.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        SpriteRenderer rightEarRenderer = gameManager.faceToMatch.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>();
        SpriteRenderer leftEarRenderer = gameManager.faceToMatch.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>();
        SpriteRenderer noseRenderer = gameManager.faceToMatch.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>();
        SpriteRenderer mouthRenderer = gameManager.faceToMatch.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>();
        SpriteRenderer hairRenderer = gameManager.faceToMatch.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>();
        SpriteRenderer mustacheRenderer = gameManager.faceToMatch.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>();
        SpriteRenderer beardRenderer = gameManager.faceToMatch.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>();
        SpriteRenderer eyeballRenderer = gameManager.faceToMatch.GetChild(0).GetChild(9).GetComponent<SpriteRenderer>();
        SpriteRenderer teethRenderer = gameManager.faceToMatch.GetChild(0).GetChild(10).GetComponent<SpriteRenderer>();

        faceRenderer.sprite = chosenFace;
        eyeRenderer.sprite = chosenEyes;
        browRenderer.sprite = chosenEyebrows;
        rightEarRenderer.sprite = chosenRightEar;
        leftEarRenderer.sprite = chosenLeftEar;
        noseRenderer.sprite = chosenNose;
        mouthRenderer.sprite = chosenMouth;
        hairRenderer.sprite = chosenHair;
        mustacheRenderer.sprite = chosenMustache;
        beardRenderer.sprite = chosenBeard;
        eyeballRenderer.sprite = chosenEyeballs;
        teethRenderer.sprite = chosenTeeth;

        faceRenderer.DOColor(chosenSkincolor, 1.0f).SetEase(Ease.InSine);
        rightEarRenderer.DOColor(chosenSkincolor, 1.0f).SetEase(Ease.InSine);
        leftEarRenderer.DOColor(chosenSkincolor, 1.0f).SetEase(Ease.InSine);
        noseRenderer.DOColor(chosenSkincolor, 1.0f).SetEase(Ease.InSine);
        eyeRenderer.DOColor(chosenEyecolor, 1.0f).SetEase(Ease.InSine);
        mouthRenderer.DOColor(chosenLipcolor, 1.0f).SetEase(Ease.InSine);
        browRenderer.DOColor(chosenHaircolor, 1.0f).SetEase(Ease.InSine);
        hairRenderer.DOColor(chosenHaircolor, 1.0f).SetEase(Ease.InSine);
        mustacheRenderer.DOColor(chosenHaircolor, 1.0f).SetEase(Ease.InSine);
        beardRenderer.DOColor(chosenHaircolor, 1.0f).SetEase(Ease.InSine);

        //float fScale = Random.Range(-1, 1);
        //gameManager.faceToMatch.GetChild(0).GetChild(4).transform.DOLocalScale(1.0f, 0.4f).SetEase(Ease.InSine);
    }

    /// <summary>
    /// Checks the sprites of each face element to determine whether or not they match the final face
    /// </summary>
    /// <returns>true if face to check equals face to match</returns>
    public bool HasMatchedFace()
    {

        return (
            //gameManager.faceParent.GetChild(0).GetComponent<SpriteRenderer>().sprite == chosenFace &&
            //gameManager.faceParent.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite == chosenEyes &&
            //gameManager.faceParent.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite == chosenEyebrows &&
            //gameManager.faceParent.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().sprite == chosenRightEar &&
            //gameManager.faceParent.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().sprite == chosenLeftEar &&
            //gameManager.faceParent.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().sprite == chosenNose &&
            //gameManager.faceParent.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().sprite == chosenMouth &&
            //gameManager.faceParent.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().sprite == chosenHair &&
            //gameManager.faceParent.GetChild(0).GetChild(7).GetComponent<SpriteRenderer>().sprite == chosenMustache &&
            gameManager.faceParent.GetChild(0).GetChild(8).GetComponent<SpriteRenderer>().sprite == chosenBeard &&
            gameManager.faceParent.GetChild(0).GetComponent<SpriteRenderer>().color == chosenSkincolor &&
            gameManager.faceParent.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color == chosenEyecolor &&
            gameManager.faceParent.GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().color == chosenLipcolor &&
            gameManager.faceParent.GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().color == chosenHaircolor
            //add this check once scaling is implemented
            //&& gameManager.faceParent.GetChild(0).GetChild(4).transform.localScale == gameManager.faceToMatch.GetChild(0).GetChild(4).transform.localScale
        );

    }
}