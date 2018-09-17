using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Make this class a generic "FoodHandler" to handle scoring and deleting
//attach it to the eat zone and delete zone when it's genericified
public class FoodScoreHandler : MonoBehaviour {
    List<List<string>> foodCorrectSequences = new List<List<string>>{
    new List<string>{"Apple", "Burger", "Banana"}, // classic meal
    new List<string>{"Cake","Cookie","Banana","Cookie","Cake"}, //desert delight
    new List<string>{"Burger","Steak","Sushi"}, //japanese
    new List<string>{"Fish","Sushi"} ,//fishy fishy
    new List<string>{"Banana","Banana"},
    new List<string>{"Cookie","Cookie"}
    };

 
	List<string> foodPlayerSequence = new List<string>{};

	void OnTriggerEnter2D (Collider2D collider) {
    string name = collider.gameObject.GetComponent<FoodValue>().foodName;
	  foodPlayerSequence.Add(name);
    
    int value = collider.gameObject.GetComponent<FoodValue>().scoreValue;
    Helpers.increaseScore(value);
    Helpers.startScoreRun();

    
    var check = false;
    foreach(List<string> foodCorrectSequence in foodCorrectSequences){
      if(foodPlayerSequence.Count <= foodCorrectSequence.Count){
        if(foodCorrectSequence.GetRange(0, foodPlayerSequence.Count).SequenceEqual(foodPlayerSequence))
        {
          CheckFoodSequence(foodCorrectSequence);
          check = true;
        }        
      }
    }
    if(!check){
      foodPlayerSequence = new List<string>(){name};
    }
    Object.Destroy(collider.gameObject);
  }

  

  void CheckFoodSequence(List<string> foodCorrectSequence){
	  if(foodPlayerSequence.SequenceEqual( foodCorrectSequence)){ 
      Helpers.increaseScore(1000);  
      foodPlayerSequence = new List<string>();
    }
  }
}