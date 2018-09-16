using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Make this class a generic "FoodHandler" to handle scoring and deleting
//attach it to the eat zone and delete zone when it's genericified
public class FoodScoreHandler : MonoBehaviour {
 	List<string> foodCorrectSequence = new List<string>{"Apple","Burger","Banana"};
	List<string> foodPlayerSequence = new List<string>{};

	void OnTriggerEnter2D (Collider2D collider) {
    string name = collider.gameObject.GetComponent<FoodValue>().foodName;
	  foodPlayerSequence.Add(name);
    
    int value = collider.gameObject.GetComponent<FoodValue>().scoreValue;
    Helpers.increaseScore(value);
    Helpers.startScoreRun();

    if(foodCorrectSequence.GetRange(0, foodPlayerSequence.Count).SequenceEqual(foodPlayerSequence) )CheckFoodSequence();
    else foodPlayerSequence = new List<string>(){name};
    Object.Destroy(collider.gameObject);
  }

  void CheckFoodSequence(){
	  if(foodPlayerSequence.SequenceEqual( foodCorrectSequence)){ 
      Helpers.increaseScore(1000);  
      foodPlayerSequence = new List<string>();
    }
  }
}