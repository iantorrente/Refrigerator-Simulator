using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Make this class a generic "FoodHandler" to handle scoring and deleting
//attach it to the eat zone and delete zone when it's genericified
public class FoodScoreHandler : MonoBehaviour {
 	List<string> foodCorrectSequence = new List<string>{"Apple","Burger","Banana"};
	List<string> foodPlayerSequence = new List<string>{};
  List<ParticleSystem> particles = new List<ParticleSystem>();
  GameObject particleSpawner;

  void Start () {
    particleSpawner = GameObject.Find("Particle Spawner");
    particles = particleSpawner.GetComponent<Particles>().particles;
  }

	void OnTriggerEnter2D (Collider2D collider) {
    string name = collider.gameObject.GetComponent<FoodValue>().foodName;
	  foodPlayerSequence.Add(name);
    
    int value = collider.gameObject.GetComponent<FoodValue>().scoreValue;
    Helpers.increaseFoodEaten();
    Helpers.increaseScore(value);
    Helpers.startScoreRun();

    //Have to make this its own script/class
    if (collider.gameObject.GetComponent<FoodValue>().foodName == "Hot Pepper") {
      particles[0].startDelay = 1;
      Instantiate(particles[0], particleSpawner.transform.position, particles[0].transform.rotation); //Rotation is what sets the z axis
    }

    if(foodCorrectSequence.GetRange(0, foodPlayerSequence.Count).SequenceEqual(foodPlayerSequence) )CheckFoodSequence();
    else foodPlayerSequence = new List<string>(){name};
    instantiateParticleEffect(collider);
    Object.Destroy(collider.gameObject);
  }

  void CheckFoodSequence(){
	  if(foodPlayerSequence.SequenceEqual( foodCorrectSequence)){ 
      Helpers.increaseScore(1000);  
      foodPlayerSequence = new List<string>();
    }
  }

  void instantiateParticleEffect (Collider2D collider) {
    if (collider.gameObject.GetComponent<FoodValue>().particle) {
      Instantiate(collider.gameObject.GetComponent<FoodValue>().particle, collider.transform.position, collider.transform.rotation);
    }
  }
}