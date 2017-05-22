using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SatelliteController : MonoBehaviour {

    private float timer = 0.0f;
    private bool canMove = false;
    private FadeIn fadeIn;
    private float fadeTime;
    private Vector3 panelRotationVector;
    private Transform panels;
    private SpriteRenderer baseRenderer;
    private int movingLeft = 1;

    // Use this for initialization
    void Start () {
        fadeIn = GetComponent<FadeIn>();
        fadeTime = fadeIn.waitTime + 2.0f;
        panelRotationVector = new Vector3(0.0f, 0.0f, 4.0f);
        panels = transform.FindChild("Panels");
        baseRenderer = transform.FindChild("Base").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > fadeTime && !canMove)
        {
            canMove = true;

            if (this.name == "Satellite 1")
                MoveLeft();

            if (this.name == "Satellite 2")
                Orbit(20.0f, 12.0f);
        }

        if (canMove && panels)
        {
            Vector3 newRotation = panels.rotation.eulerAngles + (panelRotationVector * movingLeft);
            panels.DORotate(newRotation, 0.1f);
        }    
    }

    private void MoveLeft()
    {
        transform.DOMove(new Vector3(-7.0f, 0.0f, 0.0f), 11.0f).OnComplete(MoveRight);
        baseRenderer.flipX = false;
        movingLeft = 1;
        // Debug.Log("Satellite Moving left");
    }

    private void MoveRight()
    {
        transform.DOMove(new Vector3(7.0f, 0.0f, 0.0f), 11.0f).OnComplete(MoveLeft);
        baseRenderer.flipX = true;
        movingLeft = -1;
        // Debug.Log("Satellite Moving right");
    }

    private void Orbit(float x, float y)
    {
        // transform.RotateAround(new Vector3(x, y, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), 30.0f);
    }
}
