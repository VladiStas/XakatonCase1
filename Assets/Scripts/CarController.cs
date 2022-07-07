using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    int i;
    public List<Transform> targets;
    public GameObject[] Wheels;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(Vector3.zero);
    }

    void TargetUpdate()
    {
        i++;
        if (i == targets.Count)
            i = 0;
        //i = Random.Range(0, targets.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.transform.position == agent.pathEndPosition)
        {
            TargetUpdate();

        }
        agent.SetDestination(targets[i].position);
    }
    private void FixedUpdate()
    {
        DriveWheels(Wheels);
    }
    void DriveWheels(GameObject[] gm)
    {
        for (int i = 0; i < Wheels.Length; i++)
            gm[i].transform.Rotate(5 + Time.deltaTime, 0, 0);
    }
}