using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class addScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;//To show the score in game aswell as in the menu
    [SerializeField] bool showhighscore;//Changes the code to show the highscore instead of the current score
    [SerializeField] string showhighscoreLevel;
    int oldRemainingMoves;//used to check if the remaining moves have changed
    float timeSinceLastMove;// used to track the time since the last move in order to give a Multiplier for quick moves
    int multiplier = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showhighscore)
        {
            scoreText.text = PlayerPrefs.GetInt("Score" + showhighscoreLevel).ToString();
        } else
        {
            timeSinceLastMove += Time.deltaTime;
            //multiplyer
            switch (timeSinceLastMove)
            {
                case < 2f:
                    multiplier = 3; // Triple points for quick moves
                    break;
                case < 5f:
                    multiplier = 2; // Double points for moves within 2 seconds
                    break;
                default:
                    multiplier = 1; // Normal points for moves after 2 seconds
                    break;
            }
        }
    }

    void addingScore()
    {
        Debug.Log("Adding Score");
        timeSinceLastMove = 0;//reset time
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
        Debug.Log("Current Score: " + scoreTracker.Instance.currentScore);
        scoreTracker.Instance.currentScore += 10 * multiplier;//apply new score
        Debug.Log("New Score: " + scoreTracker.Instance.currentScore);
        scoreText.text = scoreTracker.Instance.currentScore.ToString();
        if (scoreTracker.Instance.currentScore > PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, scoreTracker.Instance.currentScore);
        }
        Destroy(this.gameObject);
    }
}
