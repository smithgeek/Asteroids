using System.Collections;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Vector3 Direction;
    private GameObject mPlayer;
    private const int max = 100;
    private const int min = 50;

    // Use this for initialization
    private void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        startMovement();
    }

    // Update is called once per frame
    private void Update()
    {
        var asteroidPosition = gameObject.transform.position;
        var playerPosition = mPlayer.transform.position;
        var difference = asteroidPosition - playerPosition;
        if (Mathf.Abs(difference.x) > max || Mathf.Abs(difference.z) > max)
        {
            Spawn();
            return;
        }
        gameObject.transform.Translate(Direction.x * Time.deltaTime, 0, Direction.z * Time.deltaTime);
    }

    private void startMovement()
    {
        var asteroidSpeed = 20f;
        Direction = new Vector3(Random.Range(-asteroidSpeed, asteroidSpeed), 0, Random.Range(-asteroidSpeed, asteroidSpeed));
        var scale = Random.Range(2f, 8f);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void Spawn()
    {
        var position = mPlayer.transform.position;
        var randX = Random.Range(-max, max);
        if (randX > -min && randX <= 0) randX = -min;
        else if (randX > 0 && randX < min) randX = min;

        var randZ = Random.Range(-max, max);
        if (randZ > -min && randZ <= 0) randZ = -min;
        else if (randZ > 0 && randZ < min) randZ = min;

        gameObject.transform.position = new Vector3(position.x + randX, 0, position.z + randZ);
        startMovement();
    }
}
