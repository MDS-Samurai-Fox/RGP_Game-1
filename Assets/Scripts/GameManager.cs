using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : AdManager
{

    public bool bNewGameManager;

    // Classes
    [HideInInspector]
    public TimeManager timeManager;
    [HideInInspector]
    public SoundManager soundManager;
    [HideInInspector]
    public FaceChecker faceChecker;
    public FaceCheckerNew faceCheckerNew;
    private Buoyancy buoyancy;
    // private MoveAstro moveAstronaut;

    [HideInInspector]
    public bool canUpdate = false;

    [HeaderAttribute ("Intro Animation")]
    [SerializeField]
    private Ease easeType = Ease.InSine;
    private float easeLength = 0;

    [SpaceAttribute]
    public Transform faceParent;
    public Transform leftSide;
    public Transform middleSide;
    public Transform rightSide;
    public ParticleSystem particles;
    public Transform faceToMatch;
    public CanvasGroup gameEndPanel;

    [SpaceAttribute]
    public Vector3 leftSideSplitPosition;
    public Vector3 middleSideSplitPosition;
    public Vector3 rightSideSplitPosition;

    private Vector3 leftSideOriginalPosition;
    private Vector3 middleSideOriginalPosition;
    private Vector3 rightSideOriginalPosition;

    // Obsolete
    private bool areSidesJoined = true;
    private bool hasGameEnded = false;

    [SerializeField] public static int m_GameplayCount = 0;

    void Awake ()
    {

        timeManager = GetComponent<TimeManager> ();
        soundManager = FindObjectOfType<SoundManager> ();
        buoyancy = FindObjectOfType<Buoyancy> ();
        faceChecker = GetComponent<FaceChecker> ();
        faceCheckerNew = GetComponent<FaceCheckerNew> ();
        m_GameplayCount = 0;
        hasGameEnded = false;

    }

    // Use this for initialization
    void Start ()
    {
        ShowAd ("rewardedVideo");
        easeLength = soundManager.GetLength (ClipType.Join);

        gameEndPanel.DOFade (0, 0);
        gameEndPanel.blocksRaycasts = false;

        if (particles != null)
            particles.Stop ();

        faceToMatch.DOScale (1, easeLength);
        faceToMatch.DOScale (0.25f, 1).SetDelay (easeLength + 2);
        faceToMatch.DOMove (Vector3.zero, 1).SetDelay (easeLength + 2).From ().OnComplete (Initialize);

    }

    void Initialize ()
    {

        easeLength = soundManager.GetLength (ClipType.Join);

        leftSideOriginalPosition = leftSide.localPosition;
        middleSideOriginalPosition = middleSide.localPosition;
        rightSideOriginalPosition = rightSide.localPosition;

        // Move the face parent to the desired vector, after that enable the buoyancy
        faceParent.DOMove (new Vector3 (0, -0.35f, 0), easeLength).SetDelay (0.2f).SetEase (Ease.OutBack).OnComplete (StartGame);

        FaceSplit ();
        //soundManager.Play(ClipType.Split);

    }

    void StartGame ()
    {
        timeManager.Initialize ();
        canUpdate = true;

        PlayAnimationBlastEnd ();

        if (buoyancy != null)
            buoyancy.Float ();

    }

    public void StopGame ()
    {

        canUpdate = false;
        FaceJoin ();
        soundManager.StopMusicSource ();
        soundManager.StopJetpackSource ();

        ShowAd ("rewardedVideo");

    }

    public void ToggleJoin ()
    {

        if (areSidesJoined)
        {

            FaceSplit ();

        }
        else
        {

            FaceJoin ();

        }

        areSidesJoined = !areSidesJoined;

    }

    void FaceJoin ()
    {

        easeLength = soundManager.GetLength (ClipType.Join);
        soundManager.Play (ClipType.Finish);
        PlayAnimationBlastStart ();

        if (!bNewGameManager)
        {
            leftSide.DOLocalMove (leftSideOriginalPosition, easeLength).SetEase (easeType);
            middleSide.DOLocalMove (middleSideOriginalPosition, easeLength).SetEase (easeType);
            rightSide.DOLocalMove (rightSideOriginalPosition, easeLength).SetEase (easeType).OnComplete (PlayAnimationBlastEnd);
        }

    }

    void FaceSplit ()
    {

        easeLength = soundManager.GetLength (ClipType.Split);
        soundManager.Play (ClipType.Split);
        PlayAnimationBlastStart ();

        if (!bNewGameManager)
        {
            leftSide.DOLocalMove (leftSideSplitPosition, easeLength).SetEase (easeType);
            middleSide.DOLocalMove (middleSideSplitPosition, easeLength).SetEase (easeType);
            rightSide.DOLocalMove (rightSideSplitPosition, easeLength).SetEase (easeType).OnComplete (PlayAnimationBlastEnd);
        }

    }

    void PlayAnimationBlastStart ()
    {
        soundManager.Play (ClipType.BlastStart);
    }

    void PlayAnimationBlastEnd ()
    {
        soundManager.Play (ClipType.BlastEnd);
    }

    void Win ()
    {

        gameEndPanel.GetComponentInChildren<TextMeshProUGUI> ().text = "YOU WON";
        gameEndPanel.DOFade (1, 1).OnComplete (EnableBlockRaycasts);

    }

    void Lose ()
    {

        gameEndPanel.GetComponentInChildren<TextMeshProUGUI> ().text = "YOU LOST";
        gameEndPanel.DOFade (1, 1).OnComplete (EnableBlockRaycasts);

    }

    void EnableBlockRaycasts ()
    {
        gameEndPanel.blocksRaycasts = true;
        hasGameEnded = true;
    }

    private void Update ()
    {
        if (!canUpdate)
        {
            if (!hasGameEnded)
            {
                return;
            }
            if (Input.GetButtonDown ("Fire1"))
            {
                SceneManager.LoadScene (0);
            }
        }

        //if (bNewGameManager)
        //{
        //    if (faceCheckerNew.HasMatchedFace() == true)
        //    {
        //        timeManager.StopTimer();
        //    }
        //}
        //else
        //{
        //    if (faceChecker.HasMatchedFace() == true)
        //    {
        //        timeManager.StopTimer();
        //    }
        //}

    }

    // ADS
    protected override void OnAdFinished ()
    {
        EndGame ();
    }

    protected override void OnAdSkipped ()
    {
        EndGame ();
    }

    protected override void OnAdFailed ()
    {
        EndGame ();
    }

    void EndGame ()
    {
        if (bNewGameManager)
        {
            if (faceCheckerNew.HasMatchedFace () == true)
            {
                Invoke ("Win", soundManager.GetLength (ClipType.Finish));
            }
            else
            {
                Invoke ("Lose", soundManager.GetLength (ClipType.Finish));
            }
        }
        else
        {
            if (faceChecker.HasMatchedFace () == true)
            {
                Invoke ("Win", soundManager.GetLength (ClipType.Finish));
            }
            else
            {
                Invoke ("Lose", soundManager.GetLength (ClipType.Finish));
            }
        }
    }

}