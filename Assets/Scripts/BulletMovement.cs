using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float Speed = 25;

    // Use this for initialization
    private void Start()
    {
        Speed = ShipMovement.ActiveSpeed + 10;
        gameObject.transform.Translate(4, 0, 0, Space.Self);
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.Translate(Speed * Time.deltaTime, 0, 0, Space.Self);
    }
}
