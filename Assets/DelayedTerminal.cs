using UnityEngine;
using System.Collections;

public class DelayedTerminal : MonoBehaviour
{
    public GameObject uiPanel;
    
    [Header("Bekleme Süresi")]
    public float delayTime = 0.3f; // Artık süreyi koda girmeden Unity'den değiştirebilirsin
    
    private Coroutine openCoroutine;

    private void Start()
    {
        if (uiPanel != null) uiPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openCoroutine = StartCoroutine(OpenPanelDelay());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openCoroutine != null) StopCoroutine(openCoroutine);
            if (uiPanel != null) uiPanel.SetActive(false);
        }
    }

    private IEnumerator OpenPanelDelay()
    {
        yield return new WaitForSeconds(delayTime);
        if (uiPanel != null) uiPanel.SetActive(true);
    }
}