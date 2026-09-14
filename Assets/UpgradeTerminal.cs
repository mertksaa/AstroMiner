using UnityEngine;

public class UpgradeTerminal : MonoBehaviour
{
    public GameObject upgradePanel;
    public Driller linkedDriller;      // Bağlı olduğu maden kuyusu
    public int speedUpgradeCost = 50;  // Yükseltme bedeli

    private void Start()
    {
        if (upgradePanel != null) upgradePanel.SetActive(false);
        
        // Eğer elle atamayı unutursak, otomatik olarak bir üst objedeki Driller'ı bulsun
        if (linkedDriller == null)
        {
            linkedDriller = GetComponentInParent<Driller>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (upgradePanel != null) upgradePanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            if (upgradePanel != null) upgradePanel.SetActive(false);
    }

    // BUTONA TIKLANDIĞINDA BU FONKSİYON ÇALIŞACAK
    public void BuySpeedUpgrade()
    {
        // Eğer mevcut altınımız maliyete eşit veya büyükse
        if (EconomyManager.Instance.currentGold >= speedUpgradeCost)
        {
            // Parayı harca
            EconomyManager.Instance.SpendGold(speedUpgradeCost);
            
            // Madenin üretim süresini 0.5 saniye kısalt (Hızlandır). 
            // Mathf.Max kullanarak sürenin 0.5 saniyenin altına düşmesini (bug'a girmesini) engelliyoruz.
            linkedDriller.extractionTime = Mathf.Max(0.5f, linkedDriller.extractionTime - 0.5f);
            
            Debug.Log("Hız yükseltildi! Yeni üretim süresi: " + linkedDriller.extractionTime + " saniye.");
        }
        else
        {
            Debug.Log("Yetersiz altın! Gereken: " + speedUpgradeCost);
        }
    }
}