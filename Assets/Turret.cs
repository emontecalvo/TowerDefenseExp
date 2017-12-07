using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public GameObject BulletPrefab;

	float TurretRange = 4f;

	public MOB Enemy1;

	bool IsFiring = false;

	float TimeLastFired;

	public WaveMgr waveMgr;

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		FindClosestEnemy ();
		ShootAtEnemyIfInRange ();
	}

	void FindClosestEnemy() {
		
		Vector3 turretPosition = transform.position;
		float shortestDistance = 10000f;
		MOB closestMob = null;

		for (int i = 0; i < waveMgr.AllMOBs.Count; i++) {
			MOB mob = waveMgr.AllMOBs [i];
			if (mob == null) {
				continue;
			}
			Vector3 mobPosition = mob.transform.position;
			Vector3 relativePosition = mobPosition - turretPosition;

			float distance = relativePosition.magnitude;

			if (distance < shortestDistance) {
				shortestDistance = distance;
				closestMob = mob;
			}
		}

		Enemy1 = closestMob;

	}
	
	// Update is called once per frame
	void ShootAtEnemyIfInRange () {
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
