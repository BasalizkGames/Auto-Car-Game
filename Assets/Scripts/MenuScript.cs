using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{ 
	public Button startButton;
	public Button creditsButton;
	public Button exitButton;
    
    // Initialization
    void Start ()
    {
		startButton = startButton.GetComponent<Button> ();
		creditsButton = creditsButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
	}

	public void PlayGame ()
    {
		SceneManager.LoadScene ("GameScene");
	}

    public void CreditsPressed()
    {
        SceneManager.LoadScene("Credits");
    }

    // Exiting the game
    public void ExitGame ()
    {
		Application.Quit();
	}
}
