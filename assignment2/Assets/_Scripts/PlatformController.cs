using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

    SpawnManager spawnManager;

	// Use this for initialization
	void Start () {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        spawnManager = gameController.GetComponent<SpawnManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Exit"))
        {
            Respone();
        }
    }

    void Respone()
    {
        spawnManager.UpdateLastPlatform();
        this.transform.position = spawnManager.lastPlatform.transform.position + new Vector3(0,0,0); // Random range for the new vector 3
    }
}
