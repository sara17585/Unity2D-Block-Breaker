using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;
    

    SceneLoader sceneloader;

    public void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }


    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    
    public void CountBrokenBlocks()
    {

        breakableBlocks--;

        if (breakableBlocks<=0)
        {
            sceneloader.LoadNextScene();

        }
    }
    
}
