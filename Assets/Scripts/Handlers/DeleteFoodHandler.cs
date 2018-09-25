using UnityEngine;

public class DeleteFoodHandler : MonoBehaviour {

  void OnTriggerEnter2D (Collider2D collider) {
    Object.Destroy(collider.gameObject);
  }
}