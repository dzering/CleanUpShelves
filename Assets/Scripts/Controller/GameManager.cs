using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ShelfView shelf2;
    [SerializeField] ShelfView shelf;
    [SerializeField] BookView book;



    PlayerController playerController;

    ShelfController shelfController;
    ShelfController shelfController2;

    private void Start()
    {
        shelfController = new ShelfController(shelf, book);
        shelfController2 = new ShelfController(shelf2, book);
        playerController = new PlayerController();
    }

    private void Update()
    {
        playerController.Update();
    }
}
