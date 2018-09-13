using UnityEngine;

public class FoodSpawner : MonoBehaviour {
  public Rigidbody2D foodPrefab;

  void Update () {
    //Need to do a check that the player isn't holding an item with that finger
    if (Input.touchCount > 0) {
      Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
      Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);

      if (GetComponent<Collider2D>().OverlapPoint(touchPos)) {
        Rigidbody2D foodInstance;
        foodInstance = Instantiate(foodPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        Destroy(GetComponent<Collider2D>());
        GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Touching foods pawner");
      }
    }
  }
}