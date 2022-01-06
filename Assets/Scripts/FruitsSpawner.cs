using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{

    public GameObject appleReference;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    //Vector2 throwForce = new Vector2(0, 10);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());

    }

     IEnumerator Spawn()
    {
		while (true)
		{
            float delay = Random.Range(minDelay, maxDelay);

            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject spawnedFruit = Instantiate(appleReference, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
		}
        
       }
}