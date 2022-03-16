using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

using Boxstudio.RobotRun.Managers;

namespace Boxstudio.RobotRun.Player {

  public partial class PlayerController : MonoBehaviour, IDead {

    bool _isInvecible = false;
    public bool isInvecible { get { return _isInvecible; } }

    bool _isDead;
    public bool isDead { get { return _isDead; } }

    [SerializeField] UnityEvent OnDead;

    void OnCollisionEnter2D(Collision2D other){
      IKill killer = other.gameObject.GetComponent<IKill>();
      if(killer != null && killer.isAttacking){
        Dead(killer);
      }
    }

    public void Dead(IKill killer){
      if(_isInvecible) return;

      _isDead = true;
      OnDead?.Invoke();
    }

  }
}