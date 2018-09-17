using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
  public void onPress () {
    string pressedButton = EventSystem.current.currentSelectedGameObject.name;

    if (pressedButton == "Shop") {
      SceneManager.LoadScene("FoodPurchase", LoadSceneMode.Single);
    }

    Helpers.endScoreRun();
  }
}