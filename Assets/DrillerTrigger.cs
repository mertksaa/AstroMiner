using UnityEngine;

public class DrillerTrigger : MonoBehaviour
{
    public DrillerStats myStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && DrillerUI.Instance != null)
        {
            // Karakter alana girince, paneli kendi verilerimizle besliyoruz
            DrillerUI.Instance.SetActiveDriller(myStats);
        }
    }
}