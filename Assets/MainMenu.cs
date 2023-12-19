using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject guide;

    public void Start()
    {
        guide.SetActive(false);
    }
    // Method to start the game
    public void StartGame()
    {
        // Load the game scene by its index
        SceneManager.LoadScene("TownScene");
    }

    // Method to show instructions (You can replace this with your own instructions logic)
    public void ShowInstructions()
    {
        // Replace this with your logic to show instructions
        guide.SetActive(true);
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    public void HideInstructions()
    {
        // Replace this with your logic to show instructions
        guide.SetActive(false);
    }
}
