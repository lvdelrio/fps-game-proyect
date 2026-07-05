using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float walkspeed = 5;
    public float maxspeed = 10;

    private Rigidbody rb;
    private Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
    }

    void FixedUpdate()
    {
        rb.AddForce(calculateMovement(walkspeed), ForceMode.VelocityChange);
    }

    Vector3 calculateMovement(float _speed)
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
        }else
        {
            return new Vector3();
        }

    }
}
