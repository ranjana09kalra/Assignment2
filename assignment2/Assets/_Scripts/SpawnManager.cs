using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public GameObject platform;
    public List<GameObject> platforms;
    public GameObject lastPlatform;

    private Vector2 originposition;

    void spawn()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector2 randomposition = originposition + new Vector2(Random.Range(5, 10), Random.Range(5, -5));
            Instantiate(platform, randomposition, Quaternion.identity);
            originposition = randomposition;
                
         }
    }
	// Use this for initialization
	void Start () {
        originposition = transform.position;
        //lastPlatform.transform.position = transform.position;

        // loop through and find the greater]st x value
        // then loop through again with if statement checking for (==) greatest value
        // assign code down below
        foreach (var platform in platforms)
        {
            if(platform.transform.position.x > lastPlatform.transform.position.x)
            {
                lastPlatform = platform;
                lastPlatform.transform.position = platform.transform.position;
            }
        }



        //spawn();

	}

    public void UpdateLastPlatform()
    {
        foreach (var platform in platforms)
        {
            if (platform.transform.position.x > lastPlatform.transform.position.x)
            {
                lastPlatform.transform.position = platform.transform.position;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
