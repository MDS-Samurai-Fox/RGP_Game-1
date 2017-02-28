using DG.Tweening;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {
	
	public Ease easeType;

	// Use this for initialization
	void Start () {
		
		RotateRight();
		
	}
	
	void RotateRight() {
		
		this.transform.DORotate(Vector3.forward * 15, 5f).SetEase(easeType).OnComplete(RotateLeft);
		
	}
	
	void RotateLeft() {
		
		this.transform.DORotate(Vector3.back * 15, 5f).SetEase(easeType).OnComplete(RotateRight);
		
	}
	
}