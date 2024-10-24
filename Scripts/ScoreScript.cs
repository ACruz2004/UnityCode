using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    public int scoreNum = 0;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        score.text = "Score: " + PlayerPrefs.GetInt("Score", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        PlayerPrefs.SetInt("Score", scoreNum);
        if (scoreNum > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreNum);
            highScore.text = scoreNum.ToString();
        }
    }

    // Updating the score when you shot amoguwas
    public void AddScore(int amount)
    {
        scoreNum += amount;
        score.text = "Score: " + scoreNum.ToString();
    }

}
