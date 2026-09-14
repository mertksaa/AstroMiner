using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0f, 10f, -10f); // Kameranın karaktere olan uzaklığı/açısı
    public float smoothSpeed = 5f;

    // Kamera takibi işlemleri için Update yerine LateUpdate kullanmak titremeyi önler.
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            // Lerp fonksiyonu kameranın hedefe yumuşakça süzülmesini sağlar
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}