using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Joystick joystick; // Joystick paketini tanıyacak değişken

    void Update()
    {
        // Input.GetAxis yerine doğrudan joystick değişkenlerini okuyoruz
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if (movement.magnitude > 0.1f)
        {
            movement.Normalize();
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}