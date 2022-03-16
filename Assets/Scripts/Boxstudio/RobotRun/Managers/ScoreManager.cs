using UnityEngine;

namespace Boxstudio.RobotRun.Managers {
  public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    [SerializeField] int _deaths = 0;
    [SerializeField] int _kills = 0;
    [SerializeField] float _levelTime = 0;
    [SerializeField] float _startLevelTime = 0;
    [SerializeField] float _endLevelTime = 0;
    
    public int deaths { get { return _deaths; } set { _deaths = value; } }
    public int kills { get { return _kills; } set { _kills = value; } }
    public float levelTime { get { return _levelTime; } set { _levelTime = value; } }

    void Awake(){
      if(instance == null){
        instance = this;
      }
    }

    public void Reset(){
      deaths = 0;
      kills = 0;
      levelTime = 0;
    }

    public void NewKill(){
      kills++;
    }

    public void NewDeath(){
      deaths++;
    }

    public void StartRecordingLevelTime(){
      _startLevelTime = Time.realtimeSinceStartup;
    }

    public void StopRecordingLevelTime(){
      _endLevelTime = Time.realtimeSinceStartup;
      levelTime = _endLevelTime - _startLevelTime;
    }
  }
}
