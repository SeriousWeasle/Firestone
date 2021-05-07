using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [Header("Chunk data")]
    public Vector3 chunkSize;

    [Header("Maximum room offsets (chunks)")]
    public int maxXOffset;
    public int maxYOffset;
    public int maxZOffset;

    [Header("Dungeon size")]
    public int minimumRooms;
    public float minStartExitDist;

    [Header("Debug stuff")]
    public GameObject startChunk;
    public GameObject exitChunk;
    public GameObject randomChunk;

    [Header("Look inside generator")]
    public List<Chunk> chunks;
    public GeneratorState generatorState = GeneratorState.Planning;

    // Start is called before the first frame update
    void Start()
    {
        planStartExitChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function for adding start and exit chunk to floorplan so there is at least a minimum distance between them
    void planStartExitChunk()
    {
        //choose random place for start room in bounds
        float startX = Mathf.Round((Random.value * chunkSize.x * 2) - chunkSize.x);
        float startY = Mathf.Round((Random.value * chunkSize.y * 2) - chunkSize.y);
        float startZ = Mathf.Round((Random.value * chunkSize.z * 2) - chunkSize.z);
        //make vector3 from random pos
        Vector3 startPos = new Vector3(startX, startY, startZ);
        //add the start room to the chunks
        chunks.Add(new Chunk(startPos, ChunkType.Start));
        //bool for storing if exit is far enough away
        bool exitIsFarEnough = false;
        //while the exit is not far enough away
        while (!exitIsFarEnough)
        {
            //pick random position
            float exitX = Mathf.Round((Random.value * chunkSize.x * 2) - chunkSize.x);
            float exitY = Mathf.Round((Random.value * chunkSize.y * 2) - chunkSize.y);
            float exitZ = Mathf.Round((Random.value * chunkSize.z * 2) - chunkSize.z);
            //make vector3 for exit pos
            Vector3 exitPos = new Vector3(exitX, exitY, exitZ);
            //if distance is greater or equal to minimum distance, add room and break loop
            if ((exitPos - startPos).magnitude >= minStartExitDist)
            {
                exitIsFarEnough = true;
                //add the exit room to the chunks
                chunks.Add(new Chunk(exitPos, ChunkType.Exit));
            }
        }
    }
}

//chunk type enumerator
public enum ChunkType
{
    Start, Exit, Random, Special
}

//struct for storing chunk data
[System.Serializable]
public struct Chunk
{
    //stored data
    public Vector3 gridPos;
    public ChunkType chunkType;
    //constructor
    public Chunk(Vector3 pos, ChunkType type)
    {
        this.gridPos = pos;
        this.chunkType = type;
    }
}

//generator state enum
public enum GeneratorState
{
    Planning, Identifying, Rendering, Done
}