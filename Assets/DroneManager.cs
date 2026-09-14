using UnityEngine;

public class DroneManager : MonoBehaviour
{
    public static DroneManager Instance;
    
    public int capacityLevel = 1;
    public int globalCapacity = 3;
    public int capacityCost = 100;

    public int speedLevel = 1;
    public float globalSpeed = 3.5f;
    public int speedCost = 100;

    public int droneCount = 2; // Başlangıçta 2 dronumuz var
    public int newDroneCost = 1500;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void BuySpeedUpgrade()
    {
        if (EconomyManager.Instance.currentGold >= speedCost)
        {
            EconomyManager.Instance.SpendGold(speedCost);
            globalSpeed += 1.5f;
            speedLevel++;
            speedCost = Mathf.RoundToInt(speedCost * 1.5f);
            if(LojistikUI.Instance != null) LojistikUI.Instance.RefreshUI();
        }
    }

    public void BuyCapacityUpgrade()
    {
        if (EconomyManager.Instance.currentGold >= capacityCost)
        {
            EconomyManager.Instance.SpendGold(capacityCost);
            globalCapacity += 2;
            capacityLevel++;
            capacityCost = Mathf.RoundToInt(capacityCost * 1.5f);
            if(LojistikUI.Instance != null) LojistikUI.Instance.RefreshUI();
        }
    }
    
    public void BuyNewDrone()
    {
        if (EconomyManager.Instance.currentGold >= newDroneCost)
        {
            EconomyManager.Instance.SpendGold(newDroneCost);
            droneCount++;
            newDroneCost = Mathf.RoundToInt(newDroneCost * 2f);
            // İleride buraya drone'u sahnede yaratma (Instantiate) kodunu ekleyeceğiz
            if(LojistikUI.Instance != null) LojistikUI.Instance.RefreshUI();
        }
    }
}