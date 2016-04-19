using System.Collections;
using UnityEngine;

public class InfinteStarfield : MonoBehaviour
{
    private Transform tx;
    private ParticleSystem.Particle[] points;

    public int starsMax = 100000;
    public float starSize = 4.76f;
    public float starDistance = 10;
    public float starClipDistance = 1;
    private float starDistanceSqr;
    private float starClipDistanceSqr;

    // Use this for initialization
    public void Start()
    {
        tx = transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            points[i].startColor = new Color(255, 255, 255, 255);
            points[i].startSize = starSize;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (points == null) CreateStars();

        for (int i = 0; i < starsMax; i++)
        {
            if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
            }

            if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
                points[i].startColor = new Color(255, 255, 255, percent);
                points[i].startSize = percent * starSize;
            }
        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }
}
