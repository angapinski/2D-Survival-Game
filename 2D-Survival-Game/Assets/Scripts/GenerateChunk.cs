using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunk : MonoBehaviour {

    //Block Game Objects
    public GameObject dirtBlock;
    public GameObject dirtWithGrassBlock;
    public GameObject dirtWithSurfaceBlock;
    public GameObject stoneBlock;

    public int width;
    public float heightMultiplier;
    public float smoothness;

    private int mapSeed;

	void Start () {
        mapSeed = Random.Range(-10000, 10000);
        Generate();
    }
	
	void Generate () {
        for(int i = 0; i < width; i++)
        {
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(1f * smoothness, i / 3f) * heightMultiplier);
            
            for (int j = 0; j < h; j++)
            {
                GameObject selectedBlock;
                if (j < h - 4)
                {
                    selectedBlock = stoneBlock;
                }
                else if (j < h - 1)
                {
                    selectedBlock = dirtBlock;
                }
                else
                {
                    selectedBlock = dirtWithGrassBlock;
                }


                Instantiate(selectedBlock, new Vector3(i, j), Quaternion.identity);
            }
        }
		
	}
}
