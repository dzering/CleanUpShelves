using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ShelfView[] shelves;
    ShelfController[] shelvesControllers;

    PlayerController playerController;
    EndGameController endGameController;


    private void Start()
    {
        shelvesControllers = new ShelfController[shelves.Length];
        for (int i = 0; i < shelves.Length; i++)
        {
            shelvesControllers[i] = new ShelfController(shelves[i]);
        }

        endGameController = new EndGameController(shelves);
        playerController = new PlayerController();

        playerController.OnSwap += endGameController.Check;
    }

    private void Update()
    {
        playerController.Update();
    }
}
