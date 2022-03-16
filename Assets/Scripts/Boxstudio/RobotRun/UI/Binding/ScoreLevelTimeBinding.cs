
using UnityEngine;

using TMPro;

using Boxstudio.RobotRun.Utils;
using Boxstudio.RobotRun.Managers;

namespace Boxstudio.RobotRun.UI.Bindings {

  public class ScoreLevelTimeBinding : MonoBehaviour {

    private TextMeshProUGUI text;

    void Start(){
      text = GetComponent<TextMeshProUGUI>();
    } 

    void Update(){
      string formated = FormatUtils.TimeValue(ScoreManager.instance.levelTime);
      text.text = formated;
    }
  }
}