using UnityEngine;
using UnityEngine.UI;

public class BallGyroController : MonoBehaviour
{
    public float speed = 12f;
    public float deadZone = 0.012f;
    public float sleepvel = 0.02f;
    public Vector3 rotFixEuler = new Vector3(90, 0, 0); //para landscape
    public bool autoCalibrationOnStart = true;

    Rigidbody rb;
    Quaternion calib = Quaternion.identity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 0.3f;
        rb.angularDamping = 0.2f;
        Input.gyro.enabled = true;

        if (autoCalibrationOnStart)
        {
            calib = GetWorldAttitude();
        }
        ZeroMotion();
    }

    Quaternion GetWorldAttitude()
    {
        var g = Input.gyro.attitude;
        var q = new Quaternion(g.x, g.y, -g.z, -g.w);
        return Quaternion.Euler(rotFixEuler) * q;
    }

    void ZeroMotion()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Quaternion worldRot = GetWorldAttitude();
        Quaternion rel = Quaternion.Inverse(calib) * worldRot;
    }
}
