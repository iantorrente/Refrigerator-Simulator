using UnityEngine;

public class CookZoneHandler : MonoBehaviour {

  private GameObject food;
  private float startTime;

  private void OnTriggerEnter2D(Collider2D other) {
    food = other.gameObject;
  }
  
  private void OnTriggerStay2D(Collider2D other) {
    if (food.GetComponent<FoodValue>()) {
      string name = food.GetComponent<FoodValue>().foodName;
      startTime += Time.deltaTime;
      Debug.Log(name + " is being cooked/burned");
      Debug.Log(startTime);

      handleReaction(other);
    }
    
  }

  private void OnTriggerExit2D(Collider2D other) {
    startTime = 0.0f;
  }

  private void handleReaction (Collider2D other) {
    if (startTime > 2.0f) {
      //Copies the components of the reaction result and transfers them to the base food that's being cooked.
      GameObject reactionResult = other.GetComponent<FoodValue>().reactionResult;
      other.GetComponent<SpriteRenderer>().sprite = reactionResult.GetComponent<SpriteRenderer>().sprite;
      Helpers.CopyComponent(reactionResult.GetComponent<FoodValue>(), other.gameObject);
      Instantiate(other.GetComponent<FoodValue>().reactionParticle, other.transform.position, other.transform.rotation);
      startTime = 0.0f;
    }
  }
}