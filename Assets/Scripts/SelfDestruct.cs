using UnityEngine;
using System.Collections;
using System;

public class SelfDestruct : MonoBehaviour
{
    DateTime mSelfDestructTime;
    public int LifeMilliseconds = 5000;

    // Use this for initialization
    void Start()
    {
        mSelfDestructTime = DateTime.Now.AddMilliseconds(LifeMilliseconds);
    }

    // Update is called once per frame
    void Update()
    {
        if(DateTime.Now > mSelfDestructTime)
        {
            Destroy(gameObject);
        }
    }
}
