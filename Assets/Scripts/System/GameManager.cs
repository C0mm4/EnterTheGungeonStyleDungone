using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager gm_Instance;
    public static GameManager Instance
    {
        get
        {
            // if instance is NULL create instance
            if (!gm_Instance)
            {
                gm_Instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (gm_Instance == null)
                    Debug.Log("instance is NULL_GameManager");
            }
            return gm_Instance;
        }
    }
    [SerializeField]


    public Action SceneChangeAction;

    ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return gm_Instance._resource; } }

    MapGen _mapGen = new MapGen();
    public static MapGen MapGen { get { return gm_Instance._mapGen; } }

    RandomEncounter _randomEncounter = new RandomEncounter();
    public static RandomEncounter Random { get { return gm_Instance._randomEncounter; } }

    StageController _stageController = new StageController();
    public static StageController StageC { get { return gm_Instance._stageController; } }

    public struct SerializedGameData
    {
        public List<Resolution> resolutionList;
        // 해상도 목록
        public Resolution resolution;
        // 현재 해상도
        public bool isFullscreen;
        public float gameVolume;
        // 전체 볼륨
        public float musicVolume;
        // 배경음악 볼륨
        public float effectVolume;
        // 효과음 볼륨
    }

    public static SerializedGameData gameData;
    public GameObject persistentObject;
    // == this

    // 시스템 변수

    private void Awake()
    {
        gm_Instance = this;
        init();
        gameStart();
    }

    // Initialize System Components
    public void init()
    {
        Debug.Log("GameManager Awake Init");

        Random.init("");
        MapGen.init();
        StageC.init();
    }


    // Stage Scene Game Start
    public void gameStart()
    {
        mapgen();
    }

   
    public static void mapgen()
    {
        clear();
        StageC.gameStart();
    }

    public void NexStage()
    {
        StageC.nextStage();
    }

    public void AddRoom()
    {
        MapGen.AddRoomForTest();
    }

    public static void clear()
    {
        StageC.clear();
        MapGen.clear();
    }

    private void OnDrawGizmosSelected()
    {
        var list = MapGen.AblePos;
        foreach(var item in list)
        {
            Gizmos.DrawCube(item * 2.56f, Vector3.one * 2.56f);
        }
    }

}
