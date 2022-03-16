using UnityEngine;

using Boxstudio.RobotRun.Utils;

namespace Boxstudio.RobotRun.Player {

  public partial class PlayerController : MonoBehaviour, IDead {

    [SerializeField] Vector2 runDirection = Vector2.right;
    [SerializeField] float speed = 5f;
    [SerializeField] float dragX = .6f;
    [SerializeField] float dragY = .6f;
    [SerializeField] float _jumpHeight = 5f;
    [SerializeField] LayerMask floorLayerMask;

    public bool inFloor { get { return _inFloor; } }
    public bool inJumping { get { return _inJumping; } }
    public bool isMoving { get { return _isMoving; } }
    public bool faceToRight { get { return _faceToRight; } }

    Rigidbody2D _body;
    bool _inFloor = false;
    bool _inJumping = false;
    bool _isMoving = false;
    bool _faceToRight = true;
    float _movingSensibility = .2f;
    float _timeInFloor = 0;
    float _timeInAir = 0;
    float _timeAfterJump = 0;
    Circle _footsCircle = new Circle();
    PlayerInputController _inputController;
    float _lastJumpTime = 0f;

    void Start(){
      _body = GetComponent<Rigidbody2D>();
      _footsCircle.radius = .2f;
      _inputController = GetComponent<PlayerInputController>();
    }

    void Update(){
      Drag();
      UpdateData();
      FootsCheck();
    }

    void UpdateData(){
      _inputController.freeze = isDead;

      if(_inFloor){
        _timeInFloor += Time.deltaTime;
        _timeInAir = 0;
        _inJumping = false;
        _timeAfterJump = 0;
      } else {
        _timeInAir += Time.deltaTime;
        _timeInFloor = 0;
      }

      if(_inJumping){
        _timeAfterJump += Time.deltaTime;
      }

      _lastJumpTime += Time.deltaTime;

      _isMoving = Mathf.Abs(_body.velocity.x) > _movingSensibility;
      _faceToRight = _isMoving ? _body.velocity.x >= 0 : _faceToRight;

      CheckJump();
    }

    void CheckJump(){
      if(_lastJumpTime <= .2 && !_inJumping){
        if(!_inFloor && (_timeInAir > .2f || _inJumping)) return;

        _body.velocity = Vector2.up * _jumpHeight;
        _inJumping = true;
      }
    }

    void Drag(){
      _body.velocity = new Vector2(_body.velocity.x * dragX, _body.velocity.y * dragY);
    }

    void FootsCheck(){
      _footsCircle.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(0f, -1f);
      Collider2D[] footCollider = Physics2D.OverlapCircleAll(_footsCircle.position, _footsCircle.radius, floorLayerMask);
      if(footCollider?.Length > 0){
        _inFloor = true;
        return;
      } 

      _inFloor = false;
    }

    public void MoveLeft(){
      _body.velocity += Vector2.left * speed;
    }

    public void MoveRight(){
      _body.velocity += Vector2.right * speed;
    }

    public void Jump(){
      _lastJumpTime = 0f;
    }

    void OnDrawGizmos(){
      GizmosUtils.SetColor(Color.yellow);
      GizmosUtils.DrawCircle(_footsCircle);
    }
  }
}