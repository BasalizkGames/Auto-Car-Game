using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour {

    public float PlayerSpeed;
    public float TurnRate;
    private Rigidbody2D rb;
    public Text Score;
    public Text ScoreOutline;
    public int PlayerScore = 0;
	private bool SpeedUp;
	private bool TurnUp;
    private int frame;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
		Score.text = "Score: " + PlayerScore;
        ScoreOutline.text = Score.text;

        transform.localEulerAngles = (new Vector3 (0, 0, 180));
    }

    void Turning()
    {
		
        float PlayerTurn = Input.GetAxisRaw("Horizontal");
		float PlayerAngle = transform.rotation.eulerAngles.z;

        //TURN RIGHT
        if (PlayerTurn > 0) {
			PlayerAngle -= TurnRate;
			PlayerAngle = Mathf.Clamp (PlayerAngle, 90, 270);
			transform.localEulerAngles = (new Vector3 (0, 0, PlayerAngle));
		}


		//TURN LEFT
		else if (PlayerTurn  < 0) {
			PlayerAngle += TurnRate;
			PlayerAngle = Mathf.Clamp (PlayerAngle, 90, 270);
            transform.localEulerAngles = (new Vector3 (0, 0, PlayerAngle));
        }

    }

	// Update is called once per frame
	void FixedUpdate()
    {
        Turning();
		rb.velocity = transform.up * PlayerSpeed * -1;
        frame++;
        if (frame % 30 == 0)
        {
            PlayerScore++;
            Score.text = "Score: " + PlayerScore.ToString();
            ScoreOutline.text = Score.text;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string ObjType = other.gameObject.tag.ToString();

		switch (ObjType) {
		case "Obstacle":
                SceneManager.LoadScene("GameOver");
                break;
		case "Score":
			Destroy (other.gameObject);
                PlayerScore += 100;
                Score.text = "Score: " + PlayerScore.ToString();
                ScoreOutline.text = Score.text;

                break;
		case "SpeedUp":
			Destroy (other.gameObject);
			if (!SpeedUp) {
				StartCoroutine ("PowerUpSpeed");
			}
			break;
		case "TurnRateUp":
			Destroy (other.gameObject);
			if (!TurnUp) {
				StartCoroutine ("PowerUpTurn");
			}
			break; 
		}
	}

	IEnumerator PowerUpSpeed ()
	{
		SpeedUp = true;
		PlayerSpeed *= 1.5f;
		yield return new WaitForSeconds (3.5f);
		PlayerSpeed /= 1.5f;
		SpeedUp = false;

	}	
	IEnumerator PowerUpTurn ()
	{
		TurnUp = true;
		TurnRate *= 3f;
		yield return new WaitForSeconds (5f);
		TurnRate /= 3f;
		TurnUp = false;
	}
}