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
    float multiplier = GlobalData.globalData.scoreMultiplier;
    GlobalData.globalData.score += (int)(Math.Ceiling(value * multiplier));
    updateScoreboard();
  }

  public static void restartScore () {
    GlobalData.globalData.score = 0;
    updateScoreboard();
  }

  private static void updateMultiplierText () {
    GameObject multiplierboard = GameObject.Find("Multiplierboard");
    multiplierboard.GetComponent<Text>().enabled = true;
    multiplierboard.GetComponent<Text>().text = ("x" + GlobalData.globalData.scoreMultiplier);
  }

  public static void increaseFoodInScoreRun () {
    GlobalData.globalData.foodInScoreRun += 1;
    checkMultiplier();
  }

  private static void checkMultiplier () {
    int foodInScoreRun = GlobalData.globalData.foodInScoreRun;
    Debug.Log(foodInScoreRun);

    if (foodInScoreRun > 1 && foodInScoreRun <= 10) {
      GlobalData.globalData.scoreMultiplier = 1.10f;
    } else if (foodInScoreRun > 10 && foodInScoreRun <= 25) {
      GlobalData.globalData.scoreMultiplier = 1.15f;
    } else if (foodInScoreRun > 25 && foodInScoreRun <= 50) {
      GlobalData.globalData.scoreMultiplier = 1.25f;
    } else if (foodInScoreRun > 50 && foodInScoreRun <= 100) {
      GlobalData.globalData.scoreMultiplier = 1.40f;
    } else if (foodInScoreRun > 100) {
      GlobalData.globalData.scoreMultiplier = 1.75f;
    }

    decreaseTimer();
    updateMultiplierText();
  }

  private static void decreaseTimer () {
    float multiplier = GlobalData.globalData.scoreMultiplier;

    if (multiplier == 1.0f) {
      GlobalData.globalData.maxScoreRunTime = 10.0f;
    } else if (multiplier == 1.1f) {
      GlobalData.globalData.maxScoreRunTime = 9.0f;
    } else if (multiplier == 1.15f) {
      GlobalData.globalData.maxScoreRunTime = 7.5f;
    } else if (multiplier == 1.25f) {
      GlobalData.globalData.maxScoreRunTime = 6.0f;
    } else if (multiplier == 1.40f) {
      GlobalData.globalData.maxScoreRunTime = 4.5f;
    } else if (multiplier == 1.75f) {
      GlobalData.globalData.maxScoreRunTime = 2.0f;
    }
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
    GlobalData.globalData.scoreRunTime = GlobalData.globalData.maxScoreRunTime;
    //Adding the component to the game object 'Timer' starts the timer
    if (!GameObject.Find("Timer").GetComponent<ScoreRunTimer>()) {
      GameObject.Find("Timer").AddComponent<ScoreRunTimer>();
    }
  }

  public static void endScoreRun () {
    disableTimerText();
    rewardMoney();
    setHighScore();
    restartScore();
    GlobalData.globalData.scoreMultiplier = 1.0f;
    updateMultiplierText();
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