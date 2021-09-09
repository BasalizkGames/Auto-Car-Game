using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
	public Button playAgainButton;
	public Button exitButton;
    public Text Score;

    // Initialization
    void Start ()
    {
		playAgainButton = playAgainButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
	}
	
    public void PlayGame ()
    {
		SceneManager.LoadScene ("GameScene");
	}

    // Exiting the game
	public void ExitGame ()
    {
		Application.Quit();
	}
}