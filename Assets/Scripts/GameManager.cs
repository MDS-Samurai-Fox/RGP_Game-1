using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    // Classes
    private TimeManager timeManager;
    private SoundManager soundManager;
    private Buoyancy buoyancy;
    private MoveAstro moveAstronaut;
    
    [HideInInspector]
    public bool canUpdate = false;

    [HeaderAttribute("Intro Animation")]
    [SerializeField]
    private Ease easeType = Ease.InSine;
    private float easeLength = 0;

    [SpaceAttribute]
    public Transform faceParent;
    public Transform leftSide;
    public Transform middleSide;
    public Transform rightSide;
    public ParticleSystem particles;

    [SpaceAttribute]
    public Vector3 leftSideSplitPosition;
    public Vector3 middleSideSplitPosition;
    public Vector3 rightSideSplitPosition;

    private Vector3 leftSideOriginalPosition;
    private Vector3 middleSideOriginalPosition;
    private Vector3 rightSideOriginalPosition;

    // Obsolete
    private bool areSidesJoined = true;

    void Awake() {

        timeManager = GetComponent<TimeManager>();
        soundManager = GameObject.FindObjectOfType<SoundManager> ();
        buoyancy = GameObject.FindObjectOfType<Buoyancy> ();
        moveAstronaut = GameObject.FindObjectOfType<MoveAstro> ();

    }

    // Use this for initialization
    void Start() {

        particles.Stop();

        easeLength = soundManager.GetLength(ClipType.Join);

        leftSideOriginalPosition = leftSide.localPosition;
        middleSideOriginalPosition = middleSide.localPosition;
        rightSideOriginalPosition = rightSide.localPosition;

        // Move the face parent to the desired vector, after that enable the buoyancy
        faceParent.DOMove(new Vector3(0, -0.35f, 0), easeLength).SetEase(Ease.OutBack).OnComplete(StartGame);

        FaceSplit();

    }

    void StartGame() {

        timeManager.Initialize();
        canUpdate = true;
        buoyancy.Float();

    }

    public void StopGame() {

        canUpdate = false;
        FaceJoin();

    }

    public void ToggleJoin() {

        if (areSidesJoined) {

            FaceSplit();

        } else {

            FaceJoin();

        }

        areSidesJoined = !areSidesJoined;

    }

    void FaceJoin() {

        easeLength = soundManager.GetLength(ClipType.Join);
        soundManager.Play(ClipType.Finish);
        PlayAnimationBlastStart();

        leftSide.DOLocalMove(leftSideOriginalPosition, easeLength).SetEase(easeType);
        middleSide.DOLocalMove(middleSideOriginalPosition, easeLength).SetEase(easeType);
        rightSide.DOLocalMove(rightSideOriginalPosition, easeLength).SetEase(easeType).OnComplete(PlayAnimationBlastEnd);

    }

    void FaceSplit() {

        easeLength = soundManager.GetLength(ClipType.Split);
        soundManager.Play(ClipType.Split);
        PlayAnimationBlastStart();

        leftSide.DOLocalMove(leftSideSplitPosition, easeLength).SetEase(easeType);
        middleSide.DOLocalMove(middleSideSplitPosition, easeLength).SetEase(easeType);
        rightSide.DOLocalMove(rightSideSplitPosition, easeLength).SetEase(easeType).OnComplete(PlayAnimationBlastEnd);

    }

    void PlayAnimationBlastStart() {
        soundManager.Play(ClipType.BlastStart);
    }

    void PlayAnimationBlastEnd() {
        soundManager.Play(ClipType.BlastEnd);
    }

}