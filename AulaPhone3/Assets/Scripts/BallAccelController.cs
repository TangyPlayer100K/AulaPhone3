using UnityEngine;

public class BallAccelController : MonoBehaviour
{

    public float speed = 12f;
    public float deadZone = 0.03f;
    public bool autoCalibraionOnStart = true;

    Rigidbody rb;
    Vector2 calib; //XY Axy

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (autoCalibraionOnStart)
        {
            calib = ReadTiltXY();
        }
    }

    Vector2 ReadTiltXY()
    {
        Vector3 acceleration = Input.acceleration;

        return new Vector2(acceleration.x, acceleration.y);
    }

    public void CalibratedNow() => calib = ReadTiltXY();
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 tilt = ReadTiltXY() - calib;

        if (tilt.magnitude < deadZone)
        {
            tilt = Vector2.zero;
        }

        Vector3 force = new Vector3(tilt.x, 0f, tilt.y) * speed;
        rb.AddForce(force, ForceMode.Acceleration);
    }
}
