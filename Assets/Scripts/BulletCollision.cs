using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private GameController mGameController;

    private void Start()
    {
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Asteroid" || (collider.gameObject.tag == "Alien" && mGameController.AlienHealth == 1))
        {
            Instantiate(Resources.Load("Explosion"), collider.gameObject.transform.position, Quaternion.identity);
            int healthRange = 20 + (int)Mathf.Log10(mGameController.Health) * 20;
            int powerRange = mGameController.PhotonPower * 10;
            if (0 == Random.Range(0, healthRange))
            {
                Instantiate(Resources.Load("PhotonPowerup"), collider.gameObject.transform.position, Quaternion.identity);
            }
            if (1 == Random.Range(0, healthRange))
            {
                Instantiate(Resources.Load("Powerup"), collider.gameObject.transform.position, Quaternion.identity);
            }
            if (collider.gameObject.tag == "Asteroid")
            {
                collider.gameObject.GetComponent<AsteroidMovement>().Spawn();
            }
            else
            {
                collider.gameObject.GetComponent<AlienMovement>().Spawn();
            }
            Destroy(gameObject);
            mGameController.Score += 100;
        }
        else if(collider.gameObject.tag == "Alien")
        {
            mGameController.AlienHealth--;
            Instantiate(Resources.Load("Explosion"), collider.gameObject.transform.position, Quaternion.identity);
        }
    }
}
