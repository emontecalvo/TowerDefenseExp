using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public MOB Target;
	public Turret MyParentTurret;

	public float MySpeed = 1f;


	// Use this for initialization
	void Start () {
		Vector3 startPosition = MyParentTurret.transform.position;
		transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 destination = Target.transform.position;

		Vector3 position = transform.position;
		Vector3 P4 = MOB.MoveTowards4 (position, destination, MySpeed * Time.deltaTime);
		transform.position = P4;

		Debug.DrawLine (position, destination, Color.red);

		if (P4 == destination) {
			Debug.Log ("REACHED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			Destroy (gameObject);
		}
	}
}
