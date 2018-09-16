using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make this class a generic "FoodHandler" to handle scoring and deleting
//attach it to the eat zone and delete zone when it's genericified
public class FoodScoreHandler : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
    int value = collider.gameObject.GetComponent<FoodValue>().scoreValue;
    Helpers.increaseScore(value);
    Helpers.startScoreRun();
    Object.Destroy(collider.gameObject);
  }
}
