using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunRoom : MonoBehaviour
{
    public int roomID;
    public int x, y;
    public int centerX, centerY;
    public GameObject Tiles;
    public List<Tile> tiles;

    public List<GameObject> doorTiles;
    public List<GameObject> Doors;
    public List<GameObject> DoorObjs;

    public List<DunRoom> ConnectRoom;
    public List<GameObject> ConnectCorridor;

    public int sizeX, sizeY;
}
