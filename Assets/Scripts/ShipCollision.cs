using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShipCollision : MonoBehaviour
{
    private Text mGameOver;
    private GameController mGameController;

    private void Start()
    {
        mGameOver = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void explode(GameObject obj)
    {
        Instantiate(Resources.Load("Explosion"), obj.transform.position, Quaternion.identity);
        //Destroy(obj);
    }

    private void OnTriggerEnter(Collider collider)
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (mGameController.Health > 1)
        {
            shieldCollision(collider);
        }
        else
        {
            if ((collider.gameObject.tag == "Asteroid" || collider.gameObject.tag == "AlienTorpedo"))
            {
                mGameController.Health--;
                explode(collider.gameObject);
                explode(gameObject);
                mGameController.PhotonPower = 0;
                gameObject.SetActive(false);
                mGameOver.enabled = true;
            }
        }
    }

    private void shieldCollision(Collider collider)
    {
        if ((collider.gameObject.tag == "Asteroid" || collider.gameObject.tag == "AlienTorpedo") && gameObject.GetComponent<MeshCollider>().enabled)
        {
            Instantiate(Resources.Load("Explosion"), collider.gameObject.transform.position, Quaternion.identity);
            if (collider.gameObject.tag == "Asteroid")
            {
                collider.gameObject.GetComponent<AsteroidMovement>().Spawn();
            }
            mGameController.Health--;
            if (!mGameController.GodMode && mGameController.Health == 1)
            {
                //gameObject.GetComponent<MeshCollider>().enabled = false;
                gameObject.GetComponent<AudioSource>().Play();
                var player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Renderer>().material.SetColor("_SpecColor", Color.black);
                player.GetComponent<Light>().enabled = false;
            }
        }
    }
}
