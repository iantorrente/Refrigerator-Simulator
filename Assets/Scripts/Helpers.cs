using System;
using System.Collections;
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
  public static void showAchievement(Achievement ach){
    GameObject achBoard = GameObject.Find("Achboard");
    Console.WriteLine(ach.achievementName);
    achBoard.GetComponent<Text>().text = ach.achievementName;
  
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

  public static void updateMultiplierText () {
    GameObject multiplierboard = GameObject.Find("Multiplierboard");
    multiplierboard.GetComponent<Text>().enabled = true;
    multiplierboard.GetComponent<Text>().text = ("x" + GlobalData.globalData.scoreMultiplier);
  }

  public static void increaseFoodEaten () {
    GlobalData.globalData.foodInScoreRun += 1;
    GlobalData.globalData.totalFoodEaten += 1;
    checkMultiplier();
  }

  public static void increaseFoodDiscarded () {
    GlobalData.globalData.totalFoodDiscarded += 1;
  }

  private static void checkMultiplier () {
    int foodInScoreRun = GlobalData.globalData.foodInScoreRun;

    if (foodInScoreRun > 1 && foodInScoreRun <= 10) {
      GlobalData.globalData.scoreMultiplier = 1.25f;
    } else if (foodInScoreRun > 10 && foodInScoreRun <= 25) {
      GlobalData.globalData.scoreMultiplier = 1.50f;
    } else if (foodInScoreRun > 25 && foodInScoreRun <= 50) {
      GlobalData.globalData.scoreMultiplier = 2.0f;
    } else if (foodInScoreRun > 50 && foodInScoreRun <= 100) {
      GlobalData.globalData.scoreMultiplier = 2.75f;
    } else if (foodInScoreRun > 100) {
      GlobalData.globalData.scoreMultiplier = 3.75f;
    }

    decreaseTimer();
    updateMultiplierText();
  }

  private static void decreaseTimer () {
    float multiplier = GlobalData.globalData.scoreMultiplier;

    if (multiplier >= 1.25f || multiplier < 1.50f) {
      GlobalData.globalData.maxScoreRunTime = 10.0f;
    } else if (multiplier >= 1.50f || multiplier < 2.0f) {
      GlobalData.globalData.maxScoreRunTime = 9.0f;
    } else if (multiplier >= 2.0f || multiplier < 2.75f) {
      GlobalData.globalData.maxScoreRunTime = 7.5f;
    } else if (multiplier >= 2.75f || multiplier < 3.75f) {
      GlobalData.globalData.maxScoreRunTime = 4.5f;
    } else if (multiplier == 3.75f) {
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

  public static T CopyComponent<T>(T original, GameObject destination) where T : Component {
     System.Type type = original.GetType();
     Destroy(destination.GetComponent(type));
     Component copy = destination.AddComponent(type);
     System.Reflection.FieldInfo[] fields = type.GetFields();
     foreach (System.Reflection.FieldInfo field in fields) {
        field.SetValue(copy, field.GetValue(original));
     }
     return copy as T;
 }
}