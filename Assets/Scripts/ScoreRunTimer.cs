using System;
using UnityEngine;

public class ScoreRunTimer : MonoBehaviour {
  public ScoreRunTimer timer { get; set; }

  void Update () {
    GlobalData.globalData.scoreRunTime -= Time.deltaTime;
    Helpers.updateTimerText((int)GlobalData.globalData.scoreRunTime);

    if (GlobalData.globalData.scoreRunTime < 0) {
      Helpers.endScoreRun();
      Destroy(this);
      //End the score run here
    }
  }

  void Awake () {
    if (timer == null) {
      DontDestroyOnLoad(gameObject);
      timer = this;
    } else if (timer != this) {
      Destroy(gameObject);
    }
  }
}