using UnityEngine;

using TMPro;

using Boxstudio.RobotRun.Utils;
using Boxstudio.RobotRun.Managers;


namespace Boxstudio.RobotRun.UI.Bindings {

  public class ScoreDeathsBinding : MonoBehaviour {

    private TextMeshProUGUI text;

    void Start(){
      text = GetComponent<TextMeshProUGUI>();
    } 

    void Update(){
      string formated = FormatUtils.ScoreValue(ScoreManager.instance.deaths);
      text.text = formated;
    }
  }
}