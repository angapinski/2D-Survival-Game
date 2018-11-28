using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour {

    public GameObject chunk;
    private int chunkWidth;

    public int numChunks;
    public int mapSeed;

	// Use this for initialization
	void Start () {
        chunkWidth = chunk.GetComponent<GenerateChunk>().width;
        mapSeed = Random.Range(-10000, 10000);
        Generate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate()
    {
        int lastX = -chunkWidth;
        for(int i= 0; i < numChunks; i++)
        {
            GameObject newChunk = Instantiate(chunk, new Vector3(lastX + chunkWidth, 0f), Quaternion.identity);
            newChunk.GetComponent<GenerateChunk>().mapSeed = mapSeed;
            lastX += chunkWidth;
        }
    }
}
