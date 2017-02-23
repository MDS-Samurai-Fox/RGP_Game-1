using DG.Tweening;
using UnityEngine;

public class FaceSideSplitter : MonoBehaviour {

	[HeaderAttribute("Tweening variables")]
	[SerializeField]
	private Ease easeType = Ease.InOutQuad;
	[SerializeField]
	private float duration = 1f;

	[HeaderAttribute("Sides of the face")]
	public Transform faceParent;
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

	private SoundManager soundManager;

	void Awake() {

		soundManager = GameObject.FindObjectOfType<SoundManager> ();

	}

	// Use this for initialization
	void Start() {

		duration = soundManager.GetLength(ClipType.Join);
		
		leftSideOriginalPosition = leftSide.localPosition;
		middleSideOriginalPosition = middleSide.localPosition;
		rightSideOriginalPosition = rightSide.localPosition;
		
		faceParent.DOMove(new Vector3(0, -0.35f, 0), duration).SetEase(Ease.OutBack).OnComplete(EnableGravityFloatingBuoyancy);
		ToggleJoin();

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

		foreach(Buoyancy gf in GameObject.FindObjectsOfType<Buoyancy> ()) {
			gf.Float();
		}

	}
	
	void Join() {
		
		duration = soundManager.GetLength(ClipType.Join);
		soundManager.Play(ClipType.Join);
		
		leftSide.DOLocalMove(leftSideOriginalPosition, duration).SetEase(easeType);
		middleSide.DOLocalMove(middleSideOriginalPosition, duration).SetEase(easeType);
		rightSide.DOLocalMove(rightSideOriginalPosition, duration).SetEase(easeType);
		
	}
	
	void Split() {
		
		duration = soundManager.GetLength(ClipType.Split);
		soundManager.Play(ClipType.Split);
		leftSide.DOLocalMove(leftSideSplitPosition, duration).SetEase(easeType);
		middleSide.DOLocalMove(middleSideSplitPosition, duration).SetEase(easeType);
		rightSide.DOLocalMove(rightSideSplitPosition, duration).SetEase(easeType);
		
	}

}