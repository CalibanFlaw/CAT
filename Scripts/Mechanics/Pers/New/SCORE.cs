using UnityEngine;
using UnityEngine.UI;

public class SCORE : MonoBehaviour
{
    public bool CanPlay;
    private bool MoneyPlus = false;

    public static SCORE instance;

    public Text Money, TotalMoney, DeadMoney, HighMoney;

    public int moneyCounter = 0, TotalmoneyCounter, DeadmoneyCounter, highmoneyCounter;

    public Text Milk;
    public int MilkCounter;


    public Text score, highscore, deadScore;

    public int scoreCounter, highscoreCounter, DeadscoreCounter;

    Move move;

    private void Awake()
    {

        instance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highscoreCounter = PlayerPrefs.GetInt("SaveScore");
        }
        if (PlayerPrefs.HasKey("DeadScore"))
        {
            DeadscoreCounter = PlayerPrefs.GetInt("DeadScore");
        }
        if (PlayerPrefs.HasKey("SaveMoney"))
        {
            TotalmoneyCounter = PlayerPrefs.GetInt("SaveMoney");
        }
        if (PlayerPrefs.HasKey("DeadMoney"))
        {
            DeadmoneyCounter = PlayerPrefs.GetInt("DeadMoney");
        }
        if (PlayerPrefs.HasKey("HighMoney"))
        {
            highmoneyCounter = PlayerPrefs.GetInt("HighMoney");
        }
        if (PlayerPrefs.HasKey("Bonus"))
        {
            MilkCounter = PlayerPrefs.GetInt("Bonus");
        }

        AddTotalMoney();
        AddDeadMoney();

        move = FindObjectOfType<Move>();
    }



    private void FixedUpdate()
    {

        score.text = scoreCounter.ToString();
        deadScore.text = DeadscoreCounter.ToString();
        highscore.text = highscoreCounter.ToString();


        Money.text = moneyCounter.ToString();
        TotalMoney.text = TotalmoneyCounter.ToString();
        DeadMoney.text = DeadmoneyCounter.ToString();
        HighMoney.text = highmoneyCounter.ToString();

        Milk.text = MilkCounter.ToString();



        AddScore();


        AddTotalMoney();
        AddDeadMoney();

    }


    public void AddScore()
    {
        if (CanPlay)
        {
            scoreCounter++;
        }

        AddHighScore();
        AddDeadScore();
    }
    public void AddHighScore()
    {
        if (scoreCounter > highscoreCounter)
        {
            highscoreCounter = scoreCounter;
        }
        PlayerPrefs.SetInt("SaveScore", highscoreCounter);
    }
    public void AddDeadScore()
    {
        PlayerPrefs.SetInt("DeadScore", scoreCounter);
    }

    public void AddMoney(int number)
    {
        if (CanPlay)
            moneyCounter += number;
    }
    public void AddTotalMoney()
    {
        if (!MoneyPlus)
        {
            PlayerPrefs.SetInt("SaveMoney", TotalmoneyCounter + DeadmoneyCounter);
            MoneyPlus = true;
        }
    }
    public void AddDeadMoney()
    {
        if (moneyCounter > highmoneyCounter)
        {
            highmoneyCounter = moneyCounter;
        }
        PlayerPrefs.SetInt("HighMoney", highmoneyCounter);

        PlayerPrefs.SetInt("DeadMoney", moneyCounter);
    }

    public void AddMilk(int number)
    {
        if (CanPlay)
            MilkCounter += number;
        PlayerPrefs.SetInt("Bonus", MilkCounter);
    }

    public void GameForMilk()
    {
        MilkCounter = MilkCounter - 1;
        PlayerPrefs.SetInt("Bonus", MilkCounter);
    }
}
