using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float ANGULARdRAG = 0.001F;

    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
            Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
            rb.AddForce(transform.up * lift.magnitude * liftBooster);
        }

        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * ANGULARdRAG;
        
       rb.AddTorque(transform.up * yaw);
       rb.AddTorque(transform.right * pitch);
       rb.AddTorque(transform.forward * roll);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
