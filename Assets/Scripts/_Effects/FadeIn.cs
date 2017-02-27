using DG.Tweening;
using UnityEngine;

public class FadeIn : MonoBehaviour {

	public float waitTime = 0f;
	private float fadeDuration = 1f;

	// Use this for initialization
	void Start () {
		
		this.transform.DOScale(Vector3.zero, 0);
		Invoke("Initialize", waitTime);
		
	}
	
	void Initialize() {
		
		this.transform.DOScale(0.2f, fadeDuration);
		
	}

}