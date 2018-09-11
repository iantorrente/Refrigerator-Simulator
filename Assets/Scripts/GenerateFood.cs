using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour {

  public Rigidbody2D foodPrefab;
  public Transform foodSpawner;

  public void buttonClick () {
    //We want to generate random food for each spawner when the fridge is opened. Take
    //that pool from GlobalData.globalData.foodPool because that will be added onto 
    //whenever the player gains access to new foods.
    List<GameObject> foodPool = GlobalData.globalData.foodPool;
    Rigidbody2D foodInstance;
    foodInstance = Instantiate(foodPrefab, foodSpawner.position, foodSpawner.rotation);
  }
}