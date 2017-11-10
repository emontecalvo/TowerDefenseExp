using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB : MonoBehaviour {

	public Vector3 FinalDestination;

	public Vector3[] DestPoints;

	int DestI = 1;

	public float MySpeed = 1f;


	void Start () {

	}

	void OnDrawGizmos () {
		for (int i = 0; i < DestPoints.Length - 1; i++) {
			Gizmos.DrawLine (DestPoints[i], DestPoints[i+1]);
		}
	}
		
	void Update () {
		Debug.Log ("destI is : " + DestI);

		if (DestI < DestPoints.Length) {
			Vector3 Position = transform.position;
			Vector3 P4 = MoveTowards4 (Position, DestPoints[DestI], MySpeed * Time.deltaTime);
			transform.position = P4;
			if (P4 == DestPoints[DestI]) {
				DestI += 1;
			}
		}
	}


	Vector3 MoveTowards4 (Vector3 currentPosition, Vector3 targetPosition, float maxDistance) {
		Debug.Log ("MoveMob4 called");
		Debug.Log ("positions: " + currentPosition + " " + targetPosition + " " + maxDistance);

		Vector3 distanceToGo = targetPosition - currentPosition;
		float length = distanceToGo.magnitude;
		bool shouldShorten;
		float shorteningCoefficientFraction;
		Vector3 moveAmount;
		Vector3 finalPosition;

		if (length < maxDistance) {
			shouldShorten = false;
		} else {
			shouldShorten = true;
		}

		if (shouldShorten) {
			shorteningCoefficientFraction = maxDistance / length;
			moveAmount = distanceToGo * shorteningCoefficientFraction;
		} else {
			moveAmount = distanceToGo;
		}

		finalPosition = currentPosition + moveAmount;
		return finalPosition;
	}


}

