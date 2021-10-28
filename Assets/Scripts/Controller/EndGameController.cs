using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController
{
    ShelfView[] shelves;
    bool isVictory = false;

    public EndGameController(ShelfView[] shelves)
    {
        this.shelves = shelves;
    }

    public bool IsVictory { get => isVictory; set => isVictory = value; }

    public bool Check()
    { 
        foreach (var shelf in shelves)
        {
            for (int i = 1; i < shelf.Books.Length; i++)
            {
                if(shelf.Books[i - 1].Color != shelf.Books[i].Color)
                {
                    return IsVictory == false;
                }
            }
        }

        Debug.Log("Game Over");
        return IsVictory == true;
    }
}
