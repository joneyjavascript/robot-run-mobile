using UnityEngine;

namespace Boxstudio.RobotRun.Managers {
  public class GameManager : MonoBehaviour {

    public static GameManager instance;


    void Start(){
      if(instance != null){
        GameObject.Destroy(gameObject);
        return;
      } else {
        instance = this;
        DontDestroyOnLoad(gameObject);
      }
    }

    void Update(){

    }

  }
}
