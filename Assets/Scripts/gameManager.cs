using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    public float volumeValue = 0.5f;
    AudioSource audioSrc;
    [SerializeField] List<AudioClip> clips;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    void Update()
    {
        if (!audioSrc.isPlaying)
        {
            audioSrc.PlayOneShot(clips[Random.Range(0, clips.Count)]);
        }
    }
}
