using UnityEngine;
using UnityEngine.UI;

public class Helpers : MonoBehaviour {
  public static void updateScore (int value) {
    GlobalData.globalData.score += value;
    int score = GlobalData.globalData.score;
    GameObject scoreboard = GameObject.Find("Scoreboard");
    scoreboard.GetComponent<Text>().text = ("SCORE: " + score);
  }
}