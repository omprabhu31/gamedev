using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetMover : MonoBehaviour {

    public bool doSpin = true;
    public float spinSpeed = 180.0f;
    public bool doMotion = true;
    public float motionMagnitude = 0.1f;
	
	// Update is called once per frame
	void Update () {
        //rotate around the up axis of the gameobject if doSpin = true
        if (doSpin) {
            gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }

        //move up and down over time if doMotion = true
        if (doMotion) {
            gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
        }
	}
}
