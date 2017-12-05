using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public GameObject BulletPrefab;

	float TurretRange = 4f;

	public MOB Enemy1;

	bool IsFiring = false;

	float TimeLastFired;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Enemy1 == null) {
			// my target is dead  TODO:  retarget
			return;
		}
		Vector3 turretPosition = transform.position;
		Vector3 enemyPosition = Enemy1.transform.position;
//		Debug.Log ("enemyPosition: " + enemyPosition);

		Vector3 relativeEnemyPos = enemyPosition - turretPosition;
		float distance = relativeEnemyPos.magnitude;

		if (distance <= TurretRange) {
			float howLongSinceFire = Time.time - TimeLastFired;
			if (howLongSinceFire > 1) {
				Fire ();
//				Debug.DrawLine (turretPosition, enemyPosition, Color.red, 0.1f);
			}

		}
	}

	void Fire() {
		TimeLastFired = Time.time;

		GameObject bulletGO = Instantiate (BulletPrefab);

		Projectile singleBullet = bulletGO.GetComponent<Projectile> ();

		singleBullet.MyParentTurret = this;

		singleBullet.Target = Enemy1;
	}


}
