using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;
using UnityEngine.SearchService;


// 리소스의 Load, Instantiate, Destroy 를 관리하는 리소스 매니저. 
public class ResourceManager
{

    public int a = 1;
    public int geta() { return a; }
    // path에 있느 파일을 로드하는 함수, 로드되는 조건은 Object 일 때
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }



    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        else
        {
            return Object.Instantiate(prefab, parent);
        }
    }


    public GameObject Instantiate(GameObject obj, Transform parent = null)
    {
        if (obj == null)
        {
            return null;
        }
        GameObject prefab = Object.Instantiate(obj, parent);
        if (prefab == null)
        {
            Debug.Log($"Failed to laod prefab : {obj.name}");
            return null;
        }
        return prefab;
    }


    // Loading Sprites in path
    public Sprite LoadSprite(string path)
    {
        Sprite spr;
        spr = Load<Sprite>($"Sprites/{path}");
        if (spr == null)
        {
            Debug.Log($"Failed to load Sprite : {path}");
            spr = Load<Sprite>($"Sprites/default");
            if(spr == null)
            {
                Debug.Log($"Failed to load Sprite : default");
            }
            Debug.Log(spr.name);
            return spr;
        }

        return spr;
    }

    // Destroy GameObject
    public void Destroy(GameObject go)
    {
        if (go == null) return;
        Object.Destroy(go);
    }

    // Destroy GameObjects
    public void Destroy(GameObject[] go)
    {
        foreach(GameObject g in go)
        {
            if(g != null)
            {
                Object.Destroy(g);
            }
        }
    }

}