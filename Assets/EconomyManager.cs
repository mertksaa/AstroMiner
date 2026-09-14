using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;

    public int currentGold = 0;
    public TextMeshProUGUI goldText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // OYUN BAŞLARKEN: Cihaza kaydedilmiş "SavedGold" verisini çek (yoksa 0 yap)
        currentGold = PlayerPrefs.GetInt("SavedGold", 0);
    }

    void Start()
    {
        UpdateGoldUI(); 
    }

    void Update()
    {
        // GELİŞTİRİCİ HİLESİ: Klavyeden 'R' tuşuna basarsan tüm kayıtlar silinir
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll(); // Unity'nin hafızasındaki her şeyi siler
            currentGold = 0;
            UpdateGoldUI();
            Debug.Log("TÜM KAYITLAR SİLİNDİ! Oyunu tekrar başlattığında sıfırdan açılacak.");
        }
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldUI();
        SaveGold(); // Altın değiştiğinde kaydet
    }

    public void SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldUI();
            SaveGold(); // Altın değiştiğinde kaydet
        }
    }

    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold.ToString();
        }
    }

    // KAYIT FONKSİYONU
    private void SaveGold()
    {
        PlayerPrefs.SetInt("SavedGold", currentGold);
        PlayerPrefs.Save(); // Veriyi diske yaz
    }
}