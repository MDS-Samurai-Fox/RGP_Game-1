using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffectController : MonoBehaviour {

    private Vector3 originalPosition;

	// Use this for initialization
	void Start () {

        originalPosition = transform.position;
		
	}

    public void Shake(float duration, float strength) {

        transform.DOShakePosition(duration, strength);
        transform.DOMove(originalPosition, 0).SetDelay(duration);

    }

}
