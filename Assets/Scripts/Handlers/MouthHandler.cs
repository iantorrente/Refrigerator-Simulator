using UnityEngine;

public class MouthHandler : MonoBehaviour {
  private Animator animator { get; set; }
  void Start () {
    animator = GameObject.Find("Face Bottom").GetComponent<Animator>();
  }

  private void OnTriggerEnter2D (Collider2D other) {
    if (other.GetComponent<FoodValue>()) {
      animator.SetBool("canChomp", true);
    }
  }

  private void Update () {
    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Chomp_Anim")) {
      animator.SetBool("canChomp", false);
    }
  }
}