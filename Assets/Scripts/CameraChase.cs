using UnityEngine;
using System.Collections;

public class CameraChase : MonoBehaviour
{
    GameObject mPlayer;

    // Use this for initialization
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(mPlayer != null)
        {
            gameObject.transform.position = new Vector3(mPlayer.transform.position.x - 55, gameObject.transform.position.y, mPlayer.transform.position.z);
            //gameObject.transform.Rotate(55,90,0, Space.Self);
            gameObject.transform.LookAt(mPlayer.transform.position);
        }
    }
}
