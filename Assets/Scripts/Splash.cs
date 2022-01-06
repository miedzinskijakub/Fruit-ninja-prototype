using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    
    private Color randomAlpha;
    private float currentAlpha;
   // private float size;
    // Start is called before the first frame update
    void Start()
    {
       // size = Random.Range(0.01f, 0.5f);
       // gameObject.transform.localScale += new Vector3(size, size, 1);
        randomAlpha = new Color(1, 1, 1, Random.Range(0.3f, 0.5f));
        gameObject.GetComponent<Renderer>().material.color = randomAlpha;
        InvokeRepeating("ReduceAlpha", 0.3f, 0.3f);
    }

    void ReduceAlpha()
    {
        currentAlpha = gameObject.GetComponent<Renderer>().material.color.a;

        if (gameObject.GetComponent<Renderer>().material.color.a <= 0.1f)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, currentAlpha - 0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
