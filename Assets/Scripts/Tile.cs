using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    [HideInInspector]
    public PlayerSide CurrentHolder;

    private SpriteRenderer spriteRenderer;
    private General general;

	void Awake()
	{
	    spriteRenderer = GetComponent<SpriteRenderer>();
	    general = GameObject.Find("General").GetComponent<General>();
	}

    void Start()
    {
        CurrentHolder = PlayerSide.None;
    }
    
    void Update()
    {
        spriteRenderer.color = general.PlayerColors[CurrentHolder];
    }
}
