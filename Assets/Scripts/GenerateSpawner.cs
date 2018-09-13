using UnityEngine;
using UnityEngine.UI;

public class GenerateSpawner : MonoBehaviour {
  public GameObject foodSpawner;

  public void buttonClick () {
    GameObject fridgeButton = GameObject.Find("Refrigerator");
    GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

    if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "OPEN") {
      for (int i = 0; i < spawners.Length; i++) {
        GameObject foodSpawnerInstance;
        foodSpawnerInstance = Instantiate(foodSpawner, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
      }
    }
  }

  public static void handleOpenClose (GameObject fridgeButton) {
    if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "OPEN") {
      fridgeButton.GetComponentsInChildren<Text>()[0].text = "CLOSE";
    } else if (fridgeButton.GetComponentsInChildren<Text>()[0].text == "CLOSE") {
      fridgeButton.GetComponentsInChildren<Text>()[0].text = "OPEN";
    }
  }
}