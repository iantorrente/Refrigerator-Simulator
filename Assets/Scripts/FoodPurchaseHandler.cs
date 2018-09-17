using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodPurchaseHandler : MonoBehaviour {
  GameObject[] panels { get; set; }
  GameObject currentPanel { get; set; }

  private void Start () {
    initializePanels();
  }

  public void onPress () {
    string pressedButton = EventSystem.current.currentSelectedGameObject.name;
    string[] splitPanelName = currentPanel.name.Split(' ');
    int currentPanelIndex = Array.IndexOf(panels, currentPanel);

    if (pressedButton == "NextList") {
      int nextPanelIndex = currentPanelIndex - 1;
      
      //The last panel is at index 0
      if (currentPanelIndex != 0) {
        panels[currentPanelIndex].SetActive(false);
        panels[nextPanelIndex].SetActive(true);
        currentPanel = panels[nextPanelIndex];
      }
    } else if (pressedButton == "PrevList") {
      int prevPanelIndex = currentPanelIndex + 1;

      //The first panel is at the length of the panel array - 1 index
      if (currentPanelIndex != panels.Length - 1) {
        panels[currentPanelIndex].SetActive(false);
        panels[prevPanelIndex].SetActive(true);
        currentPanel = panels[prevPanelIndex];
      }
    }
  }

  private void initializePanels () {
    panels = GameObject.FindGameObjectsWithTag("Food List");
    
    //Deactivate all panels
    for (int i = 0; i < panels.Length; i++) {
      Debug.Log(i + ") " + panels[i].name);
      panels[i].SetActive(false);
    }

    //Reactivate panel 1
    panels[panels.Length - 1].SetActive(true);
    currentPanel = panels[panels.Length - 1];
    Debug.Log("Current panel index: " + currentPanel.name);
  }
}