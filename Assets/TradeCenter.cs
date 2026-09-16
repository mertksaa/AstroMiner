using UnityEngine;

public class TradeCenter : MonoBehaviour
{
    public static TradeCenter Instance; // Her yerden kolay erişim için Singleton
    public int oreMultiplier = 15; // 1 birim cevherin Altın karşılığı (Dronelar için)

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Droneların gelip satış yaptığı fonksiyon
    public void SellOre(int oreAmount)
    {
        int goldToGain = oreAmount * oreMultiplier;
        EconomyManager.Instance.AddGold(goldToGain);
        Debug.Log(oreAmount + " cevher satıldı, " + goldToGain + " Gold kazanıldı!");
    }

    // YENİ: Oyuncu bizzat satış noktasına girdiğinde çalışacak fiziksel sensör
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncunun üzerindeki çanta kodunu bul
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            
            // Çantada maden varsa hepsini sat
            if (inventory != null && inventory.currentOre > 0)
            {
                inventory.SellAllOre();
                Debug.Log("Oyuncu kendi taşıdığı madenleri başarıyla sattı!");
            }
        }
    }
}