using UnityEngine;

public class MouthHandler : MonoBehaviour {
  private Animator animator { get; set; }
  void Start () {
    animator = GameObject.Find("Face Bottom").GetComponent<Animator>();
  }

  private void OnTriggerEnter2D (Collider2D other) {
    Debug.Log("Food entered");
    if (other.GetComponent<FoodValue>()) {
      animator.SetBool("canChomp", true);
    }
  }

  private void Update () {
    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mouth (Eat)")) {
      animator.SetBool("canChomp", false);
    }
  }
}