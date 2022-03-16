using UnityEngine;
using Boxstudio.RobotRun.Utils;
using Boxstudio.RobotRun.Managers;

namespace Boxstudio.RobotRun.Helpers {

  public class SceneHelper : MonoBehaviour {

    public void StartGameplay(){
      ScoreManager.instance.Reset();
      ScoreManager.instance.StartRecordingLevelTime();
      LoadScene(SceneUtils.GAMEPLAY);
    }

    public void RestartLevel(){
      LoadScene(SceneUtils.GAMEPLAY);
    }

    public void BackToTitle(){
      LoadScene(SceneUtils.MAIN_MENU);
    }

    public static void LoadScene(string sceneName){
      SceneTransitionManager.instance.TransitionTo(sceneName);
    }
  }
}