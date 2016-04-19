using System.Collections;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float RotateSpeed;
    private GameObject mPlayer;
    private GameController mGameController;
    public static int ActiveSpeed = 20;

    // Use this for initialization
    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!mPlayer.activeSelf)
        {
            return;
        }
        int multiplier = 1;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 2;
        }
        if(Input.GetKey(KeyCode.Z))
        {
            multiplier = 4;
        }
        if(Input.GetKey(KeyCode.X))
        {
            multiplier = 8;
        }
        if(Input.GetKey(KeyCode.C))
        {
            multiplier = 16;
        }
        ActiveSpeed = 20 * multiplier;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(ActiveSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(-ActiveSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(0, -RotateSpeed * Time.deltaTime, 0, Space.Self);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(0, RotateSpeed * Time.deltaTime, 0, Space.Self);
        }
    }
}
