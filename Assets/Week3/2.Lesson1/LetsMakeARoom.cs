using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsMakeARoom : MonoBehaviour
{
	
	[Header("Floors")]
	public GameObject[] floorSpawns;
	public GameObject[] floorTiles;

	[Header("Wall")]
	public GameObject[] wallSpawns;
	public GameObject[] wallTiles;	
	
	[Header("Torch")]
	public GameObject[] torchSpawns;
	public GameObject torchObject;	
	
	[Header("Items")]
	public GameObject[] itemSpawns;
	public GameObject ItemObject;
	
	[Header("Controller")]
	public GameObject controller;	
	
	// Start is called before the first frame update
	void Start()
	{
		floorSpawns = GameObject.FindGameObjectsWithTag("FloorSpawn");
		wallSpawns = GameObject.FindGameObjectsWithTag("WallSpawn");
		SpawnFloors();
		SpawnWalls();
		
		//SpawnTorches();
		//SpawnItems();
		
	}



	private void SpawnFloors()
	{
		for (int i = 0; i < floorSpawns.Length; i++)
		{
			GameObject floorTile = Instantiate (floorTiles[Random.Range(0, floorTiles.Length)], floorSpawns[i].transform);	
		}
	}
	
	private void SpawnWalls()
	{
		for (int i = 0; i < wallSpawns.Length; i++)
		{
			GameObject wallTile = Instantiate (wallTiles[Random.Range(0, wallTiles.Length)], wallSpawns[i].transform);
			wallTile.transform.localScale = new Vector3 (1.5f, 1, 1);	
		}
	}
	
	private void SpawnTorches()
	{
		torchSpawns = GameObject.FindGameObjectsWithTag("TorchSpawn"); 
		
		for (int i = 0; i < torchSpawns.Length; i++)
		{
			float coinFlip = Random.Range(0,1f);
			
			if (coinFlip >= 0.5f)
			{
				GameObject torch = Instantiate (torchObject, torchSpawns[i].transform);
			}
		}
	}
	
	private void SpawnItems()
	{
		itemSpawns = GameObject.FindGameObjectsWithTag("ItemSpawn"); 
		
		for (int i = 0; i < itemSpawns.Length; i++)
		{
			float coinFlip = Random.Range(0,1f);
			
			if (coinFlip >= 0.5f)
			{
				GameObject torch = Instantiate (ItemObject, itemSpawns[i].transform);
			}
		}
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
