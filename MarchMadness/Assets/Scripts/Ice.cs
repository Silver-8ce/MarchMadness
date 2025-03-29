using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Ice : MonoBehaviour
{
    const int dimension = 7;

    [SerializeField] private GameObject iceTilePrefab;
    public IceSquare[,] iceSquares = new IceSquare[7, 7];
    public static Ice instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        for(int x = 0; x < dimension; x++)
        {
            for(int y = 0; y < dimension; y++)
            {
                //If we change the number of tiles we have to change the math inside Vector2
                GameObject tile = Instantiate(iceTilePrefab, new Vector2(3-x,3-y), transform.rotation, transform);
                IceSquare square = new IceSquare(x,y, tile);
                iceSquares[x,y] = square;
            }
        }
    }

}

public class IceSquare
{
    public float xPosition;
    public float yPosition;
    public bool playerPresent;
    public bool iceBroken;
    public GameObject tile;
    public SpriteRenderer sprite;
    private Sprite tileSprite;

    public IceSquare(float xPos, float yPos, GameObject tile)
    {
        xPosition = xPos;
        yPosition = yPos;
        this.tile = tile;
        sprite = tile.GetComponent<SpriteRenderer>();
        iceBroken = false;
        playerPresent = false;
        tileSprite = sprite.sprite;
    }
   
    public void BreakIce()
    {
        iceBroken = true;
        sprite.sprite = null;
    }

    public void RepairIce()
    {
        iceBroken = false;
        sprite.sprite = tileSprite; 
    }

    public void PlayerEnter()
    {
        playerPresent = true;
    }

    public void PlayerExit()
    {
        playerPresent = false;
        RepairIce();
    }

}
