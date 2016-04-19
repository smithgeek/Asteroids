using System.Collections;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public int Speed = 50;
    private Vector3 mLocation;

    // Use this for initialization
    private void Start()
    {
        mLocation = gameObject.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        float rotate = Speed * Time.deltaTime;
        gameObject.transform.Rotate(rotate, rotate, rotate);
        gameObject.transform.position = mLocation;
    }
}
