using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {
  public static GlobalData globalData { get; set; }
  public int score { get; set; }
  public List<Rigidbody2D> foodPool = new List<Rigidbody2D>();

  void Awake () {
    if (globalData == null) {
      DontDestroyOnLoad(gameObject);
      globalData = this;
    } else if (globalData != this) {
      Destroy(gameObject);
    }
  }
}