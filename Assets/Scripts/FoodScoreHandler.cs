using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Make this class a generic "FoodHandler" to handle scoring and deleting
//attach it to the eat zone and delete zone when it's genericified
public class FoodScoreHandler : MonoBehaviour {
    public static readonly IList<List<string>> foodCorrectSequences = new List<List<string>>{
    new List<string>{"Apple", "Burger", "Banana"}, // classic meal
    new List<string>{"Cake","Cookie","Banana","Cookie","Cake"}, //desert delight
    new List<string>{"Burger","Steak","Sushi"}, //japanese
    new List<string>{"Fish","Sushi"} ,//fishy fishy
    new List<string>{"Banana","Banana"},
    new List<string>{"Cookie","Cookie"},
    new List<string>{"Rotten Food","Rotten Food"}
    };

    public static readonly Dictionary<List<string>, System.Action> commandDictionary = new Dictionary<List<string>,System.Action>
    {
      {foodCorrectSequences[0],() => Helpers.increaseScore(150)},
      {foodCorrectSequences[1],() => Helpers.increaseScore(777)},
      {foodCorrectSequences[2],() => Helpers.increaseScore(200)},
      {foodCorrectSequences[3],() => Helpers.increaseScore(50)},
      {foodCorrectSequences[4],() => Helpers.increaseScore(20)},
      {foodCorrectSequences[5],() => Helpers.increaseScore(200)},
      {foodCorrectSequences[6],() => Helpers.increaseScore(-200)}
    }; 
    ChewingHandler chewingHandler;
	List<string> foodPlayerSequence = new List<string>{};
  void Start(){
    this.chewingHandler = new ChewingHandler();
  }

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
    chewingHandler.Chew();
    Object.Destroy(collider.gameObject);
  }

  

  void CheckFoodSequence(List<string> foodCorrectSequence){
	  if(foodPlayerSequence.SequenceEqual( foodCorrectSequence)){ 
      commandDictionary[foodCorrectSequence]();
      
      foodPlayerSequence = new List<string>();
    }
  }
}