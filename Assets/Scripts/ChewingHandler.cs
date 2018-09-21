using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingHandler : MonoBehaviour {
	GameObject Head;
	GameObject Mouth;
	Vector3 chewTransform;
	
	Vector3 currentMouthVector;
	Vector3 currentHeadVector;
	float movementSpeed = 1;


	public ChewingHandler(){
		this.Head = GameObject.FindGameObjectsWithTag("Face")[1];
		this.Mouth = GameObject.FindGameObjectsWithTag("Face")[0];
		this.currentHeadVector = Head.transform.position;
		this.currentMouthVector = Mouth.transform.position;
		this.chewTransform = (Head.transform.position-Mouth.transform.position)/2;
	}

	public void Chew () {
		
		Mouth.transform.position = Vector3.Lerp(currentMouthVector,chewTransform, Mathf.PingPong(3,1 ));
		


  	}

  

}
