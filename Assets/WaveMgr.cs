using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMgr : MonoBehaviour {

	public Vector3[] Path1;
	public Vector3[] Path2;
	public Vector3[] Path3;

	int WaveLimit = 3;
	int CurrentWave = 0;

	public GameObject MOBPrefab;

	float TimeLastFired;

	float TimeLastWave;

	public List<MOB> AllMOBs = new List<MOB>();

	int EnemyCount = 4;
	int CurrentEnemyCount = 0;

	float TimeUntilNextWave = -1f;

	bool IsWaveFinished = false;

	void Start () {

	}


	void Update () {

		if (TimeUntilNextWave > 0) {
			TimeUntilNextWave -= Time.deltaTime;
			if (TimeUntilNextWave <= 0) {
				CurrentWave += 1;
				TimeUntilNextWave = -1f;
				IsWaveFinished = false;
			}
		}

		if (CurrentWave == 0) {
			Wave0 ();
		} else if (CurrentWave == 1) {
			Wave1 ();
		} else if (CurrentWave == 2) {
			Wave2 ();
		}
	}

	void Fire() {
		TimeLastFired = Time.time;

		TimeLastWave = Time.time;

		// mobGO is the Game Object
		GameObject mobGO = Instantiate (MOBPrefab);

		// mob is the component
		MOB mob = mobGO.GetComponent<MOB> ();

		AllMOBs.Add (mob);

		mob.DestPoints = Path1;
	}

	void Wave0() {
		if (IsWaveFinished) {
			return;
		}

//		Debug.Log ("wave0 called");
		float howLongSinceFire = Time.time - TimeLastFired;
		if (howLongSinceFire > 2 && CurrentEnemyCount < EnemyCount) {
			Fire ();
			CurrentEnemyCount += 1;
		} else if (CurrentEnemyCount >= EnemyCount) {
			CurrentEnemyCount = 0;
			EnemyCount += 1;
//			CurrentWave += 1;
			IsWaveFinished = true;
			TimeUntilNextWave = 12;
		}
	}

	void Wave1() {
		Debug.Log ("* * * * * * * wave1 called");
		float howLongSinceFire = Time.time - TimeLastFired;
		if (howLongSinceFire > 1.5 && CurrentEnemyCount < EnemyCount) {
			Fire ();
			CurrentEnemyCount += 1;
		} else if (CurrentEnemyCount >= EnemyCount) {
			CurrentEnemyCount = 0;
			EnemyCount += 1;
			IsWaveFinished = true;
			TimeUntilNextWave = 12;
		}
	}

	void Wave2() {
		Debug.Log ("* * wave2 called ! ! ! ! ! ! ! !");
		float howLongSinceFire = Time.time - TimeLastFired;
		if (howLongSinceFire > 1 && CurrentEnemyCount < EnemyCount) {
			Fire ();
			CurrentEnemyCount += 1;
		} else if (CurrentEnemyCount >= EnemyCount) {
			CurrentEnemyCount = 0;
			EnemyCount += 1;
			IsWaveFinished = true;
			TimeUntilNextWave = 8;
		}
	}
}
