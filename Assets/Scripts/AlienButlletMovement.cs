using System.Collections;
using UnityEngine;

public class AlienButlletMovement : MonoBehaviour {
    public float Speed = 35;

	// Use this for initialization
    private void Start()
    {
        Speed = AlienMovement.MoveSpeed + 10;
        gameObject.transform.Rotate(0, 0, 90, Space.Self);
        gameObject.transform.Translate(0, 0, 4, Space.Self);
	}

	// Update is called once per frame
    private void Update()
    {
        gameObject.transform.Translate(0, 0, Speed * Time.deltaTime, Space.Self);
    }
}
