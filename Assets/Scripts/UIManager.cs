using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text laborCountText; // Reference to the Text element displaying labor count

    // Function to update the displayed labor count
    public void UpdateLaborCount(int availableLabors)
    {
        laborCountText.text = "Labors: " + availableLabors.ToString(); // Update the text with available labors
    }
}
