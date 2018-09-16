using System;
using UnityEngine;
using UnityEngine.UI;

public class Helpers : MonoBehaviour {
  private static void updateScoreboard () {
    int score = GlobalData.globalData.score;
    GameObject scoreboard = GameObject.Find("Scoreboard");
    scoreboard.GetComponent<Text>().text = (score.ToString());
  }

  private static void updateMoneyboard () {
    double money = GlobalData.globalData.money;
    GameObject moneyboard = GameObject.Find("Moneyboard");
    moneyboard.GetComponent<Text>().text = ("$" + String.Format("{0:0.00}", money));
  }

  public static void increaseScore (int value) {
    GlobalData.globalData.score += value;
    int score = GlobalData.globalData.score;
    updateScoreboard();
  }

  public static void restartScore () {
    GlobalData.globalData.score = 0;
    updateScoreboard();
  }

  public static void updateTimerText (int time) {
    GameObject timer = GameObject.Find("Timer Text");
    timer.GetComponent<Text>().enabled = true;
    timer.GetComponent<Text>().text = ((time + 1).ToString());
  }

  public static void disableTimerText () {
    GameObject timer = GameObject.Find("Timer Text");
    timer.GetComponent<Text>().enabled = false;
  }

  public static void startScoreRun() {
    GlobalData.globalData.scoreRunTime = 3.0f;
    //Adding the component to the game object 'Timer' starts the timer
    if (!GameObject.Find("Timer").GetComponent<Timer>()) {
      GameObject.Find("Timer").AddComponent<Timer>();
    }
  }

  public static void endScoreRun () {
    disableTimerText();
    rewardMoney();
    setHighScore();
    restartScore();
  }

  public static void setHighScore () {
    int currentScore = GlobalData.globalData.score;
    int currentHighScore = GlobalData.globalData.highScore;

    if (currentScore > currentHighScore) {
      GlobalData.globalData.highScore = currentScore;
      Debug.Log("NEW HIGH SCORE OF: " + currentScore);
    }
  } 

  public static void rewardMoney () {
    int score = GlobalData.globalData.score;
    double money = (score * 0.01);
    GlobalData.globalData.money += money;

    updateMoneyboard();
    Debug.Log("Rewarded: $" + money);
  }

  private static string parseScore (int score) {
    string parsedScore = "";

    return parsedScore;
  }
}