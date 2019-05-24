using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);   
    }

    private void Start()
    {
        // Load Splash screen
        // Load Menu
        
        SceneManager.LoadScene("1-3"); // Temporaly first world
    }
}
