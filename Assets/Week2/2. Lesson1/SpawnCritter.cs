using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class SpawnCritter : MonoBehaviour {

	[Header("Part1")]
	public GameObject critter;
	public Transform spawnpoint;
	[Header("Part2")]	
	public bool RandomSpawnpoint;
	public Collider randomCollider;
	[Header("Part3")]
	public GameObject[] objects;
	public bool RandomObject;
	[Header("Part4")]
	public bool GoCrazy;
	private bool Started;
	

	// Update is called once per frame
	void Update () {
		
		if(!GoCrazy)
		{
			if (Input.anyKeyDown) {
				SpawnObject(); //runs the spawn object method
			}
		}
		else
		{
			if (!Started)
			{
				StartCoroutine(ItsGoingCrazy()); //makes things go crazy for a while
			}
		}

	}
	
	public void SpawnObject()
	{
		if (RandomSpawnpoint)
		{
			spawnpoint.position = RandomPointInBounds(randomCollider.bounds); //Runs the random position function
		}
		
		if (RandomObject)
		{
			critter = objects[Random.Range(0, objects.Length)]; //chooses a random object
		}
		
		GameObject clone = Instantiate(critter, spawnpoint); //spawns an object at a given point
		clone.transform.parent = null; //changes the parent object of the object spawned
	}
	
	public Vector3 RandomPointInBounds(Bounds bounds) { // creates a random vector inside a designated area
		return new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			Random.Range(bounds.min.y, bounds.max.y),
			Random.Range(bounds.min.z, bounds.max.z)
		);
	}	
	
	IEnumerator ItsGoingCrazy()
	{
		Started = true;
		int totalSpawns = 500;
		int spawned = 0;
		
		while (spawned < totalSpawns)
		{
			SpawnObject();
			spawned++;
			yield return new WaitForSeconds(0.1f);
		}

	}
}
