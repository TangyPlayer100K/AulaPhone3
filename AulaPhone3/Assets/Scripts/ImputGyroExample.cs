using UnityEngine;

public class ImputGyroExample : MonoBehaviour
{
    Gyroscope m_Gyro;

    private void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;


    }

    private void OnGUI()
    {
        GUI.Label(new Rect(500, 500, 500, 500), "Gyro rotation rate: " + m_Gyro.rotationRate);
        //GUI.Label(new Rect(500, 500, 500, 500), "Gyro rotation Attitude: " + m_Gyro.attitude);
        //GUI.Label(new Rect(500, 500, 500, 500), "Gyro enabled " + m_Gyro.enabled);
    }

}
