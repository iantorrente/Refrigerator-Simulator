using UnityEngine;

public class LetterboxHandler : MonoBehaviour {
  void Start () {
    Camera mainCamera = this.GetComponent<Camera>();
    float deviceWidth = Screen.width;
    float deviceHeight = Screen.height;
    float aspectRatio = deviceWidth / deviceHeight;

    if (aspectRatio < 0.5) {
      mainCamera.orthographicSize = 7f;
    }
  }
}