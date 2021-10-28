using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookView : ObjectView
{
    ShelfView shelf;
    int id;

    public int ID { get => id; set => id = value; }
    public ShelfView Shelf { get => shelf; set => shelf = value; }
}
