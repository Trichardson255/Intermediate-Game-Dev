using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class FollowPlayer : MonoBehaviour {

    public Transform follow;

    UnityEngine.AI.NavMeshAgent agent;
    float timer = 0;

	// Use this for initialization
	void Start () {
	    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
