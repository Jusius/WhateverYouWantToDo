﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float moveSpeed = 15;
	private Vector3 moveDirection;


	void Update() {
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
	}

	void FixedUpdate() {

		//rigidbody2D.MovePosition(rigidbody2D.position + /test * moveSpeed * Time.deltaTime);
	}
}