using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{    
    float levelLoadDelay = 10f;
    AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {        
        Invoke("LoadNextScene", levelLoadDelay);
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //private void StartTheGame()
    //{        
    //    LoadNextScene();
    //}
}
