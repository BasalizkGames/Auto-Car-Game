using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credits : MonoBehaviour
{
    public Button backButton;

    // Initialization
    void Start()
    {
        backButton = backButton.GetComponent<Button>();
    }

    public void BackPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}