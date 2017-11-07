﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB : MonoBehaviour {

	public Vector3 AStart;
	public Vector3 BEnd;
	public bool One = false;
	public float MySpeed = 1f;


	void Start () {
		transform.position = AStart;

		Debug.LogFormat ("Hi world" + DateTime.Now.ToString ());
//		MoveTowards (1, 10, 1);
//		MoveTowards (1, -5, 1);
//		MoveTowards (-1, 5, 2);
	}

	void OnDrawGizmos () {
		Gizmos.DrawLine (AStart, BEnd);
	}
		
	void Update () {
		Vector3 Position = transform.position;
//		float P1 = MoveTowards (Position.x, BEnd.x, MySpeed * Time.deltaTime);
//		float P2 = MoveTowards (Position.y, BEnd.y, MySpeed * Time.deltaTime);
//		float P3 = MoveTowards (Position.z, BEnd.z, MySpeed * Time.deltaTime);
		float P1 = MoveTowards2 (Position.x, BEnd.x, MySpeed * Time.deltaTime);
		float P2 = MoveTowards2 (Position.y, BEnd.y, MySpeed * Time.deltaTime);
		float P3 = MoveTowards2 (Position.z, BEnd.z, MySpeed * Time.deltaTime);
		Position.x = P1;
		Position.y = P2;
		Position.z = P3;
		transform.position = Position;
	}

	float MoveTowards (float currentPosition, float targetPosition, float maxDistance) {
		Debug.Log ("MoveMob called");
		Debug.Log ("positions: " + currentPosition + " " + targetPosition + " " + maxDistance);
		if (currentPosition < targetPosition) {
			if (currentPosition <= targetPosition) {
				currentPosition += maxDistance;
			} else {
				currentPosition = targetPosition;
			}
		} else if (currentPosition > targetPosition) {
			if ((currentPosition - maxDistance) >= targetPosition) {
				currentPosition -= maxDistance;
			} else {
				currentPosition = targetPosition;
			}
		}
		return currentPosition;
	}

	float MoveTowards2 (float currentPosition, float targetPosition, float maxDistance) {
		Debug.Log ("MoveMob2 called");
		Debug.Log ("positions: " + currentPosition + " " + targetPosition + " " + maxDistance);

		float delta = targetPosition - currentPosition;

		if (delta > maxDistance) {
			delta *= maxDistance;
		}

		if (delta < -maxDistance) {
			delta *= -1;
		}

		float CP2 = currentPosition + delta;
		return CP2;
	}
}
