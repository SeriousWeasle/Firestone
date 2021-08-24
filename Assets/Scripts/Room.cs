using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("List of occupied and mount blocks the room prefab has")]
    public List<Vector3> relativeOccupiedBlocks;
    public List<Vector3> relativeMountPoints;

    public RoomData getData()
    {
        List<Vector3> occ = new List<Vector3>();
        List<Vector3> mnt = new List<Vector3>();
        
        foreach(Vector3 o in relativeOccupiedBlocks)
        {
            occ.Add(o + gameObject.transform.position);
        }

        foreach(Vector3 m in relativeMountPoints)
        {
            mnt.Add(m + gameObject.transform.position);
        }

        return new RoomData(occ, mnt);
    }
}

[System.Serializable]
public struct RoomData
{
    public List<Vector3> occupiedBlocks;
    public List<Vector3> mountPoints;

    public RoomData(List<Vector3> occupiedBlocks, List<Vector3> mountPoints)
    {
        this.occupiedBlocks = occupiedBlocks;
        this.mountPoints = mountPoints;
    }
}