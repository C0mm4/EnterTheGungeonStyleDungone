using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StageController
{


    public List<DunRoom> rooms;
    public List<GameObject> corridors;
    public List<GameObject> gates;
    public bool[] isClear;
    public bool[] isVIsit;
    public int currentRoom;
    public int roomNo;
    public int stageNo;


    public bool isTutorial = false;


    // When Game Starts Create Stage 1 Dungeon
    public void init()
    {
        if(rooms != null)
            if(rooms.Count >= 0)
            {
                rooms.Clear();
            }
        if(gates != null)
            if(gates.Count >= 0)
            {
                gates.Clear();
            }
        rooms = new List<DunRoom>();
        gates = new List<GameObject>();
        isClear = new bool[0];
        isVIsit = new bool[0];
    }
    public void gameStart()
    {
        isTutorial = false;
        stageNo = 1;
        startStage();
    }

    // When Next Stage trigger begins Create Next Stage Dungeion.
    public void nextStage()
    {
        stageNo++;
        startStage();
    }

    // Dungeon Create
    private void startStage()
    {

        int roomNom = 6;
        int roomNoM = 7;

        roomNom += stageNo;
        roomNoM += stageNo * 2;
        int roomN = GameManager.Random.getMapNext(roomNom, roomNoM);

        (rooms, corridors) = GameManager.MapGen.DungeonGen(roomN);

    }



    // Clear Buffer
    public void clear()
    {
        if (rooms != null)
        {
            foreach (DunRoom go in rooms)
            {
                if(go != null)
                    GameManager.Resource.Destroy(go.gameObject);
            }
            rooms.Clear();
            foreach (GameObject go in gates)
            {
                if(go != null)
                    GameManager.Resource.Destroy(go);
            }
            gates.Clear();
            isClear = new bool[0];
            isVIsit = new bool[0];
        }
    }
}
