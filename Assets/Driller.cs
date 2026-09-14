using UnityEngine;

public class Driller : MonoBehaviour
{
    public string drillerID; // Her kuyuya özel bir kimlik (Örn: "Maden_1", "Maden_2")
    public float extractionTime = 2f; 
    public int currentOre = 0;        
    public int maxCapacity = 10;      
    
    private float timer;

    void Start()
    {
        // Oyun başlarken bu kuyunun içindeki cevheri yükle
        currentOre = PlayerPrefs.GetInt(drillerID + "_ore", 0);
    }

    void Update()
    {
        if (currentOre < maxCapacity)
        {
            timer += Time.deltaTime;
            
            if (timer >= extractionTime)
            {
                currentOre++;
                timer = 0f;
                
                // Cevher üretildiğinde kaydet
                PlayerPrefs.SetInt(drillerID + "_ore", currentOre);
            }
        }
    }

    public int TakeOre(int droneCapacity)
    {
        int oreToTake = Mathf.Min(droneCapacity, currentOre);
        currentOre -= oreToTake;
        
        // Drone cevheri aldığında (eksildiğinde) kaydet
        PlayerPrefs.SetInt(drillerID + "_ore", currentOre);
        
        return oreToTake;
    }
}