
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthData : MonoBehaviour {


	GameObject Head;
	
	Vector3 chewTransform;
	
	Vector3 currentMouthVector;
	Vector3 currentHeadVector;
	public float movementSpeed = 2.5f;
	
	bool chew;

	// Use this for initialization
	void Start () {
		this.Head = GameObject.FindGameObjectWithTag("Face");
		this.currentHeadVector = Head.transform.position;
		this.currentMouthVector = transform.position;
		this.chewTransform = (Head.transform.position-this.transform.position)/2;
		
	}
	void OnTriggerEnter2D (Collider2D collider) {
		this.ChewSpeed();
	}
	IEnumerator stopChew(){
		yield return new WaitForSeconds(6);
		chew = false;
	}
	public void ChewSpeed(){
		chew = true;
		//StartCoroutine(stopChew());
	}
	// Update is called once per frame
	void Update () {
		
				transform.position =  new Vector3(-Mathf.PingPong(Time.time* movementSpeed, 2),transform.position.y,transform.position.z);
			
		 //transform.position = Vector3.Lerp(chewTransform,currentMouthVector,  t);
	}
	
	

}
