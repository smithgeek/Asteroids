using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score = 0;

    public Text mHighScoreText;

    public Text mHealthText;

    public Text mAlienHealthText;

    public int PhotonPower { get; set; }

    public bool GodMode { get; set; }

    public bool RapidFire { get; set; }

    public int Health { get; set; }

    public int AlienHealth { get; set; }

    private GameObject[] mAsteroids;

    private GameObject mPlayer;

    public void Start()
    {
        reset();
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mHighScoreText = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<Text>();
        mAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        mHealthText = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        mAlienHealthText = GameObject.FindGameObjectWithTag("AlienHealth").GetComponent<Text>();
    }

    private float getRandomLocation()
    {
        float value = Random.Range(-20, 20);
        if (value > 0 && value < 5) value = 5;
        if (value <= 0 && value > -5) value = -5;
        return value;
    }

    public void Update()
    {
        bool cheat = Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.RightAlt);
        if (cheat && Input.GetKeyDown(KeyCode.G))
        {
            GodMode = true;
            Health = 1000;
            PowerupCollision.enableShield();
        }
        if (cheat && Input.GetKeyDown(KeyCode.D))
        {
            GodMode = !GodMode;
        }
        if (cheat && Input.GetKeyDown(KeyCode.P))
        {
            PhotonPower = 1000;
        }
        if (cheat && Input.GetKeyDown(KeyCode.F))
        {
            RapidFire = !RapidFire;
        }
        if (cheat && Input.GetKeyDown(KeyCode.F1))
        {
            var offsett = new Vector3(getRandomLocation(), 0, getRandomLocation());
            Instantiate(Resources.Load("PhotonPowerup"), mPlayer.transform.position + offsett, Quaternion.identity);
        }
        if (cheat && Input.GetKeyDown(KeyCode.F2))
        {
            var offsett = new Vector3(getRandomLocation(), 0, getRandomLocation());
            Instantiate(Resources.Load("Powerup"), mPlayer.transform.position + offsett, Quaternion.identity);
        }

        if (Time.timeScale == 0)
        {
            mHighScoreText.text = "Paused";
        }
        else
        {
            mHighScoreText.text = "Score: " + Score.ToString();
        }
        mHealthText.text = "Health: " + Health.ToString() + " Power: " + PhotonPower.ToString() + " Speed: " + ShipMovement.ActiveSpeed.ToString();
        mAlienHealthText.text = "Health " + AlienHealth.ToString() + " Speed: " + AlienMovement.MoveSpeed.ToString();
        if(cheat)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            mPlayer.SetActive(true);
            GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>().enabled = false;
            AlienMovement.MoveSpeed = 23;
            reset();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach(var asteroid in mAsteroids)
            {
                asteroid.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var asteroid in mAsteroids)
            {
                asteroid.SetActive(false);
            }
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }

    public void reset()
    {
        Score = 0;
        GodMode = false;
        RapidFire = false;
        PhotonPower = 0;
        Health = 1;
        AlienHealth = 1;
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Renderer>().material.SetColor("_SpecColor", Color.black);
        player.GetComponent<Light>().enabled = false;
    }
}
