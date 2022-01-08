using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animatorController;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _camera;
    [SerializeField] private FixedJoystick _joystick;

    public float _walkSpeend;
    public float _runningSpeed;
    public float _directionSpeed;
    public float _mass;
    public bool _isRun = false;
    public bool _isMobile;

    private Vector3 _moveDirection;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    void Update()
    {
        Move();
        MassCharacter();
        Jump();
    }

    void Move()
    {        
        if(_isMobile)
        {
            horizontalInput = _joystick.Horizontal;
            verticalInput = _joystick.Vertical;
        } 
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run(horizontalInput, verticalInput);
            }
            else
            {
                Walk(horizontalInput, verticalInput);
            }
        }
        RunAnimation();
        WalkAnimation();
    }

    void Walk(float horizontalInput, float verticalInput)
    {
        _moveDirection = Direction(horizontalInput, verticalInput);
        _characterController.Move(_moveDirection.normalized * Time.deltaTime * _walkSpeend);
    }

    void Run(float horizontalInput, float verticalInput)
    {
        _moveDirection = Direction(horizontalInput, verticalInput);
        _characterController.Move(_moveDirection.normalized * Time.deltaTime * _runningSpeed);
    }

    Vector3 Direction(float horizontal, float vertical)
    {
        float targeAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        Quaternion direction = Quaternion.Euler(0f, targeAngle, 0f);
        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, direction, Time.deltaTime * _directionSpeed);
        return direction * Vector3.forward;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpAnimation();
        }
    }

    void MassCharacter()
    {
        _characterController.Move(Vector3.down * Time.deltaTime * _mass);
    }

    void RunAnimation()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animatorController.SetBool("run", true);
                SlideAnimation();
            }
        }
        else
        {
            _animatorController.SetBool("run", false);
        }
    }

    void WalkAnimation()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            _animatorController.SetBool("walking", true);
        }
        else 
        {
            _animatorController.SetBool("walking", false);
        }
    }

    void JumpAnimation()
    {
        _animatorController.SetBool("jump", true);
    }

    void SlideAnimation()
    {
        if (Input.GetKey(KeyCode.E)) _animatorController.SetBool("slide", true);
    }
}
