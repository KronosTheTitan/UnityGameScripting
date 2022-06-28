using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHole : MonoBehaviour
{
    private float _StartTime;

    [SerializeField] private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time> _StartTime+1 && particleSystem != null)
        {
            Destroy(particleSystem.gameObject);
        }

        if (Time.time > _StartTime + 60) Destroy(gameObject);
    }
}
