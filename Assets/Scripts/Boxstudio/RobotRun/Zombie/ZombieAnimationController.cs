using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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