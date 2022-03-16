using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Boxstudio.RobotRun.UI; 

namespace Boxstudio.RobotRun.Player {

  public class PlayerInputController : MonoBehaviour {

    PlayerController controller;

    [SerializeField] GameObject mobileGamepadCanvas;
    [SerializeField] float joySensibility = .1f;

    FloatingJoystick floatingJoystick;
    MobileButton jumpButton;
    bool _freeze = false;
    public bool freeze { get { return _freeze; } set { _freeze = value; }}

    void Start(){
      controller = GetComponent<PlayerController>();
      floatingJoystick = mobileGamepadCanvas.GetComponentInChildren<FloatingJoystick>();
      jumpButton = mobileGamepadCanvas.transform.Find("JumpButton").GetComponent<MobileButton>();
      jumpButton.onClick.AddListener(() => {
        if(freeze) return;

        controller.Jump();
      });
    }

    void Update(){
      UpdateControls();
    }

    void UpdateControls(){
      if(_freeze) return;

      if(floatingJoystick.Direction.x < -joySensibility){
        controller.MoveLeft();
      }

      if(floatingJoystick.Direction.x > joySensibility){
        controller.MoveRight();
      }

      if(Input.GetKeyDown(KeyCode.W)){
        controller.Jump();
      }

      if(Input.GetKey(KeyCode.A) ){
        controller.MoveLeft();
      }

      if(Input.GetKey(KeyCode.D)){
        controller.MoveRight();
      }
    }
  }
}