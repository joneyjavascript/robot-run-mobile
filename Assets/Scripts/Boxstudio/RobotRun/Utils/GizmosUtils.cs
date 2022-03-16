using UnityEngine;

namespace Boxstudio.RobotRun.Utils {
  public class GizmosUtils {

    public static void SetColor(Color color){
       UnityEditor.Handles.color = color;
    }

    public static void DrawCircle(Vector2 position, float radius){
      DrawCircle(new Circle(position, radius));
    }

    public static void DrawCircle(Circle circle){
      UnityEditor.Handles.DrawWireDisc(circle.position, Vector3.back, circle.radius);
    }
  }
}