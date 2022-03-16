using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Boxstudio.RobotRun.Zombie {

  public partial class ZombieController : MonoBehaviour, IKill, IDead  {

    public bool isMoving { get { return _isMoving; } }
    public bool faceToRight { get { return _faceToRight; } }

    Rigidbody2D _body;
    bool _isMoving = false;
    bool _faceToRight = false;
    float _movingSensibility = .2f;

    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;

    void Start(){
      _body = GetComponent<Rigidbody2D>();
      boxCollider = GetComponent<BoxCollider2D>();
      circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update(){
      _isMoving = Mathf.Abs(_body.velocity.x) > _movingSensibility;
      _faceToRight = _isMoving ? _body.velocity.x >= 0 : _faceToRight;
      UpdateAttanking();
    }

  }
}