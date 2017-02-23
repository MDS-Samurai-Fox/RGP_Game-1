using DG.Tweening;
using UnityEngine;

public class Buoyancy : MonoBehaviour {

    // [SerializeField]
    private Ease easeType = Ease.InOutQuad;
    // [SerializeField]
    private float moveValue = 0.1f;
    // [SerializeField]
    private float duration = 2f;
    // [SerializeField]
    private float delay = 0.1f;

    private bool shouldFloatUpwards = true;
    private float yPosition = -0.35f;

    public void Float() {

        if (shouldFloatUpwards) {

            this.transform.DOMoveY(yPosition + moveValue, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);

        } else {

            this.transform.DOMoveY(yPosition - moveValue, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);

        }

        shouldFloatUpwards = !shouldFloatUpwards;

    }

}