using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateFood : MonoBehaviour {

  private List<Rigidbody2D> foodPool { get; set; }

  public void buttonClick () {
    //We want to generate random food for each spawner when the fridge is opened. Take
    //that pool from GlobalData.globalData.foodPool because that will be added onto 
    //whenever the player gains access to new foods.
    
    GameObject fridgeButton = GameObject.Find("Refrigerator");
    foodPool = GlobalData.globalData.foodPool;
    GameObject[] foodSpawners = GameObject.FindGameObjectsWithTag("Food Spawner");
    Debug.Log(foodSpawners.Length);

    if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "OPEN" ) {
      for (int i = 0; i < foodSpawners.Length; i++) {
        Rigidbody2D randomFood = foodPool[Random.Range(0, foodPool.Count)];
        Collider2D rFCollider = randomFood.GetComponent<Collider2D>();
        foodSpawners[i].GetComponent<SpriteRenderer>().enabled = true;
        foodSpawners[i].GetComponent<SpriteRenderer>().sprite = randomFood.GetComponent<SpriteRenderer>().sprite;
        foodSpawners[i].transform.localScale = randomFood.transform.localScale;
        foodSpawners[i].AddComponent(rFCollider.GetType());
        foodSpawners[i].GetComponent<Collider2D>().isTrigger = true;
        foodSpawners[i].GetComponent<FoodSpawner>().foodPrefab = randomFood;
      }
    } else if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "CLOSE") {
      for (int i = 0; i < foodSpawners.Length; i++) {
        Destroy(foodSpawners[i].GetComponent<Collider2D>());
      }
    }

    handleOpenClose(fridgeButton);
    // Rigidbody2D foodInstance;
    // foodPool = GlobalData.globalData.foodPool;
    // foodPrefab = foodPool[Random.Range(0, foodPool.Count)];
    // foodInstance = Instantiate(foodPrefab, foodSpawner.position, foodSpawner.rotation);
  }

  private void handleOpenClose (GameObject fridgeButton) {
    if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "OPEN") {
      GlobalData.globalData.interactable = true;
      fridgeButton.GetComponentsInChildren<Text>()[0].text = "CLOSE";
    } else if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "CLOSE") {
      GlobalData.globalData.interactable = false;
      fridgeButton.GetComponentsInChildren<Text>()[0].text = "OPEN";
    }
  }
}