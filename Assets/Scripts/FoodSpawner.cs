using UnityEngine;

public class FoodSpawner : MonoBehaviour {
  public Rigidbody2D foodPrefab;

  void Update () {
    if (Input.touchCount > 0 && GlobalData.globalData.interactable == true && GlobalData.globalData.canPickupFood) {
      Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

      if (this.GetComponent<Collider2D>() != null && GetComponent<Collider2D>().OverlapPoint(worldPoint)) {
        Rigidbody2D foodInstance;
        foodInstance = Instantiate(foodPrefab, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
        foodInstance.transform.localScale = foodInstance.transform.localScale;
        Destroy(GetComponent<Collider2D>());
        GetComponent<SpriteRenderer>().enabled = false;
        GlobalData.globalData.foodTakenOutOfFridge += 1;
      }
    }
  }
}