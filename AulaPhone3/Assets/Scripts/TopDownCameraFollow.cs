using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{

    public Transform target; // Sphere position
    public float height = 20f; // Distancia vertical
    public float smooth = 5f; // Quanto maior o valor mais suave

    private Vector3 offset; // Sera usada para salvar o Y fixo 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position;
        offset.y = height;
    }

    void LateUpdate()
    {
        if (!target)
        {
            return;
        }        

        Vector3 desiredPos = target.position + offset;
        desiredPos.y = height;

        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smooth);
    }
}
