using System.Collections;
using UnityEngine;

public class PhotonPowerupCollision : MonoBehaviour
{
    private GameController mGameController;

    // Use this for initialization
    private void Start()
    {
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            mGameController.PhotonPower++;
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponents<AudioSource>()[1].Play();
            Destroy(gameObject);
        }
    }
}
