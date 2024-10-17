using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private float FB_Force;
    [SerializeField] private float UD_Force;
    [SerializeField] private float Arrows_Force;
    [SerializeField] private float X_AxisTorque;
    [SerializeField] private float StabilizationMultiplyer;

    [HideInInspector] public float YRotation = 0.0f;
    [HideInInspector] public float ZRotation = 0.0f;
    [HideInInspector] public float XRotation = 0.0f;
    [HideInInspector] public float forwardMagnitude = 0.0f;
    [HideInInspector] public float rightMagnitude = 0.0f;
    [HideInInspector] public float upMagnitude = 0.0f;

    private InputAction WS_Action;
    private InputAction AD_Action;
    private InputAction UpDown_Action;
    private InputAction UD_Action;
    private InputAction RL_Action;
    private InputAction Stabilization_Action;

    // Start is called before the first frame update
    void Start()
    {
        WS_Action = playerInput.actions.FindAction("WS");
        AD_Action = playerInput.actions.FindAction("AD");
        UpDown_Action = playerInput.actions.FindAction("UpDown");
        UD_Action = playerInput.actions.FindAction("UD");
        RL_Action = playerInput.actions.FindAction("RL");
        Stabilization_Action = playerInput.actions.FindAction("Stabilization");


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = rb.angularVelocity;
        YRotation = rotation.y;
        ZRotation = -rotation.z;
        XRotation = -rotation.x;

        forwardMagnitude = Vector3.Dot(rb.velocity, transform.forward);
        rightMagnitude = Vector3.Dot(rb.velocity, transform.right);
        upMagnitude = Vector3.Dot(rb.velocity, transform.up);

        rb.AddForce(transform.forward * WS_Action.ReadValue<float>() * FB_Force * Time.deltaTime);
        rb.AddForce(transform.up * UpDown_Action.ReadValue<float>() * UD_Force * Time.deltaTime);
        rb.AddTorque(transform.forward * RL_Action.ReadValue<float>() * X_AxisTorque * Time.deltaTime);
        rb.AddTorque(transform.up * AD_Action.ReadValue<float>() * Arrows_Force * Time.deltaTime);
        rb.AddTorque(transform.right * UD_Action.ReadValue<float>() * Arrows_Force * Time.deltaTime);

        if (Stabilization_Action.IsPressed()) rb.AddTorque(-rb.angularVelocity * StabilizationMultiplyer * Time.deltaTime);


        Debug.Log(rb.angularVelocity);
        Debug.Log(Vector3.Dot(rb.velocity, transform.forward));
    }
}
