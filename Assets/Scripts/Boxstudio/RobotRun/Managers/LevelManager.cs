using UnityEngine;

using Boxstudio.RobotRun.Player;
using Boxstudio.RobotRun.Utils;

namespace Boxstudio.RobotRun.Managers {

  public enum LevelManagerState { WaitingPlayerStart, Running, RestartingLevel, EndingLevel };

  public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    LevelManagerState currentState = LevelManagerState.WaitingPlayerStart;
    GameObject player;
    PlayerController playerController;

    void Start(){
      player = GameObject.FindGameObjectWithTag("Player");
      playerController = player.GetComponent<PlayerController>();
      instance = this;
    }

    void Update(){
      if(currentState == LevelManagerState.Running){
        if(playerController.isDead){
          RestartLevel();
          AdsManager.instance.CountDownAds();
        }
      }

      if(currentState == LevelManagerState.WaitingPlayerStart){
        if(Input.anyKey){
          currentState = LevelManagerState.Running;
        }
      }
    }

    void RestartLevel(){
      currentState = LevelManagerState.RestartingLevel;
      SceneTransitionManager.instance.TransitionTo(SceneUtils.GAMEPLAY);
    }

    public void EndLevel(){
      currentState = LevelManagerState.EndingLevel;
      ScoreManager.instance.StopRecordingLevelTime();
      SceneTransitionManager.instance.TransitionTo(SceneUtils.CLEARED_LEVEL);
    }
  }
}