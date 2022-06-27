using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _currentForceJump;

    private float _minForceJump = 1;
    private float _minSpeed = 2;
   [SerializeField] private bool _isGrounded;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void OnValidate()
    {
        if(_currentForceJump <= 0)
        {
            _currentForceJump = _minForceJump;
        }
        if(_speed <= 0)
        {
            _speed = _minSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
        _animator.SetBool(PlayerMovementController.Params.Jump, PlayerMovementController.States.OnTheGround);
    }

    private void Move()
    {
        bool isReadyToJump = Input.GetAxis("Vertical") > 0 & _isGrounded;

        if (Input.GetAxis("Horizontal") != 0)
        {
            _spriteRenderer.flipX = Input.GetAxis("Horizontal") >= 0 ? false : true;
            _animator.SetFloat(PlayerMovementController.Params.Speed, PlayerMovementController.States.Walk);
        }
        else
        {
            _animator.SetFloat(PlayerMovementController.Params.Speed, PlayerMovementController.States.Idle);
        }

        
        transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0, 0);

        if (isReadyToJump)
        {
            _rigidbody2D.AddForce(new Vector2(0, _minForceJump * _currentForceJump));
            _isGrounded = false;
            _animator.SetBool(PlayerMovementController.Params.Jump, PlayerMovementController.States.InTheAir);
        }
    }
}
