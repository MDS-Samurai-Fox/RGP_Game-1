using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnalogLever : MonoBehaviour
{

    private GameManager gameManager;
    private Vector3 rotationVector;
    private int rotateDirection = 1;

    void Start()
    {
        rotationVector = new Vector3(0.0f, 0.0f, 4.0f);
    }

    // Use this for initialization
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.rotation.eulerAngles.z);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (!gameManager.canUpdate)
            return;

        float z = transform.rotation.eulerAngles.z;

        if (z >= 50.0f && z <= 200.0f)
        {
            // Debug.Log("Analog Lever Moving Right");
            rotateDirection = -1;
        }
        else if (z <= 310.0f && z >= 201.0f)
        {
            // Debug.Log("Analog Lever Moving Left");
            rotateDirection = 1;
        }

      

        Vector3 newRotation = transform.rotation.eulerAngles + (rotationVector* rotateDirection);
        transform.DORotate(newRotation, 0.1f);
    }
}
