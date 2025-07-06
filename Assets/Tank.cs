using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed;
        float turn = Input.GetAxis("Horizontal") * turnSpeed;

        Vector3 movement = transform.forward * move * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn * Time.deltaTime, 0f);

        rb.MovePosition(rb.position + movement);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
