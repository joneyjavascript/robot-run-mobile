
using UnityEngine;

namespace Boxstudio.RobotRun.Zombie {
  public partial class ZombieController : MonoBehaviour, IKill, IDead  {

    public bool isAttacking { get { return _isAttacking; } }

    bool _isAttacking = false;

    float timeToAttach = 0f;
    [SerializeField] float nextAttackTime = 5f;
    [SerializeField] float endAttackTime = 7f;

    void UpdateAttanking(){
      if(isDead) return;

      timeToAttach += Time.deltaTime;
      if(timeToAttach > nextAttackTime){
        _isAttacking = true;
      }

      if(timeToAttach > endAttackTime){
        timeToAttach = 0;
        _isAttacking = false;
      }
    }
  }
}