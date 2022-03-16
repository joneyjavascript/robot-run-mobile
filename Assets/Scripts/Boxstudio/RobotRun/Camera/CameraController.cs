using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Boxstudio.RobotRun.Camera {

  public class CameraController : MonoBehaviour {

    [SerializeField] GameObject _target;
    [SerializeField] Vector3 _offset;
    [SerializeField] Vector3 _targetPosition;
    [SerializeField] Vector3 _nextPosition;
    [SerializeField] bool _lockX = false;
    [SerializeField] bool _lockY = false;

    [SerializeField] float _decay;

    void Update(){
      _targetPosition = _target.transform.position + _offset;
      _nextPosition = transform.position + ((_targetPosition - transform.position) / _decay);
      _nextPosition = new Vector3(
        _lockX ? transform.position.x :_nextPosition.x,
        _lockY ? transform.position.y :_nextPosition.y,
        transform.position.z);
    }

    void LateUpdate(){
      transform.position = _nextPosition;
    }
  }
}