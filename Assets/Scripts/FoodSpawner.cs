using UnityEngine;

public class FoodSpawner : MonoBehaviour {
  public Rigidbody2D foodPrefab;

  void Update () {
    //Need to do a check that the player isn't holding an item with that finger (seems like DragRigidBody2D already does this. Check in on it though)
    if (Input.touchCount > 0 && GlobalData.globalData.interactable == true) {
      Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

      if (this.GetComponent<Collider2D>() != null && GetComponent<Collider2D>().OverlapPoint(worldPoint)) {
        Rigidbody2D foodInstance;
        foodInstance = Instantiate(foodPrefab, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
        foodInstance.transform.localScale = foodInstance.transform.localScale;
        Destroy(GetComponent<Collider2D>());
        GetComponent<SpriteRenderer>().enabled = false;
      }
    }
  }
}