using UnityEngine;

public class DrillerTrigger : MonoBehaviour
{
    public DrillerStats myStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. İSTATİSTİKLERİ DOLDUR (Paneli açma işini DelayedTerminal'e bırakıyoruz)
            if (DrillerUI.Instance != null)
            {
                DrillerUI.Instance.SetActiveDriller(myStats);
            }

            // 2. OTOMATİK MADEN TOPLAMA
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            Driller myDriller = myStats.GetComponent<Driller>(); 
            
            if (inventory != null && myDriller != null)
            {
                if (myDriller.currentOre > 0 && inventory.currentOre < inventory.maxCapacity)
                {
                    int availableSpace = inventory.maxCapacity - inventory.currentOre;
                    int amountToTake = Mathf.Min((int)myDriller.currentOre, availableSpace);
                    
                    inventory.AddOre(amountToTake);
                    myDriller.currentOre -= amountToTake;
                }
            }
        }
    }
}