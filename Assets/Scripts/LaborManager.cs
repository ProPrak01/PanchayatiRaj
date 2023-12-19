using System.Collections;
using UnityEngine;
using TMPro;

public class LaborManager : MonoBehaviour
{
    public int availableLabors = 20; // Initial available labor count
    public TextMeshProUGUI laborCostText;
    public TextMeshProUGUI laborChangeText;

    private void Start()
    {
        HideChangeText();
        // UpdateLaborText();
    }

    private void Update()
    {
        laborCostText.text = availableLabors.ToString();
    }

    /*private void UpdateLaborText()
    {
        laborCostText.text = availableLabors.ToString();
    }*/

    private void HideChangeText()
    {
        laborChangeText.gameObject.SetActive(false);
    }

    public void AssignLaborForStructure(int laborCost, float constructionTime)
    {
        availableLabors -= laborCost;
        ShowChangeText("-" + laborCost.ToString() + " Labors");
        if (availableLabors >= laborCost)
        {
            StartCoroutine(BuildStructure(laborCost, constructionTime));
        }
        else
        {
            Debug.Log("Not enough available labors!");
            // Handle the situation when there are not enough labors available
        }
    }

    private IEnumerator BuildStructure(int laborCost, float constructionTime)
    {
       

        yield return new WaitForSeconds(constructionTime);

        availableLabors += laborCost;
        ShowChangeText("+" + laborCost.ToString() + " Labors");

        yield return new WaitForSeconds(2f);
        HideChangeText();
        // UpdateLaborText();
    }

    private void ShowChangeText(string textToShow)
    {
        laborChangeText.gameObject.SetActive(true);
        laborChangeText.text = textToShow;
    }
    public bool CanAffordLabor(int laborCost)
    {
        return availableLabors >= laborCost;
    }
}
