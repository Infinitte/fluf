using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private int levelX;
    private int levelY;
    static Vector2 posPlayer = new Vector2 (-6f, -2.06f);

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            InstantiatePlayer();
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void InstantiatePlayer()
    {
        if (posPlayer.x<=-6.6f)
        {
            posPlayer.x = 6.5f;
            posPlayer.y = -2.06f;
        }
        else if (posPlayer.x >= 6.6f)
        {
            posPlayer.x = -6.5f;
            posPlayer.y = -2.06f;
        }
        Vector3 playerPostion = new Vector3(posPlayer.x, posPlayer.y, 0);

        player = (GameObject)Instantiate(Resources.Load("Fluf"), playerPostion, Quaternion.identity);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string[] level = scene.name.Split('-');
        levelX = int.Parse(level[0]);
        levelY = int.Parse(level[1]); 
    }

    void Update()
    {
        if (player.transform.position.x>=6.6f)
        {
            posPlayer = player.transform.position;
            string nextLevel = string.Format("{0}-{1}", levelX+1,levelY);
            Debug.Log("Next Level:" + nextLevel);

            SceneManager.LoadScene(nextLevel);
        }
        else if (player.transform.position.x <= -6.6f)
        {
            posPlayer = player.transform.position;
            string nextLevel = string.Format("{0}-{1}", levelX-1, levelY);
            Debug.Log("Next Level:" + nextLevel);

            SceneManager.LoadScene(nextLevel);
        }
    }
}
