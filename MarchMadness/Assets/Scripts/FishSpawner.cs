using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] GameObject straightFish;
    SpawnableLocations straightFishSpawn;
    int magnitude = 3;

    // Start is called before the first frame update
    void Start()
    {
       straightFishSpawn = new SpawnableLocations(straightFish);

       for(int i=0; i<Ice.dimension; i++)
        {
            straightFishSpawn.bottomRow.Add(new int[2] { i ,6});
            straightFishSpawn.topRow.Add(new int[2] { i, 0 });
            straightFishSpawn.rightCollumn.Add(new int[2] { 0, i });
            straightFishSpawn.leftCollumn.Add(new int[2] { 6, i });
        }

        StartSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine(FishWaves());
    }

    IEnumerator FishWaves()
    {
        while(RoundInfo.instance.RoundActive)
        {
            int amountOfFishToSpawn = Random.Range(0, magnitude);
            for( int i=0;i<amountOfFishToSpawn;i++)
            {
                SpawnFish(PickRandomFish());
            }
            yield return new WaitForSeconds(2f);
        }
    }

    private SpawnableLocations PickRandomFish()
    {
        int roll = Random.Range(0, 11);

        if(roll>=0 && roll <= 10)
        {
            return straightFishSpawn;
        }
        else
        {
            return straightFishSpawn;
        }


    }

    public void SpawnFish(SpawnableLocations fish)
    {

        Player.Direction direction = (Player.Direction)Random.Range(0, 4);

        switch (direction) {
            case (Player.Direction.UP):
                getSpawnLocation(fish.bottomRow);
                    break;
            case (Player.Direction.DOWN):
                getSpawnLocation(fish.topRow);
                break;
            case (Player.Direction.LEFT):
                getSpawnLocation(fish.rightCollumn);
                break;
            case(Player.Direction.RIGHT):
                getSpawnLocation(fish.leftCollumn);
                break;
        }

        void getSpawnLocation(List<int[]> list)
        {
            int[] location = list[Random.Range(0, list.Count)];
            //Spawns offscreen
            GameObject fishObject = Instantiate(fish.fish,new Vector3(20,20,0), transform.rotation);
            Fish fishType = fishObject.GetComponent<Fish>();
            fishType.addFishToPond(location[0], location[1], direction);
        }
    }

}

public class SpawnableLocations
{
    public GameObject fish;
    public List<int[]> bottomRow;
    public List<int[]> topRow;
    public List<int[]> leftCollumn;
    public List<int[]> rightCollumn;

    public SpawnableLocations(GameObject fishType)
    {
        bottomRow = new List<int[]>();
        topRow = new List<int[]>();
        leftCollumn = new List<int[]>();
        rightCollumn = new List<int[]>();
        fish = fishType;
    }

}

