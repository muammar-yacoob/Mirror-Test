using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    private Rigidbody rb;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Update()
    {
        //Rotate
        var x = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * x);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.2f)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}