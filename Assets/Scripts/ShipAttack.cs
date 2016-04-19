using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShipAttack : MonoBehaviour
{
    private GameController mGameController;
    private GameObject mPlayer;
    private Text mGameOver;

    // Use this for initialization
    private void Start()
    {
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mGameOver = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        bool shouldFire = Input.GetKeyDown(KeyCode.Space);
        if(Input.GetKey(KeyCode.Space) && mGameController.RapidFire)
        {
            shouldFire = true;
        }
        if(shouldFire)
        {
            fire();
        }
    }

    private void fire()
    {
        //mPlayer.GetComponent<MeshRenderer>().enabled = true;
        if (!mPlayer.activeSelf)
        {
            mPlayer.SetActive(true);
            mGameOver.enabled = false;
            mGameController.reset();
            return;
        }
        if (mGameController.PhotonPower >= 200)
        {
            fireSuper();
        }
        else if (mGameController.PhotonPower > 100)
        {
            fireSix();
        }
        else if (mGameController.PhotonPower > 50)
        {
            fireSeven();
        }
        else if (mGameController.PhotonPower >= 25)
        {
            fireFive();
        }
        else if (mGameController.PhotonPower >= 3)
        {
            fireFour();
        }
        else if (mGameController.PhotonPower >= 2)
        {
            fireThree();
        }
        else if(mGameController.PhotonPower >= 1)
        {
            fireTwo();
        }
        else
        {
            fireOne();
        }
    }

    private void fireOne()
    {
        var position = gameObject.transform.position;
        Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
    }

    private void fireTwo()
    {
        var position = gameObject.transform.position;
        GameObject one = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        one.transform.Translate(0, 0, 5, Space.Self);
        GameObject two = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        two.transform.Translate(0, 0, -5, Space.Self);
    }

    private void fireThree()
    {
        var position = gameObject.transform.position;
        Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        GameObject one = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        one.transform.Translate(0, 0, 5, Space.Self);
        GameObject two = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        two.transform.Translate(0, 0, -5, Space.Self);
    }

    private void fireFour()
    {
        fireThree();
        var position = gameObject.transform.position;

        GameObject right = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        right.transform.Rotate(0, 90, 0);

        GameObject left = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        left.transform.Rotate(0, -90, 0);
    }

    private void fireFive()
    {
        fireFour();
        var position = gameObject.transform.position;

        GameObject behind = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        behind.transform.Rotate(0, 180, 0);
    }

    private void fireSix()
    {
        fireFour();
        var position = gameObject.transform.position;
        Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        GameObject one = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        one.transform.Translate(0, 0, 5, Space.Self);
        one.transform.Rotate(0, 180, 0);
        GameObject two = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
        two.transform.Translate(0, 0, -5, Space.Self);
        two.transform.Rotate(0, 180, 0);
    }

    private void fireSeven()
    {
        fireOne();
        var position = gameObject.transform.position;
        var rotations = new[] { 45, 90, 135, 180, 225, 270, 315 };
        foreach (var rotation in rotations)
        {
            GameObject obj = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
            obj.transform.Rotate(0, rotation, 0);
        }
    }

    private void fireSuper()
    {
        fireOne();
        var position = gameObject.transform.position;
        var rotations = new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310, 320, 330, 340, 350 };
        foreach (var rotation in rotations)
        {
            GameObject obj = (GameObject)Instantiate(Resources.Load("PhotonTorpedo"), position, gameObject.transform.rotation);
            obj.transform.Rotate(0, rotation, 0);
        }
    }
}
