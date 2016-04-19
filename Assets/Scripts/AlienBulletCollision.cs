using System.Collections;
using UnityEngine;

public class AlienBulletCollision : MonoBehaviour {

	// Use this for initialization
    private void Start()
    {
	}

	// Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //Instantiate(Resources.Load("Explosion"), collider.gameObject.transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
    }
}
