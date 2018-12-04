using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunk : MonoBehaviour {

    //Block Game Objects
    public GameObject dirtBlock;
    public GameObject dirtWithGrassBlock;
    public GameObject dirtWithSurfaceBlock;
    public GameObject stoneBlock;
    public GameObject coalBlock;
    public GameObject copperBlock;
    public GameObject ironBlock;
    public GameObject goldBlock;

    //Ore Chances
    public float coalChance = 2f;
    public float copperChance = 3f;
    public float ironChance = 2f;
    public float goldChance = 1f;

    //Max ore groups per chunk
    public int maxCoalGroups = 1;
    public int maxCopperGroups = 1;
    public int maxIronGroups = 1;
    public int maxGoldGroups = 1;

    public int width;
    public float heightMultiplier;
    public int heightAddition;
    public float smoothness;

    [HideInInspector]
    public int mapSeed;

	void Start () {
        mapSeed = Random.Range(-10000, 10000);
        Generate();
    }

    private void OnMouseDown()
    {
        Generate();
    }

    void Generate () {
        for(int i = 0; i < width; i++)
        {
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(mapSeed, (i + transform.position.x) / smoothness) * heightMultiplier) + heightAddition;
            
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


                GameObject newTile = Instantiate(selectedBlock, Vector3.zero, Quaternion.identity) as GameObject;
                newTile.transform.parent = this.gameObject.transform;
                newTile.transform.localPosition = new Vector3(i, j);
            }
        }
		
	}

    public void populateOres()
    {

    }
}
