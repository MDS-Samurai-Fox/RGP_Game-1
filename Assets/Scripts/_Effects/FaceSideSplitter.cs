﻿using DG.Tweening;
using UnityEngine;

public class FaceSideSplitter : MonoBehaviour {

    [HeaderAttribute("Tweening variables")]
    [SerializeField]
    private Ease easeType = Ease.InOutQuad;
    private float duration = 1f;

    [HeaderAttribute("Transforms")]
    public Transform faceParent;
    public Transform leftSide;
    public Transform middleSide;
    public Transform rightSide;
    public ParticleSystem particles;

    [HeaderAttribute("Split Position Vectors")]
    public Vector3 leftSideSplitPosition;
    public Vector3 middleSideSplitPosition;
    public Vector3 rightSideSplitPosition;

    private Vector3 leftSideOriginalPosition;
    private Vector3 middleSideOriginalPosition;
    private Vector3 rightSideOriginalPosition;

    private bool areSidesJoined = true;

    private SoundManager soundManager;

    private Buoyancy buoyancy;

    void Awake() {

        soundManager = GameObject.FindObjectOfType<SoundManager> ();
        buoyancy = GameObject.FindObjectOfType<Buoyancy> ();

    }

    // Use this for initialization
    void Start() {

        particles.Stop();

        duration = soundManager.GetLength(ClipType.Join);

        leftSideOriginalPosition = leftSide.localPosition;
        middleSideOriginalPosition = middleSide.localPosition;
        rightSideOriginalPosition = rightSide.localPosition;

        faceParent.DOMove(new Vector3(0, -0.35f, 0), duration).SetEase(Ease.OutBack).OnComplete(EnableBuoyancy);
		
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

    void EnableBuoyancy() {

        buoyancy.Float();

    }

    public void DisableBuoyancy() {

        buoyancy.Stop();

    }

    void Join() {

        duration = soundManager.GetLength(ClipType.Join);
        soundManager.Play(ClipType.Finish);
        PlayAnimationBlastStart();

        leftSide.DOLocalMove(leftSideOriginalPosition, duration).SetEase(easeType);
        middleSide.DOLocalMove(middleSideOriginalPosition, duration).SetEase(easeType);
        rightSide.DOLocalMove(rightSideOriginalPosition, duration).SetEase(easeType).OnComplete(PlayAnimationBlastEnd);

    }

    void Split() {

        duration = soundManager.GetLength(ClipType.Split);
        soundManager.Play(ClipType.Split);
        PlayAnimationBlastStart();

        leftSide.DOLocalMove(leftSideSplitPosition, duration).SetEase(easeType);
        middleSide.DOLocalMove(middleSideSplitPosition, duration).SetEase(easeType);
        rightSide.DOLocalMove(rightSideSplitPosition, duration).SetEase(easeType).OnComplete(PlayAnimationBlastEnd);

    }

    void PlayAnimationBlastStart() {
        soundManager.Play(ClipType.BlastStart);
    }

    void PlayAnimationBlastEnd() {
        soundManager.Play(ClipType.BlastEnd);
    }

}