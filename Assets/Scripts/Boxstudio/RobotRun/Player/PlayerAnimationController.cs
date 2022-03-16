using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Boxstudio.RobotRun.Player {

  [RequireComponent(typeof(PlayerController))]
  public class PlayerAnimationController : MonoBehaviour {

    Animator animator;
    SpriteRenderer spriteRenderer;
    PlayerController playerController;

    void Start(){
      animator = GetComponentInChildren<Animator>();
      playerController = GetComponent<PlayerController>();
      spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update(){
      animator.SetBool("inFloor", playerController.inFloor);
      animator.SetBool("inJumping", playerController.inJumping);
      animator.SetBool("isMoving", playerController.isMoving);
      animator.SetBool("isDead", playerController.isDead);
      
      spriteRenderer.flipX = !playerController.faceToRight;
    }

  }
}

