using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Boxstudio.RobotRun.Saw {

  public partial class SawAnimationController : MonoBehaviour, IKill {
    public bool isAttacking { get { return true; } }
  }
}