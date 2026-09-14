using UnityEngine;
using TMPro;

public class DrillerUI : MonoBehaviour
{
    public static DrillerUI Instance;

    public TextMeshProUGUI speedText, capacityText, qualityText;
    private DrillerStats activeDriller; // O an yanında durduğumuz maden

    private void Awake() { Instance = this; }
    
    private void OnEnable() { RefreshUI(); }

    public void SetActiveDriller(DrillerStats driller)
    {
        activeDriller = driller;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (activeDriller == null) return;

        speedText.text = $"<b><size=110%>ÜRETİM HIZI</size></b>\nSeviye: {activeDriller.speedLevel}\n<color=#FFD700>Maliyet: {activeDriller.speedCost} G</color>";
        capacityText.text = $"<b><size=110%>DEPO KAPASİTESİ</size></b>\nSeviye: {activeDriller.capacityLevel}\n<color=#FFD700>Maliyet: {activeDriller.capacityCost} G</color>";
        qualityText.text = $"<b><size=110%>KALİTE ÇARPANI</size></b>\nSeviye: {activeDriller.qualityLevel}\n<color=#FFD700>Maliyet: {activeDriller.qualityCost} G</color>";
    }

    // Butonlar tıklandığında aktif madeni yükseltir
    public void BuySpeed() { activeDriller.UpgradeSpeed(); RefreshUI(); }
    public void BuyCapacity() { activeDriller.UpgradeCapacity(); RefreshUI(); }
    public void BuyQuality() { activeDriller.UpgradeQuality(); RefreshUI(); }
}