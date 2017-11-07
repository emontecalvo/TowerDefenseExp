using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB : MonoBehaviour {

	public Vector3 AStart;
	public Vector3 BEnd;
	public bool One = false;

	// Use this for initialization
	void Start () {
		transform.position = AStart;

		Debug.LogFormat ("Hi world" + DateTime.Now.ToString ());
		MoveMob (1, 10, 1);
		MoveMob (1, -5, 1);
		MoveMob (-1, 5, 2);
	}

	void OnDrawGizmos () {
	
		Gizmos.DrawLine (AStart, BEnd);
	
	}
		

	// Update is called once per frame
	void Update () {
//		Vector3 delta = new Vector3 (AStart, BEnd, 0);
//		transform.position = transform.position + delta;
//		if (!One) {
//			StartCoroutine(Move_Routine(this.transform, AStart, BEnd));
//			One = true;
//		}

	}

	private IEnumerator Move_Routine(Transform transform, Vector3 from, Vector3 to)
	{
		float t = 0f;
		while(t < 1f)
		{
			t += Time.deltaTime;
			transform.position = Vector3.Lerp(from, to, Mathf.SmoothStep(0f, 1f, t));
			yield return null;
		}
	}


	float MoveMob (float currentPosition, float targetPosition, float maxDistance) {
		Debug.Log ("MoveMob called");

	}
}
