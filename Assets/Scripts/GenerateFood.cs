using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
  Controls all aspects of generating food. Also handles opening/closing the fridge
  because I don't know the meaning of "single responsibility".

  ===Will contain logic for checking if the fridge is empty of food===
*/
public class GenerateFood : MonoBehaviour {

  private List<Rigidbody2D> foodPool { get; set; }
  private GameObject[] foodSpawners { get; set; }
  
  private void Start () {

    foodSpawners = GameObject.FindGameObjectsWithTag("Food Spawner");
  }

  public void buttonClick () {
    GameObject fridgeButton = GameObject.Find("Refrigerator"); //Move this to Start()
    foodPool = GlobalData.globalData.foodPool; 

    if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "OPEN" ) {
      Initializer.achievementHandler.RegisterEvent(AchievementType.Start);
      for (int i = 0; i < foodSpawners.Length; i++) {
        Rigidbody2D randomFood = foodPool[Random.Range(0, foodPool.Count)];
        Collider2D rFCollider = randomFood.GetComponent<Collider2D>();
        foodSpawners[i].GetComponent<SpriteRenderer>().enabled = true;
        //If the food object has more than one sprite, randomize through it
        foodSpawners[i].GetComponent<SpriteRenderer>().sprite = randomFood.GetComponent<SpriteRenderer>().sprite; 
        foodSpawners[i].transform.localScale = randomFood.transform.localScale / 10;
        foodSpawners[i].AddComponent(rFCollider.GetType());
        foodSpawners[i].GetComponent<Collider2D>().isTrigger = true;
        foodSpawners[i].GetComponent<FoodSpawner>().foodPrefab = randomFood; //Add the random food to the food spawner
      }
    } else if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "CLOSE") {
      checkFridge();

      for (int i = 0; i < foodSpawners.Length; i++) {
        Destroy(foodSpawners[i].GetComponent<Collider2D>());
      }
    }

    handleOpenClose(fridgeButton);
  }

  private void handleOpenClose (GameObject fridgeButton) {
    if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "OPEN") {
      GlobalData.globalData.interactable = true;
      fridgeButton.GetComponentsInChildren<Text>()[0].text = "CLOSE";
      GameObject.Find("Refrigerator1_Door").GetComponent<SpriteRenderer>().enabled = false;
    } else if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "CLOSE") {
      GlobalData.globalData.interactable = false;
      fridgeButton.GetComponentsInChildren<Text>()[0].text = "OPEN";
      GameObject.Find("Refrigerator1_Door").GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  //Checks how much food is left in the fridge and gives players score depending on it
  private void checkFridge () {
    int foodTakenOutOfFridge = GlobalData.globalData.foodTakenOutOfFridge;
    int fridgeScore = GlobalData.globalData.scoreForFridge;
    Debug.Log(foodTakenOutOfFridge + " food taken out");
    int scoreForFridge = foodTakenOutOfFridge * fridgeScore;
    Helpers.increaseScore(scoreForFridge);
    GlobalData.globalData.foodTakenOutOfFridge = 0;
  }
}