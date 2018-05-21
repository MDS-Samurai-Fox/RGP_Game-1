using DG.Tweening;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {
	
	public Ease easeType;
	private Vector3 eulerAngles;

	// Use this for initialization
	void Start () {
		
		eulerAngles = transform.eulerAngles;
		RotateRight();
		
	}
	
	void RotateRight() {
		
		this.transform.DORotate(eulerAngles + Vector3.forward * 5, 5f).SetEase(easeType).OnComplete(RotateLeft);
		
	}
	
	void RotateLeft() {
		
		this.transform.DORotate(eulerAngles + Vector3.back * 5, 5f).SetEase(easeType).OnComplete(RotateRight);
		
	}
	
}