using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMgr : MonoBehaviour {

	public Vector3[] Path1;
	public Vector3[] Path2;
	public Vector3[] Path3;

	public GameObject MOBPrefab;

	float TimeLastFired;

	public List<MOB> AllMOBs = new List<MOB>();

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

		// mobGO is the Game Object
		GameObject mobGO = Instantiate (MOBPrefab);

		// mob is the component
		MOB mob = mobGO.GetComponent<MOB> ();

		AllMOBs.Add (mob);

		mob.DestPoints = Path1;

	}
}
