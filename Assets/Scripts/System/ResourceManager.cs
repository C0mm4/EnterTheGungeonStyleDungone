using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;
using UnityEngine.SearchService;


// ���ҽ��� Load, Instantiate, Destroy �� �����ϴ� ���ҽ� �Ŵ���. 
public class ResourceManager
{

    public int a = 1;
    public int geta() { return a; }
    // path�� �ִ� ������ �ε��ϴ� �Լ�, �ε�Ǵ� ������ Object �� ��
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