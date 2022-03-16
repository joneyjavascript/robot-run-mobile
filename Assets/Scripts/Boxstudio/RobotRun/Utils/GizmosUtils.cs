using UnityEngine;

namespace Boxstudio.RobotRun.Utils {
  public class GizmosUtils {

    public static void SetColor(Color color){
      #if UNITY_EDITOR
       UnityEditor.Handles.color = color;
      #endif
    }

    public static void DrawCircle(Vector2 position, float radius){
      DrawCircle(new Circle(position, radius));
    }

    public static void DrawCircle(Circle circle){
      #if UNITY_EDITOR
        UnityEditor.Handles.DrawWireDisc(circle.position, Vector3.back, circle.radius);
      #endif
    }
  }
}