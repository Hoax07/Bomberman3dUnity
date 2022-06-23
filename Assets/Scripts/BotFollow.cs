using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BotFollow : MonoBehaviour
{
    private Transform target;
    public float delay = 0;
    IAstarAI agent;
    float switchTime = float.PositiveInfinity;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<IAstarAI>();
	}
    private void Start()
    {
		target = transform.parent.gameObject.GetComponent<SpawnBots>().playerforfollow;
		GetComponent<AILerp>().speed = transform.parent.gameObject.GetComponent<SpawnBots>().GameData.GetComponent<GameData>().SpeedBots;
	}

    void Update()
	{
		bool search = false;

		if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
		{
			switchTime = Time.time + delay;
		}

		if (Time.time >= switchTime)
		{
			search = true;
			switchTime = float.PositiveInfinity;
		}

		agent.destination = target.position;

		if (search) agent.SearchPath();
	}
}
