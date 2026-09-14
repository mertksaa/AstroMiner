using UnityEngine;

public class TradeCenter : MonoBehaviour
{
    public static TradeCenter Instance; // Her yerden kolay erişim için Singleton
    public int oreMultiplier = 15; // 1 birim cevherin Altın karşılığı (İleride upgrade edilecek)

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SellOre(int oreAmount)
    {
        int goldToGain = oreAmount * oreMultiplier;
        EconomyManager.Instance.AddGold(goldToGain);
        Debug.Log(oreAmount + " cevher satıldı, " + goldToGain + " Gold kazanıldı!");
    }
}