using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
  public void onPress () {
    string pressedButton = EventSystem.current.currentSelectedGameObject.name;

    if (pressedButton == "Shop") {
      SceneManager.LoadScene("FoodPurchase", LoadSceneMode.Single);
    } else if (pressedButton == "BackButton") {
      SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    //Whatever condition it takes to end the score run, just end it before moving scenes
    if (GlobalData.globalData.score != 0) {
      Helpers.endScoreRun();
    }
  }
}