using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
	
	public GameObject spawnObject;
	public GameObject roomPrefab;
	public GameObject corridorPrefab;
	private GameObject holder;
	public GameObject controller;
		
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(GenerateMeADungeonPlease());
	}

	IEnumerator GenerateMeADungeonPlease()
	{
		//first lets create a holder for for the dungeon
		holder = new GameObject("Env");
		holder.transform.position= new Vector3(0,0,0);
		
		//now lets put down a room
		GameObject firstRoom = Instantiate(roomPrefab, spawnObject.transform);
		firstRoom.transform.parent = holder.transform;
		//Now lets make a whole for the door
		GameObject tempWall = firstRoom.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
		Destroy(tempWall);
		//Now lets spawn a corridor
		spawnObject.transform.position = new Vector3(spawnObject.transform.position.x, spawnObject.transform.position.y, spawnObject.transform.position.z + 18f);
		GameObject corridor = Instantiate(corridorPrefab, spawnObject.transform);
		corridor.transform.parent = holder.transform;
		//now lets spawn a new room
		spawnObject.transform.position = new Vector3(spawnObject.transform.position.x, spawnObject.transform.position.y, spawnObject.transform.position.z + 18f);	
		GameObject mainRoom = Instantiate(roomPrefab, spawnObject.transform);
		mainRoom.transform.parent = holder.transform;
		//now lets create an opening 
		GameObject tempWall2 = mainRoom.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
		Destroy(tempWall2);
		
		yield return null;
		
		//now lets see if we can make this a little better.
		
		
	}


	private void Update() {
		if (Input.GetKeyDown(KeyCode.R))
		{
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			controller.SetActive(true);	
		}		
		
	}


}
