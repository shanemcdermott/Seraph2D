using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction
{
    public const int Right = 0,
        Left = 1,
        UpRight = 2,
        Up = 3,
        UpLeft = 4,
        DownRight = 5,
        Down = 6,
        DownLeft = 7;
    

    public static int FromVector2(Vector2 A)
    {
        //Right
        if(A.x>0)
        {
            if(A.y>0)
            {
                return Direction.UpRight;
            }
            else if(A.y<0)
            {
                return Direction.DownRight;
            }
            else
            {
                return Direction.Right;
            }
        }
        //Left
        else if(A.x < 0)
        {
            if(A.y > 0)
            {
                return Direction.UpLeft;
            }
            else if(A.y < 0)
            {
                return Direction.DownLeft;
            }
            else
            {
                return Direction.Left;
            }
        }
        //Up
        else if(A.y > 0)
        {
            return Direction.Up;
        }
        else if(A.y < 0)
        {
            return Direction.Down;
        }
        else
        {
            return -1;
        }
    }
}
