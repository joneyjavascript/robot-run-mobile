using System;
using UnityEngine;

namespace Boxstudio.RobotRun.Utils {
  public class FormatUtils {
    public static string ScoreValue(int value){
      return value.ToString().PadLeft(3, '0');
    }

    public static string TimeValue(float value){
      return  Mathf.Floor(value / 60f).ToString().PadLeft(2, '0') + ":" + Mathf.Floor(value % 60).ToString().PadLeft(2, '0');
    }
  }
}