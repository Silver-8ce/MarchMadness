using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        UP, DOWN, LEFT, RIGHT
    }
    int xPosition, yPosition;

    void Start()
    {
        xPosition = 3; 
        yPosition = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Move(Direction.UP);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Move(Direction.DOWN);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Direction.RIGHT);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Move(Direction.LEFT);
        }
        if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            BreakIce();
        }
    }

    public void SetPosition(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < 7 && y < 7)
        {
            Ice.instance.iceSquares[xPosition, yPosition].PlayerExit();
            Ice.instance.iceSquares[x, y].PlayerEnter();
            transform.position = Ice.instance.iceSquares[x, y].tile.transform.position;
            xPosition = x;
            yPosition = y;
        }
    }

    public void BreakIce()
    {
        Ice.instance.iceSquares[xPosition, yPosition].BreakIce();
    }

    public void Move(Direction direction)
    {
        switch(direction)
        {
            case Direction.UP:
                SetPosition(xPosition, yPosition - 1);
                break;
            case Direction.DOWN:
                SetPosition(xPosition, yPosition + 1);
                break;
            case Direction.LEFT:
                SetPosition(xPosition + 1, yPosition);
                break;
            case Direction.RIGHT:
                SetPosition(xPosition - 1, yPosition);
                break;
        }
    }
}
