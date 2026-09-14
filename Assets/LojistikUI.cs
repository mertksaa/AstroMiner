using UnityEngine;
using TMPro;

public class LojistikUI : MonoBehaviour
{
    public static LojistikUI Instance;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI capacityText;
    public TextMeshProUGUI newDroneText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void OnEnable()
    {
        RefreshUI(); // Panel her açıldığında yazıları güncelle
    }

    public void RefreshUI()
    {
        DroneManager dm = DroneManager.Instance;
        
        // Zengin Metin (Rich Text) ile profesyonel görünüm
        speedText.text = $"<b><size=110%>MOTOR YÜKSELTMESİ</size></b>\nSeviye: {dm.speedLevel} -> {dm.speedLevel + 1}\nHız: {dm.globalSpeed} -> {dm.globalSpeed + 1.5f}\n<color=#FFD700>Maliyet: {dm.speedCost} G</color>";
        
        capacityText.text = $"<b><size=110%>KARGO GENİŞLETME</size></b>\nSeviye: {dm.capacityLevel} -> {dm.capacityLevel + 1}\nKapasite: {dm.globalCapacity} -> {dm.globalCapacity + 2}\n<color=#FFD700>Maliyet: {dm.capacityCost} G</color>";
        
        newDroneText.text = $"<b><size=110%>YENİ DRONE ÜRETİMİ</size></b>\nAktif Drone: {dm.droneCount}\n<color=#FFD700>Maliyet: {dm.newDroneCost} G</color>";
    }
}