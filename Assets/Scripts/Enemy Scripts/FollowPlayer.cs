using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class FollowPlayer : MonoBehaviour {

    public Transform follow;

    NavMeshAgent agent;
    float timer = 0;

	// Use this for initialization
	void Start () {
	    agent = GetComponent<NavMeshAgent>();
        follow = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            agent.SetDestination(follow.position);
            timer = 1;
        }
        timer -= Time.deltaTime;
	}
}
