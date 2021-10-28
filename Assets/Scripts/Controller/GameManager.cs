using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BookView book;
    [SerializeField] ShelfView[] shelves;
    ShelfController[] shelvesControllers;

    PlayerController playerController;


    private void Start()
    {
        shelvesControllers = new ShelfController[shelves.Length];
        for (int i = 0; i < shelves.Length; i++)
        {
            shelvesControllers[i] = new ShelfController(shelves[i], book);
        }

        playerController = new PlayerController();
    }

    private void Update()
    {
        playerController.Update();
    }
}
