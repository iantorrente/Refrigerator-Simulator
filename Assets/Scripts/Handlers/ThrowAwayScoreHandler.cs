using UnityEngine;

public class ThrowAwayScoreHandler : MonoBehaviour {
  void OnTriggerEnter2D (Collider2D collider) {
    int throwAwayValue = collider.gameObject.GetComponent<FoodValue>().throwAwayValue;
    Helpers.increaseFoodDiscarded();
    Helpers.increaseScore(throwAwayValue);
    Object.Destroy(collider.gameObject);
  }
}