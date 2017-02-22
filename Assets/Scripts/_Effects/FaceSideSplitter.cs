using DG.Tweening;
using UnityEngine;

public class FaceSideSplitter : MonoBehaviour {

    [HeaderAttribute("Tweening variables")]
    [SerializeField]
    private Ease easeType = Ease.InOutQuad;
    [SerializeField]
    private float duration = 1f;

    [HeaderAttribute("Sides of the face")]
    public Transform leftSide;
    public Transform middleSide;
    public Transform rightSide;

    [HeaderAttribute("Position Vectors")]
    public Vector3 leftSideSplitPosition;
    public Vector3 middleSideSplitPosition;
    public Vector3 rightSideSplitPosition;

    private Vector3 leftSideOriginalPosition;
    private Vector3 middleSideOriginalPosition;
    private Vector3 rightSideOriginalPosition;

    private bool areSidesJoined = true;

    private SoundManager sm;

    void Awake() {

        sm = GameObject.FindObjectOfType<SoundManager> ();

    }

    // Use this for initialization
    void Start() {

		duration = sm.GetLength(ClipType.Join);
		
        leftSideOriginalPosition = leftSide.position;
        middleSideOriginalPosition = middleSide.position;
        rightSideOriginalPosition = rightSide.position;
		
        ToggleJoin();

        Invoke("EnableGravityFloatingBuoyancy", duration);

    }

    public void ToggleJoin() {

        if (areSidesJoined) {
			
			Split();

        } else {

			Join();	

        }

        areSidesJoined = !areSidesJoined;

    }

    void EnableGravityFloatingBuoyancy() {

        print("Enabling Gravity Floating Buoyancy");

        foreach(GravityFloat gf in GameObject.FindObjectsOfType<GravityFloat> ()) {
            gf.Float();
        }

    }
	
	void Join() {
		
		sm.Play(ClipType.Join);
		leftSide.DOMove(leftSideOriginalPosition, duration).SetEase(easeType);
		middleSide.DOMove(middleSideOriginalPosition, duration).SetEase(easeType);
		rightSide.DOMove(rightSideOriginalPosition, duration).SetEase(easeType);
		
	}
	
	void Split() {
		
		sm.Play(ClipType.Split);
		leftSide.DOMove(leftSideSplitPosition, duration).SetEase(easeType);
		middleSide.DOMove(middleSideSplitPosition, duration).SetEase(easeType);
		rightSide.DOMove(rightSideSplitPosition, duration).SetEase(easeType);
		
	}

}