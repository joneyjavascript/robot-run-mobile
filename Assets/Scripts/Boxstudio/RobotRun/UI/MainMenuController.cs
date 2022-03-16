using UnityEngine;
using UnityEngine.UI;

using Boxstudio.RobotRun.Utils;
using Boxstudio.RobotRun.Helpers;
using Boxstudio.RobotRun.Managers;

namespace Boxstudio.RobotRun.UI {

  public class MainMenuController : MonoBehaviour {

    private Button playButton;

    void Start(){
      playButton = transform.Find("ButtonPlay").GetComponent<Button>();
      playButton.onClick.AddListener(StartGame);
    } 

    void StartGame(){
      ScoreManager.instance.Reset();
      ScoreManager.instance.StartRecordingLevelTime();
      SceneHelper.LoadScene(SceneUtils.GAMEPLAY);
    }
  }
}