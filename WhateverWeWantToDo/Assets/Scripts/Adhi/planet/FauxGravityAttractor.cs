using UnityEngine;
using System.Collections;

public class FauxGravityAttractor : MonoBehaviour {

	public float gravity = -12;
	public FauxGravityAttractor thisPlanet;
	void Start(){
		thisPlanet = GetComponent<FauxGravityAttractor>();
	}

	public void Attract(Transform body) {
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 localUp = body.up;

		body.rigidbody2D.AddForce(gravityUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation(localUp,gravityUp) * body.rotation;
		body.rotation = Quaternion.Slerp(body.rotation,targetRotation,50f * Time.deltaTime );
	}   

	public void OnTriggerEnter2D(Collider2D collider2D){
		FauxGravityBody enteredObject = collider2D.gameObject.GetComponent<FauxGravityBody>();
		if(enteredObject!=null){
			enteredObject.attractor = thisPlanet;
		}
	}
	public void OnTriggerExit2D(Collider2D collider2D){
		FauxGravityBody enteredObject = collider2D.gameObject.GetComponent<FauxGravityBody>();
		if(enteredObject!=null){
			enteredObject.attractor = null;
		}
	}
}
