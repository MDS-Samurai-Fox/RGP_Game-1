using DG.Tweening;
using UnityEngine;

public class Buoyancy : MonoBehaviour {

    private Ease easeType = Ease.InOutQuad;
    private float moveAmount = 0.1f;
    private float duration = 2f;
    private float delay = 0.35f;

    private bool canFloat = true;
    private bool shouldFloatUpwards = true;
    private float yPosition = -0.35f;

    public void Float() {

        if (!canFloat)
            return;

        if (shouldFloatUpwards) {

            this.transform.DOMoveY(yPosition + moveAmount, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);

        } else {

            this.transform.DOMoveY(yPosition - moveAmount, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);

        }

        shouldFloatUpwards = !shouldFloatUpwards;

    }

    public void Stop() {
        canFloat = false;
    }

}