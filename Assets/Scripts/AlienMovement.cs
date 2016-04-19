using System.Collections;
using UnityEngine;

public class AlienMovement : MonoBehaviour {
    private GameObject mPlayer;
    private GameController mGameController;
    public static int MoveSpeed = 23;
    private int MaxDist = 100;
    private int MinDist = 25;
    private float fireRate = 1.0f;
    private float fireWait = 0.0f;

	// Use this for initialization
	private void Start ()
    {
        mGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        Spawn();
	}

	// Update is called once per frame
    private void Update()
    {
        if (mPlayer.activeSelf)
        {
            transform.LookAt(mPlayer.transform.position);
        }
        if (!mPlayer.activeSelf || Vector3.Distance(transform.position, mPlayer.transform.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        if (mPlayer.activeSelf && Vector3.Distance(transform.position, mPlayer.transform.position) <= MaxDist && Random.Range(0, 5) == 0 && fireWait > fireRate)
        {
            fireWait = 0;
            Instantiate(Resources.Load("AlienTorpedo"), gameObject.transform.position, gameObject.transform.rotation);
        }
        else
        {
            fireWait += Time.deltaTime;
        }
    }

    public void Spawn()
    {
        int randX = Random.Range(100, 500);
        int randZ = Random.Range(100, 500);
        if(Random.Range(0, 2) == 0) randX = -randX;
        if (Random.Range(0, 2) == 0) randZ = -randZ;
        gameObject.transform.position = new Vector3(randX, 0, randZ);
        MoveSpeed += 2;
        int bonusHealth = Mathf.Max(0, (MoveSpeed - 25) / 5);
        if(MoveSpeed >= 200)
        {
            fireRate = 0.0f;
        }
        else if (MoveSpeed >= 100)
        {
            fireRate = 0.25f;
        }
        else if(MoveSpeed >= 50)
        {
            fireRate = 0.5f;
        }
        else
        {
            fireRate = 1.0f;
        }
        mGameController.AlienHealth = 1 + bonusHealth;
    }
}
