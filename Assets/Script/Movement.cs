using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private Animator _animatorController;

    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Transform _camera;

    private Vector3 _moveDirection;

    public float _speendWalk;
    public float _speendRunning;
    public float _speedDirection;
    public float _mass;

    void Update()
    {
        Move();
        MassCharacter();
        AnimationMovement();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

        if (move.magnitude >= 0.1f)
        {
            _moveDirection = Direction(horizontal, vertical);
            _characterController.Move(_moveDirection.normalized * Time.deltaTime * _speendWalk);
        }
    }

    void MassCharacter()
    {
        _characterController.Move(Vector3.down * Time.deltaTime * _mass);
    }

    Vector3 Direction(float horizontal, float vertical)
    {
        float targeAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        Quaternion direction = Quaternion.Euler(0f, targeAngle, 0f);
        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, direction, Time.deltaTime * _speedDirection);
        return direction * Vector3.forward;
    }

    void AnimationMovement()
    {
        if (
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D)
            )
        {
            _animatorController.SetBool("walking", true);
        } 
        else
        {
            _animatorController.SetBool("walking", false);
        }

        if (
            Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)
            )
        {
            _animatorController.SetBool("run", true);
        }
        else
        {
            _animatorController.SetBool("run", false);
        }

        if (Input.GetKey(KeyCode.E)) _animatorController.SetBool("slide", true);
    }
}
