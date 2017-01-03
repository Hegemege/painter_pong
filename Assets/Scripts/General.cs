using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    public Color[] Colors;
    public Dictionary<PlayerSide, Color> PlayerColors;

    void Awake()
    {
        PlayerColors = new Dictionary<PlayerSide, Color>();

        PlayerColors[PlayerSide.None] = Colors[0];
        PlayerColors[PlayerSide.Left] = Colors[1];
        PlayerColors[PlayerSide.Right] = Colors[2];
    }

    void Start() 
    {
    
    }
    
    void Update() 
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
