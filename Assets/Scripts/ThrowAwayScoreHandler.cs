using UnityEngine;

public class ThrowAwayScoreHandler : MonoBehaviour {
  void OnTriggerEnter2D (Collider2D collider) {
    string name = collider.gameObject.GetComponent<FoodValue>().foodName;
    
    int throwAwayValue = collider.gameObject.GetComponent<FoodValue>().throwAwayValue;
    Helpers.increaseFoodDiscarded();
    Helpers.increaseScore(throwAwayValue);
    Object.Destroy(collider.gameObject);
  }
}