using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float speed;
    private int xPosition, yPosition;
    private Player.Direction directionFace;
    public 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection()
    {

    }

    public void SetPosition(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < 7 && y < 7)
        {
            transform.position = Ice.instance.iceSquares[x, y].tile.transform.position;
            xPosition = x;
            yPosition = y;
            if(Ice.instance.iceSquares[x, y].playerPresent)
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

    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}



