using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManagement : MonoBehaviour
{
    /**
     Costs->

    ROAD - 20,000
    HOUSE - 10,00,000 :  30,00,000
    Hospital - 50,00,000
    School - 30,00,000
    Lake- 10,00,000

    **/
    public TextMeshProUGUI CostText;
    public TextMeshProUGUI DeductMoneyShow;

    public int InitialCost = 10000000;
    private void Start()
    {
        DeductMoneyShow.gameObject.SetActive(false);
    }

    private void Update()
    {
        CostText.text = InitialCost.ToString();
    }

    public void DecreaseCost(int Value)
    {
        if (InitialCost >= Value)
        {
            InitialCost -= Value;
            DeductMoneyShow.gameObject.SetActive(true);
            DeductMoneyShow.text = "- Rs." + Value.ToString();
            StartCoroutine(CallFunctionAfterDelay());
        }
        else
        {
            Debug.Log("Insufficient funds!");
        }
    }

    public void IncreaseCost(int Value)
    {
        InitialCost += Value;
        DeductMoneyShow.gameObject.SetActive(true);
        DeductMoneyShow.text = "+ Rs." + Value.ToString();
        StartCoroutine(CallFunctionAfterDelay());
    }

    IEnumerator CallFunctionAfterDelay()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Call your function after the delay
        DeductMoneyShow.gameObject.SetActive(false);
    }

    public bool CanAfford(int cost)
    {
        return InitialCost >= cost;
    }

}
