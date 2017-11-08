using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB : MonoBehaviour {

	public Vector3 AStart;
	public Vector3 BEnd;
	public Vector3 CEnd;
	public Vector3 FinalDestination;
	bool DestinationReached = false;
	bool BEndReached = false;
	bool CEndReached = false;

	public float MySpeed = 1f;


	void Start () {
		transform.position = AStart;
		FinalDestination.x = 13;
		FinalDestination.y = 1;
		FinalDestination.z = 1;
//		Debug.LogFormat ("Hi world" + DateTime.Now.ToString ());

	}

	void OnDrawGizmos () {
		Gizmos.DrawLine (AStart, BEnd);
		Gizmos.DrawLine (BEnd, CEnd);
	}
		
	void Update () {
		if (!DestinationReached) {
			if (!BEndReached) {
				Vector3 Position = transform.position;
				Vector3 P4 = MoveTowards4 (Position, BEnd, MySpeed * Time.deltaTime);
				transform.position = P4;
				if (P4 == BEnd) {
					Debug.Log ("HERE!!!");
					BEndReached = true;
				}
			} else if (!CEndReached) {
				Vector3 Position = transform.position;
				Vector3 P5 = MoveTowards4 (Position, CEnd, MySpeed * Time.deltaTime);
				transform.position = P5;
				if (P5 == CEnd) {
					CEndReached = true;
					DestinationReached = true;
					Debug.Log ("HERE!!!");
				}
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

