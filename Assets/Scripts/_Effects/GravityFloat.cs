using DG.Tweening;
using UnityEngine;

public class GravityFloat : MonoBehaviour {

    [SerializeField]
    private Ease easeType = Ease.InOutQuad;
    [SerializeField]
    private float moveValue = 0.25f;
    [SerializeField]
    private float duration = 2f;
    [SerializeField]
    private float delay = 2f;

    private bool shouldMoveUpwards = false;
    [SerializeField]
    private float yPosition = 0;

    void Start() {

        // yPosition = this.transform.position.y;

    }

    public void Float() {

        if (!shouldMoveUpwards) {

            this.transform.DOMoveY(yPosition - moveValue, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);

        } else {

            this.transform.DOMoveY(yPosition + moveValue, duration).SetEase(easeType).SetDelay(delay).OnComplete(Float);

        }

        shouldMoveUpwards = !shouldMoveUpwards;

    }

}