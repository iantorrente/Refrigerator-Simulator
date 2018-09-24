using System.Collections.Generic;
using UnityEngine;

public class FoodItems : MonoBehaviour {
  public static List<Rigidbody2D> allFoodItems { get; set; }

  public static GameObject getFoodItem (string foodItem) {
    GameObject food = new GameObject();
    allFoodItems = GlobalData.globalData.allFoodItems;

    for (int i = 0; i < allFoodItems.Count; i++) {
      if (foodItem == allFoodItems[i].GetComponent<FoodValue>().foodName) {
        food = allFoodItems[i].gameObject;
      }
    }

    return food;
  }
}