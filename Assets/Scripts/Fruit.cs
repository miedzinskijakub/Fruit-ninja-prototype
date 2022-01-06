using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
	public float startForce = 15f;
	public GameObject splash;

	Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}



	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Blade")
		{
			Vector3 direction = (collision.transform.position - transform.position).normalized;
			Quaternion rotation = Quaternion.LookRotation(direction);
			
			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
			GameObject splashing = Instantiate(splash, transform.position, transform.rotation);
			splashing.transform.localScale += new Vector3(Random.Range(0.001f, 0.01f), Random.Range(0.001f, 0.01f), 1);
			Destroy(slicedFruit, 3f);
			Destroy(splashing, 3f);

			Destroy(gameObject);
		}
	}

}
