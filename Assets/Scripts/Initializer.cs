using UnityEngine;
using UnityEngine.UI;

//A class that initializes game objects, UI, etc. to the desired initial positions/states
//so that if we forget to enable/disable something in the editor it will always be in its
//intended state. The class is destroyed once it's done initializing everything
public class Initializer : MonoBehaviour {
  void Start () {
    GameObject multiplierboard = GameObject.Find("Multiplierboard");
    GameObject refrigeratorDoor = GameObject.FindWithTag("Refrigerator Door");

    multiplierboard.GetComponent<Text>().enabled = false;
    refrigeratorDoor.GetComponent<SpriteRenderer>().enabled = true;

    Destroy(this.gameObject);
  }
}