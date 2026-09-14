using UnityEngine;

public class DrillerStats : MonoBehaviour
{
    public int speedLevel = 1;
    public int speedCost = 50;

    public int capacityLevel = 1;
    public int capacityCost = 50;

    public int qualityLevel = 1;
    public int qualityCost = 100;

    public void UpgradeSpeed()
    {
        if (EconomyManager.Instance.currentGold >= speedCost)
        {
            EconomyManager.Instance.SpendGold(speedCost);
            speedLevel++;
            speedCost = Mathf.RoundToInt(speedCost * 1.5f);
        }
    }

    public void UpgradeCapacity()
    {
        if (EconomyManager.Instance.currentGold >= capacityCost)
        {
            EconomyManager.Instance.SpendGold(capacityCost);
            capacityLevel++;
            capacityCost = Mathf.RoundToInt(capacityCost * 1.5f);
        }
    }

    public void UpgradeQuality()
    {
        if (EconomyManager.Instance.currentGold >= qualityCost)
        {
            EconomyManager.Instance.SpendGold(qualityCost);
            qualityLevel++;
            qualityCost = Mathf.RoundToInt(qualityCost * 1.5f);
        }
    }
}