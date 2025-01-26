using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateBuilding : MonoBehaviour
{
	
	public int numberOfTiers;
	public GameObject[] buildingParts;
	
	// Start is called before the first frame update
	void Start()
	{
		numberOfTiers = Random.Range(2,7);
	
		StartCoroutine(GenerateBuildings());
		
	}

   IEnumerator GenerateBuildings()
	{
		float yPos = 6;
		for (int i = 0; i < numberOfTiers; i++)
		{
			
			Instantiate(buildingParts[Random.Range(0, buildingParts.Length)], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity);
			yield return new WaitForSeconds (0.3f);
			yPos += 0.5f;
			Debug.Log (yPos);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
	}
}
