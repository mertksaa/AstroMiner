using UnityEngine;

public class UnlockArea : MonoBehaviour
{
    public string areaID; // Her alana özel isim vereceğiz (Örn: "Maden_2")
    public int unlockCost = 150; 
    public GameObject objectToUnlock; 

    private void Start()
    {
        // OYUN BAŞLARKEN: Bu alan daha önce satın alınıp kaydedilmiş mi kontrol et
        // Eğer kaydedildiyse (değeri 1 ise), satın alma işlemini atla ve direkt aç
        if (PlayerPrefs.GetInt(areaID, 0) == 1)
        {
            if (objectToUnlock != null)
            {
                objectToUnlock.SetActive(true);
            }
            Destroy(gameObject); // Halıyı yok et
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EconomyManager.Instance.currentGold >= unlockCost)
            {
                EconomyManager.Instance.SpendGold(unlockCost); 
                
                if (objectToUnlock != null)
                {
                    objectToUnlock.SetActive(true); 
                }
                
                // ALAN AÇILDIĞINDA: Bu ID'yi sisteme "1" olarak (açıldı) kaydet
                PlayerPrefs.SetInt(areaID, 1);
                PlayerPrefs.Save();
                
                Debug.Log(areaID + " kilidi açıldı ve diske KAYDEDİLDİ!");
                Destroy(gameObject); 
            }
        }
    }
}