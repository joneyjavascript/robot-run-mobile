using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace Boxstudio.RobotRun.Saw {

  public partial class SawAnimationController : MonoBehaviour, IKill {

    [SerializeField] float _rotateSpeed = 5f;

    void Update(){
      transform.Rotate(new Vector3(0, 0, _rotateSpeed), Space.Self);
    }
  }
}