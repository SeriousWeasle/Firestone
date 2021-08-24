using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [Header("Dungeon size")]
    public int minPropagationRoomCount;
    public int maxPropagationRoomCount;
    [Header("Start and exit room types")]
    public List<GameObject> startRoomPrefabs;
    public List<GameObject> exitRoomPrefabs;
    [Header("Propagation and termination rooms")]
    public List<GameObject> propagationRoomPrefabs;
    public List<GameObject> terminationRoomPrefabs;
    [Header("Where rooms are and where rooms can be")]
    public List<Vector3> occupiedGridBlocks;
    public List<Vector3> mountPointLocations;

    int propagationRoomCount;
    // Start is called before the first frame update
    void Start()
    {
        //Add start room
        GameObject startRoom = Instantiate(startRoomPrefabs[Random.Range(0, startRoomPrefabs.Count - 1)]);
        //get occupied blocks and stuff from room
        RoomData data = startRoom.GetComponent<Room>().getData();
        //Add occupied grid blocks and mount points for start room
        occupiedGridBlocks.AddRange(data.occupiedBlocks);
        mountPointLocations.AddRange(data.mountPoints);

        //get a number for propagation room count
        propagationRoomCount = Random.Range(minPropagationRoomCount, maxPropagationRoomCount);
    }

    // Update is called once per frame
    void Update()
    {

    }
}