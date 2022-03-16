using UnityEngine;

namespace Boxstudio.RobotRun.Zombie {

  public class ZombieAnimationController : MonoBehaviour {

    Animator animator;
    SpriteRenderer spriteRenderer;
    ZombieController zombieController;

    void Start(){
      animator = GetComponentInChildren<Animator>();
      zombieController = GetComponent<ZombieController>();
      spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update(){
      animator.SetBool("isDead", zombieController.isDead);
      animator.SetBool("isAttacking", zombieController.isAttacking);
      animator.SetBool("isMoving", zombieController.isMoving);
      spriteRenderer.flipX = !zombieController.faceToRight;
    }

  }
}