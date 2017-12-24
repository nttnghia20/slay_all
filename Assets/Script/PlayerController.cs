using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed = 0.05F;
    public float maxTurnDelta = 0.05f;

    private Rigidbody2D rd2d;
    private float currentAngle;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        currentAngle = 0;
    }

    void FixedUpdate()
    {
        // move forward
        transform.position += moveSpeed * transform.up * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(currentAngle, Vector3.forward), maxTurnDelta);
    }

    void Update()
    {
        UpdateInput();
    }

    void UpdateInput() 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            currentAngle += turnSpeed;

        if (Input.GetKey(KeyCode.RightArrow))
            currentAngle -= turnSpeed;
    }
}
