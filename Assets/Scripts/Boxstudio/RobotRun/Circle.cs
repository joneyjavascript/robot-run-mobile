using UnityEngine;
namespace Boxstudio.RobotRun {
  public class Circle {
    public Vector2 position = Vector2.zero;
    public float radius = 1f;

    public Circle(){}

    public Circle(Vector2 position, float radius=1f){
      this.position = position;
      this.radius = radius;
    }
  }
}