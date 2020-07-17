using UnityEngine;
using System.Collections;

public class AdvancedTargetMover : MonoBehaviour {

    // motion parameters
    public bool doSpin = true;
	public float spinSpeed = 180.0f;
    public bool doHorizontalMotion = true;
	public float horizontalMotionMagnitude = 0.1f;
    public bool doVerticalMotion = true;
    public float verticalMotionMagnitude = 0.1f;

	// Update is called once per frame
	void Update () {

		if (doSpin)
        {
            gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }

        if (doHorizontalMotion)
        {
            gameObject.transform.Translate(Vector3.right * horizontalMotionMagnitude * Mathf.Cos(Time.timeSinceLevelLoad));
        }

        if (doVerticalMotion)
        {
            gameObject.transform.Translate(Vector3.up * verticalMotionMagnitude * Mathf.Cos(Time.timeSinceLevelLoad));
        }

    }
}
