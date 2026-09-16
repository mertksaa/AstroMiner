using UnityEngine;
using TMPro; // Fiyat yazısı için gerekli kütüphane

public class UnlockArea : MonoBehaviour
{
    public string areaID = "Area_1"; 
    public int unlockCost = 1500;
    
    [Header("Açılacak Objeler")]
    public GameObject drillerToUnlock; // Driller buraya bağlanacak
    public GameObject droneToUnlock;   // YENİ: Drone buraya bağlanacak
    public GameObject barriersToDestroy; // Varsa önünü kapatan duvarlar
    
    [Header("Arayüz")]
    public TextMeshProUGUI costText; // Ekranda yazacak fiyat metni

    private void Start()
    {
        // Oyun açıldığında bu alan daha önce satın alınmış mı kontrol et
        if (PlayerPrefs.GetInt(areaID, 0) == 1)
        {
            ActivateZone(); 
        }
        else
        {
            // Satın alınmadıysa madeni ve dronu kapalı (görünmez) tut
            if (drillerToUnlock != null) drillerToUnlock.SetActive(false);
            if (droneToUnlock != null) droneToUnlock.SetActive(false);
            
            // Fiyatı ekrana yazdır
            if (costText != null) costText.text = unlockCost + " G";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eğer giren oyuncuysa ve bu alan daha önce alınmamışsa
        if (other.CompareTag("Player") && PlayerPrefs.GetInt(areaID, 0) == 0)
        {
            if (EconomyManager.Instance.currentGold >= unlockCost)
            {
                EconomyManager.Instance.SpendGold(unlockCost);
                
                // Alındığını sisteme kaydet
                PlayerPrefs.SetInt(areaID, 1);
                PlayerPrefs.Save();
                
                ActivateZone(); // Açılma fonksiyonunu çağır
            }
        }
    }

    private void ActivateZone()
    {
        // Madeni ve Dronu görünür yapıp çalıştır
        if (drillerToUnlock != null) drillerToUnlock.SetActive(true);
        if (droneToUnlock != null) droneToUnlock.SetActive(true);
        
        // Bariyer varsa yok et
        if (barriersToDestroy != null) barriersToDestroy.SetActive(false);
        
        // Satın alma sensörünü (kendisini) tamamen kapat
        gameObject.SetActive(false); 
    }
}