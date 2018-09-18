using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {
  public static GlobalData globalData { get; set; }
  public bool interactable = false;
  public double money;
  public int score { get; set; }
  public int highScore { get; set; }
  public float maxScoreRunTime = 10.0f; //As the timer goes on decrease this
  public float scoreRunTime = 3.0f; //When this gets reset set it to maxScoreRunTime
  public List<Rigidbody2D> foodPool = new List<Rigidbody2D>();
  public List<Rigidbody2D> allFoodItems = new List<Rigidbody2D>();

  void Awake () {
    if (globalData == null) {
      DontDestroyOnLoad(gameObject);
      globalData = this;
    } else if (globalData != this) {
      Destroy(gameObject);
    }
  }
}