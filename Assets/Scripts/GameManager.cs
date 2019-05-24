using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public GameObject playerPrefab;
    private int levelX;
    private int levelY;
    static string lastLevel = "";
    static Vector3 posPlayer = new Vector3 (-6f, -2.06f, 0f);
    static Vector2 velocityPlayer = new Vector2(0, 0);
    static int transitionMode = 0; // 0: scroll o caida, 1: salto, 2: puerta, 3: muerte, 4: teleport

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            InstantiatePlayer();
        }
        else
        {
            player.transform.SetPositionAndRotation(posPlayer, Quaternion.identity);
        }
    }

    void InstantiatePlayer()
    {
        player = Instantiate(playerPrefab, posPlayer, Quaternion.identity) as GameObject;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string[] level = scene.name.Split('-');
        levelX = int.Parse(level[0]);
        levelY = int.Parse(level[1]);
        SceneManager.MoveGameObjectToScene(player, scene);
        if (lastLevel != "")
        {
            SceneManager.UnloadSceneAsync(lastLevel);
        }
    }

    void Update()
    {
        if (player.transform.position.x>=8.6f)
        {
            posPlayer = player.transform.position;
            velocityPlayer = player.GetComponent<Rigidbody2D>().velocity;
            string nextLevel = string.Format("{0}-{1}", levelX+1,levelY);
            lastLevel = string.Format("{0}-{1}", levelX, levelY);
            posPlayer.x = -8.5f;
            transitionMode = 0;

            SceneManager.LoadScene(nextLevel, LoadSceneMode.Additive);
        }
        else if (player.transform.position.x <= -8.6f)
        {
            posPlayer = player.transform.position;
            velocityPlayer = player.GetComponent<Rigidbody2D>().velocity;
            string nextLevel = string.Format("{0}-{1}", levelX-1, levelY);
            lastLevel = string.Format("{0}-{1}", levelX, levelY);
            posPlayer.x = 8.5f;
            transitionMode = 0;

            SceneManager.LoadScene(nextLevel, LoadSceneMode.Additive);
        }
        else if (player.transform.position.y <= -3f)
        {
            posPlayer = player.transform.position;
            velocityPlayer = player.GetComponent<Rigidbody2D>().velocity;
            string nextLevel = string.Format("{0}-{1}", levelX, levelY-1);
            lastLevel = string.Format("{0}-{1}", levelX, levelY);
            posPlayer.y = 6.9f;
            transitionMode = 0;

            SceneManager.LoadScene(nextLevel, LoadSceneMode.Additive);
        }
        else if (player.transform.position.y >= 7f)
        {
            posPlayer = player.transform.position;
            velocityPlayer = player.GetComponent<Rigidbody2D>().velocity;
            string nextLevel = string.Format("{0}-{1}", levelX, levelY+1);
            lastLevel = string.Format("{0}-{1}", levelX, levelY);
            posPlayer.y = -2.5f;
            transitionMode = 1;

            SceneManager.LoadScene(nextLevel, LoadSceneMode.Additive);
        }
    }
}
