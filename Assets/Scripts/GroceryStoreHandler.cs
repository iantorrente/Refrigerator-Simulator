using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GroceryStoreHandler : MonoBehaviour {
  public GameObject[] panels;
  GameObject currentPanel { get; set; }
  GameObject purchaseModal { get; set; }
  GameObject expensiveModal { get; set; }
  GameObject selectedFood { get; set; }
  GameObject purchasePrompt { get; set; }
  GameObject moneyDisplay { get; set; }
  Button[] activeButtons { get; set; }
  EventSystem eventSystem { get; set; }

  private void Start () {
    eventSystem = EventSystem.current;
    getActiveButtons();
    initializePanels();
    initializeMoneyDisplay();
  }

  public void onPress () {
    string pressedButton = eventSystem.currentSelectedGameObject.name;
    int currentPanelIndex = Array.IndexOf(panels, currentPanel);

    if (pressedButton == "NextList") {
      int nextPanelIndex = currentPanelIndex + 1;
      
      if (currentPanelIndex != panels.Length - 1) {
        panels[currentPanelIndex].SetActive(false);
        panels[nextPanelIndex].SetActive(true);
        currentPanel = panels[nextPanelIndex];
        getActiveButtons();
      }
    } else if (pressedButton == "PrevList") {
      int prevPanelIndex = currentPanelIndex - 1;

      if (currentPanelIndex != 0) {
        panels[currentPanelIndex].SetActive(false);
        panels[prevPanelIndex].SetActive(true);
        currentPanel = panels[prevPanelIndex];
        getActiveButtons();
      }
    }

    if (pressedButton == "PurchaseButton") {
      handlePurchase();
      handleModal(purchaseModal);
    } else if (pressedButton == "CancelButton") {
      handleModal(purchaseModal);
    } else if (pressedButton == "CancelExpensiveButton") {
      handleModal(expensiveModal);
    }
  }

  private void initializePanels () {
    purchasePrompt = GameObject.Find("PurchasePrompt");

    //Deactivate all panels
    for (int i = 0; i < panels.Length; i++) {
      Debug.Log(i + ") " + panels[i].name);
      panels[i].SetActive(false);
    }
    expensiveModal = GameObject.Find("Expensive Modal");
    expensiveModal.SetActive(false);
    purchaseModal = GameObject.Find("Purchase Modal");
    purchaseModal.SetActive(false);


    //Reactivate panel 1
    panels[0].SetActive(true);
    currentPanel = panels[0];
    Debug.Log("Current panel index: " + currentPanel.name);
  }

  private void initializeMoneyDisplay () {
    moneyDisplay = GameObject.Find("Player Money");
    updateMoneyDisplay ();
  }

  private void updateMoneyDisplay () {
    moneyDisplay.GetComponent<Text>().text = ("$" + String.Format("{0:0.00}", GlobalData.globalData.money));
  }

  public void handleFoodClick () {
      string pressedObject = eventSystem.currentSelectedGameObject.name;
      selectedFood = FoodItems.getFoodItem(pressedObject);
      deactivateButtons();
      handleModal(purchaseModal);
      
      Debug.Log(selectedFood.GetComponent<FoodValue>().foodName);
  }

  private void handleModal (GameObject modal) {
    if (!modal.active) {
      modal.SetActive(true);
      if (modal.name == "Purchase Modal") {
        purchasePrompt.GetComponent<Text>().text = (
          "PURCHASE " + selectedFood.GetComponent<FoodValue>().foodName.ToUpper() 
          + " FOR $" + selectedFood.GetComponent<FoodValue>().cost + "?");
      }
      activateButtons();
    } else {
      modal.SetActive(false);
      activateButtons();
    }
  }

  private void handlePurchase () {
    double cost = selectedFood.GetComponent<FoodValue>().cost;
    double playerMoney = GlobalData.globalData.money;

    if (playerMoney - cost < 0) {
      handleModal(expensiveModal);
    } else {
      GlobalData.globalData.money -= cost;
      updateMoneyDisplay();
      GlobalData.globalData.foodPool.Add(selectedFood.GetComponent<Rigidbody2D>());
    }
  }

  private void getActiveButtons () {
    activeButtons = GameObject.FindObjectsOfType<Button>();
  }

  private void deactivateButtons () {
    for (int i = 0; i < activeButtons.Length; i++) {
      activeButtons[i].interactable = false;
    }
  }

  private void activateButtons () {
    for (int i = 0; i < activeButtons.Length; i++) {
      activeButtons[i].interactable = true;
    }
  }
}