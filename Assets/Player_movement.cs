using Fusion;
using UnityEngine;

public class Player_movement : NetworkBehaviour
{
    public float walkspeed = 5;
    public float maxspeed = 10;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Ya NO usamos Update() para leer el input aquí -
    // eso va en tu PlayerInputHandler (como vimos antes),
    // que llena GameplayInput.MoveDirection

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out GameplayInput input))
        {
            rb.AddForce(CalculateMovement(input.MoveDirection.normalized, walkspeed), ForceMode.VelocityChange);
        }
    }

    Vector3 CalculateMovement(Vector2 input, float _speed)
    {
        Vector3 targetmovement = new Vector3(input.x, 0f, input.y);
        targetmovement = transform.TransformDirection(targetmovement);
        targetmovement *= _speed;

        Vector3 velocity = rb.velocity;

        if (input.magnitude > 0.5f)
        {
            Vector3 velocitychange = targetmovement - velocity;
            velocitychange.x = Mathf.Clamp(velocitychange.x, -maxspeed, maxspeed);
            velocitychange.z = Mathf.Clamp(velocitychange.z, -maxspeed, maxspeed);
            velocitychange.y = 0;
            return velocitychange;
        }
        else
        {
            return Vector3.zero;
        }
    }
}