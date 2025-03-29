using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    float secondDelay = 2f;
    private int xPosition, yPosition;
    private Player.Direction directionFace;

    public int Points { get; private set; } = 2;


    // Start is called before the first frame update
    private void Start()
    {
        //addFishToPond(4, 0, Player.Direction.DOWN);
    }

    public void addFishToPond(int x, int y, Player.Direction direction)
    {
        directionFace = direction;
        SetPosition(x, y);
        StartCoroutine(repeatMovement());
    }

    IEnumerator repeatMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondDelay);
            Move(directionFace);
        }
    }

    public void SetPosition(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < 7 && y < 7)
        {
            Ice.instance.iceSquares[xPosition, yPosition].fishOnTile.Remove(this);
            Ice.instance.iceSquares[x, y].fishOnTile.Add(this);
            transform.position = Ice.instance.iceSquares[x, y].tile.transform.position;
            xPosition = x;
            yPosition = y;
            if(Ice.instance.iceSquares[x, y].playerPresent && Ice.instance.iceSquares[x, y].iceBroken)
            {
                Caught();
            }
        }
        else
        {
            Despawn();
        }
    }

    void Move(Player.Direction direction)
    {
        switch (direction)
        {
            case Player.Direction.UP:
                SetPosition(xPosition, yPosition - 1);
                break;
            case Player.Direction.DOWN:
                SetPosition(xPosition, yPosition + 1);
                break;
            case Player.Direction.LEFT:
                SetPosition(xPosition + 1, yPosition);
                break;
            case Player.Direction.RIGHT:
                SetPosition(xPosition - 1, yPosition);
                break;
        }
    }

    public void Caught()
    {
        RoundInfo.instance.AddPoints(Points);
        Despawn();
    }

    void Despawn()
    {
        //Ice.instance.iceSquares[xPosition, yPosition].fishOnTile.Remove(this);
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}



