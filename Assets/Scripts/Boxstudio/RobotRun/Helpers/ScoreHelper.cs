using UnityEngine;

using Boxstudio.RobotRun.Managers;

namespace Boxstudio.RobotRun.Helpers {

  public class ScoreHelper : MonoBehaviour {

    public void NewDeath(){
      ScoreManager.instance.NewDeath();
    }

    public void NewKill(){
      ScoreManager.instance.NewKill();
    }
  }
}