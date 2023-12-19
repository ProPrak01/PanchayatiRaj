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

    public int InitialCost = 10000000;

    private void Update()
    {
        CostText.text = InitialCost.ToString();
    }

    public void DecreaseCost(int Value)
    {
        InitialCost -= Value;
    }
    public void IncreaseCost(int Value)
    {
        InitialCost += Value;
    }


}
