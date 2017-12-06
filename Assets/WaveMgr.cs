using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMgr : MonoBehaviour {

	public Vector3[] Path1;
	public Vector3[] Path2;
	public Vector3[] Path3;

	public GameObject MOBPrefab;

	float TimeLastFired;

	void Start () {

	}


	void Update () {

		float howLongSinceFire = Time.time - TimeLastFired;
		if (howLongSinceFire > 1) {
			Fire ();

		}
	}

	void Fire() {
		TimeLastFired = Time.time;

		GameObject mobGO = Instantiate (MOBPrefab);

		MOB mob = mobGO.GetComponent<MOB> ();

		mob.DestPoints = Path1;

	}
}
