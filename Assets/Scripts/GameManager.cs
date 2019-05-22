using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private int levelX;
    private int levelY;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene: " + scene.name);
        string[] level = scene.name.Split('-');
        levelX = int.Parse(level[0]);
        levelY = int.Parse(level[1]);
        Debug.Log("SceneY: " + levelY);
    }

    // Update is called once per frame
    void Update()
    { 
        if (player.transform.position.x>=6.6)
        {
            string nextLevel = string.Format("{0}-{1}", levelX, levelY+1);
            Debug.Log("Next Level:" + nextLevel);

            SceneManager.LoadScene(nextLevel);
        }
    }
}
