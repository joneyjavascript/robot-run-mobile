

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Boxstudio.RobotRun.Level {
  public class DeadZone : MonoBehaviour, IKill {

    public bool isAttacking { get { return true;  }}

    void OnTriggerEnter2D(Collider2D other){
      IDead otherDead = other.gameObject.GetComponent<IDead>();
      
      if(otherDead != null){
        otherDead.Dead(this);
      }
    }

  }
}
