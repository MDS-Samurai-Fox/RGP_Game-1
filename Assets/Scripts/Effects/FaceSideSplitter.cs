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

    // Use this for initialization
    void Start() {

        leftSideOriginalPosition = leftSide.position;
        middleSideOriginalPosition = middleSide.position;
        rightSideOriginalPosition = rightSide.position;

        ToggleJoin();
		
		Invoke("EnableGravityFloatingBuoyancy", duration);

    }

    public void ToggleJoin() {

        if (areSidesJoined) {
			
			leftSide.DOMove(leftSideSplitPosition, duration).SetEase(easeType);
			middleSide.DOMove(middleSideSplitPosition, duration).SetEase(easeType);
			rightSide.DOMove(rightSideSplitPosition, duration).SetEase(easeType);

        } else {

			leftSide.DOMove(leftSideOriginalPosition, duration).SetEase(easeType);
			middleSide.DOMove(middleSideOriginalPosition, duration).SetEase(easeType);
			rightSide.DOMove(rightSideOriginalPosition, duration).SetEase(easeType);

        }

        areSidesJoined = !areSidesJoined;

    }
	
	void EnableGravityFloatingBuoyancy() {
		
		print("Enabling Gravity Floating Buoyancy");
		
		foreach (GravityFloat gf in GameObject.FindObjectsOfType<GravityFloat>()) {
			gf.Float();
		}
		
	}

}