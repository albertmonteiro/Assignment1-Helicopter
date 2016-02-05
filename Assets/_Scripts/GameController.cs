using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;

    [SerializeField]
    private AudioSource _gameOverSound;


    // PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            //Debug.Log("Inside ScoreValue Setter method");
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            //Debug.Log("Inside LivesValue Setter method");
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    // PUBLIC INSTANCE VARIABLES
    public int birdNumber = 2;
    public int missileNumber = 8;
    public BirdController bird;
    public MissileController missile;
    public HelicopterController helicopter;
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public Button RestartButton;


    // Use this for initialization
    void Start()
    {
        //Debug.Log("Inside START method");
        this._initialize();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //PRIVATE METHODS ++++++++++++++++++

    //Initial Method
    private void _initialize()
    {
        //Debug.Log("Inside INITIALIZE method");
		this.ScoreValue = 0;
		this.LivesValue = 5;
        //this._scoreValue = 0;
        //this._livesValue = 5;
        this.GameOverLabel.gameObject.SetActive(false);
        this.HighScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
   
        for (int birdCount = 0; birdCount < this.birdNumber; birdCount++)
        {
            Instantiate(bird.gameObject);
        }
        for (int missileCount = 0; missileCount < this.missileNumber; missileCount++)
        {
            Instantiate(missile.gameObject);
        }
    }

    private void _endGame()
    {
        this.HighScoreLabel.text = "High Score: " + this._scoreValue;
        this.GameOverLabel.gameObject.SetActive(true);
        this.HighScoreLabel.gameObject.SetActive(true);
        this.LivesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.helicopter.gameObject.SetActive(false);
        //this.bird.gameObject.SetActive(false);
        this._gameOverSound.Play();
        this.RestartButton.gameObject.SetActive(true);
    }

    // PUBLIC METHODS
    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
