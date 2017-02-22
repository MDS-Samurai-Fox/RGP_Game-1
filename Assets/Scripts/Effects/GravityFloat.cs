using DG.Tweening;
using UnityEngine;

public class GravityFloat : MonoBehaviour {
	
	[SerializeField]
	private Ease easeType = Ease.OutQuad;
	[SerializeField]
	private float moveValue = 0.25f;
	[SerializeField]
	private float duration = 2f;
	[SerializeField]
	private float delay = 2f;
	
    private bool shouldMoveUpwards = false;
	private float y;

    // Use this for initialization
    void Start() {
		
		y = this.transform.position.y;
		
		Invoke("Float", delay);

    }

    void Float() {

        if (!shouldMoveUpwards) {

            this.transform.DOMoveY(y - moveValue, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);
			
			
        }
		else {
			
			this.transform.DOMoveY(y + moveValue, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);
			// shouldMoveUpwards = false;
			
		}
		
		shouldMoveUpwards = !shouldMoveUpwards;

    }

}