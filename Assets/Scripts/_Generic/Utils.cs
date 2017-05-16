using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static IEnumerator Pause(float p) {

        Time.timeScale = 0.1f;

        float pauseEndTime = Time.realtimeSinceStartup + p;

        while (Time.realtimeSinceStartup < pauseEndTime) {
            yield return 0;
        }

        Time.timeScale = 1;

    }

}
