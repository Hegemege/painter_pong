using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TileGenerator : MonoBehaviour
{
    public GameObject TilePrefab;

    public int GridSize;

    private Text leftText;
    private Text rightText;

    private Tile[] tiles;

    void Awake()
	{
        tiles = new Tile[GridSize * GridSize];
	    leftText = GameObject.Find("LeftScore").GetComponent<Text>();
        rightText = GameObject.Find("RightScore").GetComponent<Text>();

        var startX = transform.position.x - 5.0f;
	    var startY = transform.position.y - 5.0f;

        var diffX = 10.0f / GridSize;
        var diffY = 10.0f / GridSize;

        var offsetX = 5.0f / GridSize;
        var offsetY = 5.0f / GridSize;

        // Instantiate all the tiles, no need to save them here
	    for (var i = 0; i < GridSize; i++)
	    {
	        for (var j = 0; j < GridSize; j++)
	        {
	            var tile = Instantiate(TilePrefab);
	            tiles[i + j*GridSize] = tile.GetComponent<Tile>();

                var x = startX + diffX * i + offsetX;
                var y = startY + diffY * j + offsetY;

                // Set the position and local scale of the tiles so that the whole area is filled
	            tile.transform.position = new Vector3(x, y, transform.position.z);
                tile.transform.localScale = new Vector3(diffX, diffY, 1.0f);

	        }
	    }
	}
    
    void Update()
    {
        var leftTiles = 0;
        var rightTiles = 0;

        for (var i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].CurrentHolder == PlayerSide.Left)
            {
                leftTiles++;
            }

            if (tiles[i].CurrentHolder == PlayerSide.Right)
            {
                rightTiles++;
            }
        }

        leftText.text = leftTiles.ToString();
        rightText.text = rightTiles.ToString();
    }
}
