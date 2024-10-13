using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    void Update()
    {
        SetMoveDirection();
    }

    private void SetMoveDirection()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        float verticalInput = Input.GetAxis(Vertical);

        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput);
        inputDirection = transform.TransformDirection(inputDirection);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + inputDirection, _speed * Time.deltaTime);
    }
}
