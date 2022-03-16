
using UnityEngine;
using UnityEngine.Events;

using Boxstudio.RobotRun.Managers;

namespace Boxstudio.RobotRun.Zombie {
  public partial class ZombieController : MonoBehaviour, IKill, IDead {

    bool _isInvecible = false;
    public bool isInvecible { get { return _isInvecible; } }

    [SerializeField] float _deadExplosionForce = 5f;

    bool _isDead;
    public bool isDead { get { return _isDead; } }

    [SerializeField] UnityEvent OnDead;

    void OnCollisionEnter2D(Collision2D other){
      IKill killer = other.gameObject.GetComponent<IKill>();
      if(killer != null && killer.isAttacking){
        Dead(killer);
      }
    }

    public void Dead(IKill killer){
      // Kill Effect
      Vector3 direction = (((MonoBehaviour)killer).transform.position - transform.position).normalized;
      _body.velocity = direction * _deadExplosionForce;

      if(_isInvecible) return;

      // Dead Logic
      if(!_isDead) {
        _isDead = true;
        boxCollider.enabled = false;
        circleCollider.enabled = true;
        ScoreManager.instance.NewKill();
        OnDead?.Invoke();
      }
    }
  }
}