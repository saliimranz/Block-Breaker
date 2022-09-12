using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;
    // Start is called before the first frame update

    private void Awake()
    {
        Debug.Log("Music Player Awake" + GetInstanceID());
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate Music Player self Destructing");

        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
