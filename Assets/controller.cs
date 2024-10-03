using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private float FB_Force;
    [SerializeField] private float UD_Force;
    [SerializeField] private float Arrows_Force;
    [SerializeField] private float X_AxisTorque;
    [SerializeField] private float StabilizationMultiplyer;

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

        rb.AddForce(transform.forward * WS_Action.ReadValue<float>() * FB_Force * Time.deltaTime);
        rb.AddForce(transform.up * UpDown_Action.ReadValue<float>() * UD_Force * Time.deltaTime);
        rb.AddTorque(transform.forward * RL_Action.ReadValue<float>() * X_AxisTorque * Time.deltaTime);
        rb.AddTorque(transform.up * AD_Action.ReadValue<float>() * Arrows_Force * Time.deltaTime);
        rb.AddTorque(transform.right * UD_Action.ReadValue<float>() * Arrows_Force * Time.deltaTime);

        if (Stabilization_Action.IsPressed()) rb.AddTorque(-rb.angularVelocity * StabilizationMultiplyer * Time.deltaTime);



        Debug.Log(rb.velocity.magnitude);
    }
}
