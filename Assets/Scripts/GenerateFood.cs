using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour {

  public Rigidbody2D foodPrefab;
  public Transform foodSpawner;
  private List<Rigidbody2D> foodPool { get; set; }

  public void buttonClick () {
    //We want to generate random food for each spawner when the fridge is opened. Take
    //that pool from GlobalData.globalData.foodPool because that will be added onto 
    //whenever the player gains access to new foods.
    Rigidbody2D foodInstance;
    foodPool = GlobalData.globalData.foodPool;
    foodPrefab = foodPool[Random.Range(0, 3)];
    foodInstance = Instantiate(foodPrefab, foodSpawner.position, foodSpawner.rotation);
  }
}