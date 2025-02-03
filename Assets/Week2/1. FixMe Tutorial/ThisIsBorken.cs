/*
public class ThisIsBorken : MonoBehaviour
{
	private GameObject worldZero;
	public GameObject groundObj;
	public GameObject spawnPoint;
	public GameObject building;
	[Range(1,10)]
	public int width;
	[Range(1,10)]
	public int height;
	private GameObject[] spawnPoints;
	
	
	// Start is called before the first frame update
	void Start()
	{
		worldZero = new GameObject("WorldZero");
		worldZero.transform.position= new Vector3(0,0,0);
		GameObject ground = Instantiate(groundObj, worldZero.transform);
		
		
		StartCoroutine(CreateSpawnpoints());
				
	}

	IEnumerator CreateSpawnpoints()
	{
		
		for (int i = 0; i < hieght; i++)
		{
			for (int a = 0; b < width; c++)
			{
				GameObject spawnpoint = Instantiate(spawnPoint, worldZero.transform);
				spawnpoint.transform.parent = null;
				spawnpoint.transform.position = worldZero.transform.position;
				worldZero.transform.position = new Vector3 (worldZero.transform.position.x, worldZero.transform.position.y, worldZero.transform.position.z + 2f);
				yield return new WaitForSeconds(0.1f);
			}
			
			worldZero.transform.position = new Vector3 (worldZero.transform.position.x + 2f, worldZero.transform.position.y, 0f);
		}
		
		CreateBuildings();
	}
	
	void CreateBuildings()
	{
		spawnPoints = GameObject.FindGameObjectsWithTag("spawnpoint");
		
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			int RandomHeight = Random.Range(3,6);
			for (int i = 0; i < RandomHeight; i++)
			{
				spawnPoints[i].transform.localPosition = new Vector3 (spawnPoints[i].transform.localPosition.x, spawnPoints[i].transform.localPosition.y + 1, spawnPoints[i].transform.localPosition.z);
				GameObject Building1 = Instantiate(building, spawnPoints[i].transform);
				Building1.GetComponent<MeshRenderer>().material.color = new Color (Random.Range(0,1f), Random.Range(0,1f), Random.Range(0,1f));
				yield return new WaitForSeconds(0.1f);
			}
			
		}
	}	
}

//When you get it working make sure you comment the code properly.

*/


















































































































































































































































































































































//////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////
////Oh and if you thought it was just the code you have to fix, well I aint that nice.////
//////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////