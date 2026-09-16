using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [Header("Kapasite ve Durum")]
    public int currentOre = 0;
    public int maxCapacity = 50;
    public int oreSellPrice = 15; // Cevher başı kazanılacak altın

    [Header("Görseller ve Arayüz")]
    public GameObject backpackVisual; // Sırttaki maden görseli
    public TextMeshProUGUI inventoryText; // Ekranda "Çanta: 10/50" yazacak

    private void Start()
    {
        UpdateUI();
    }

    // Dışarıdan (Madenlerden veya Meteorlardan) maden toplamak için
    public void AddOre(int amount)
    {
        if (currentOre < maxCapacity)
        {
            currentOre += amount;
            if (currentOre > maxCapacity) currentOre = maxCapacity; // Sınırı aşmasın
            UpdateUI();
        }
    }

    // Satış noktasına gidildiğinde çalışacak fonksiyon
    public void SellAllOre()
    {
        if (currentOre > 0)
        {
            int earnAmount = currentOre * oreSellPrice;
            EconomyManager.Instance.AddGold(earnAmount); // Altını kasaya ekle
            currentOre = 0;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (inventoryText != null) 
            inventoryText.text = "Çanta: " + currentOre + " / " + maxCapacity;
        
        // Çantada maden varsa sırttaki görseli aç, yoksa kapat
        if (backpackVisual != null)
            backpackVisual.SetActive(currentOre > 0);
    }
}