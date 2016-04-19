using System.Collections;
using UnityEngine;

public class PowerupCollision : MonoBehaviour
{
    private GameController mGameController;

    // Use this for initialization
    public void Start()
    {
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    public void Update()
    {
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            enableShield();
            Destroy(gameObject);
            mGameController.Score += 50;
            mGameController.Health++;
        }
    }

    public static void enableShield()
    {
        var shield = GameObject.FindGameObjectWithTag("Shield");
        shield.GetComponent<MeshCollider>().enabled = true;
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            player.GetComponents<AudioSource>()[0].Play();
            player.GetComponent<Renderer>().material.SetColor("_SpecColor", new Color(0.471f, 0.779f, 0.836f, 1.000f));
            player.GetComponent<Light>().enabled = true;
        }
    }
}
