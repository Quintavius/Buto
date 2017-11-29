using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishController : MonoBehaviour
{
    NavMeshAgent fishe;
    [Header("CAUTION, Highly advanced fishe AI")]
    public float range;
    float dist;
    public Vector3 target;

    // Use this for initialization
    void Start()
    {
        fishe = GetComponent<NavMeshAgent>();
        fishe.baseOffset += Random.Range(-1.5f, 1.5f);
        var scaleMod = Random.Range(-0.8f, 0.8f);
        transform.localScale += new Vector3(scaleMod,scaleMod,scaleMod);
        Reroute();
    }

    // Update is called once per frame
    void Update()
    {
        if (fishe.pathPending)
        {
            dist = Vector3.Distance(transform.position, target);
        }
        else
        {
            dist = fishe.remainingDistance;
        }

        if (dist < 1)
        {
            Reroute();
        }
    }
    public void Reroute()
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, range, 1);
        Vector3 finalPosition = hit.position;

        fishe.destination = finalPosition;
    }
}
