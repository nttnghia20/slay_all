using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EInputSource {
    Keyboard = 0,
    GamePad = 1
}

public class PlayerController : MonoBehaviour {
    static readonly string[,] INPUT_MAPPING = {{"Horizontal", "Vertical"}, {"Horizontal1", "Vertical1"}};

    public float moveSpeed;
    public float turnSpeed = 0.05F;
    public float maxTurnDelta = 0.05f;

    public EInputSource inputSource; 

    private Rigidbody2D rd2d;
    private float currentAngle;
    private int inputSourceID;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        currentAngle = 0;
        inputSourceID = (int)inputSource;
    }

    void FixedUpdate()
    {
        // move forward
        transform.position += moveSpeed * transform.right * Time.fixedDeltaTime;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(currentAngle, Vector3.forward), maxTurnDelta);
    }

    void Update()
    {
        UpdateInput();
    }

    void UpdateInput() 
    {
        float hInput = Input.GetAxis(INPUT_MAPPING[inputSourceID, 0]);
        float vInput = Input.GetAxis(INPUT_MAPPING[inputSourceID, 1]);

        if(!Mathf.Approximately(hInput + vInput, 0.0f))
            transform.right = new Vector2(hInput, vInput);

    }
}
