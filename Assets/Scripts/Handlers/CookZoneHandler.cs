using UnityEngine;

public class CookZoneHandler : MonoBehaviour {
  
  private void OnTriggerStay2D(Collider2D other) {
    if (other.GetComponent<FoodValue>()) {
      string name = other.GetComponent<FoodValue>().foodName;
      other.GetComponent<FoodValue>().cookingTime += Time.deltaTime;
      Debug.Log(name + " is being cooked/burned");
      Debug.Log(other.GetComponent<FoodValue>().cookingTime);

      handleReaction(other);
    }
    
  }

  private void handleReaction (Collider2D other) {
    if (other.GetComponent<FoodValue>().cookingTime > 2.0f) {
      //Copies the components of the reaction result and transfers them to the base food that's being cooked.
      GameObject reactionResult = other.GetComponent<FoodValue>().reactionResult;
      other.GetComponent<SpriteRenderer>().sprite = reactionResult.GetComponent<SpriteRenderer>().sprite;
      Helpers.CopyComponent(reactionResult.GetComponent<FoodValue>(), other.gameObject);
      Instantiate(other.GetComponent<FoodValue>().reactionParticle, other.transform.position, other.transform.rotation);
    }
  }
}