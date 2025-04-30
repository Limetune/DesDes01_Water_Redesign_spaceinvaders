using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Text textScore;

    int score = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textScore.text = ("Score: ") + score.ToString();
    }

    public void AddScore()
    {
        score += Enemy.Instance.score;
        textScore.text = ("Score: ") + score.ToString();
    }
}
