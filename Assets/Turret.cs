using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	float TurretRange = 4f;

	public MOB Enemy1;

	bool IsFiring = false;

	float TimeLastFired;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 turretPosition = transform.position;
		Vector3 enemyPosition = Enemy1.transform.position;
//		Debug.Log ("enemyPosition: " + enemyPosition);

		Vector3 relativeEnemyPos = enemyPosition - turretPosition;
		float distance = relativeEnemyPos.magnitude;

		if (distance <= TurretRange) {
			float howLongSinceFire = Time.time - TimeLastFired;
			if (howLongSinceFire > 1) {
				Fire ();
				Debug.DrawLine (turretPosition, enemyPosition, Color.red, 0.1f);
			}

		}
	}

	void Fire() {
		Debug.Log ("I'm firing");
		TimeLastFired = Time.time;
	}


}
