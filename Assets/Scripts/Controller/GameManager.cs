using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ShelfView[] shelves;
    ShelfController[] shelvesControllers;

    PlayerController playerController;
    EndGameController endGameController;

    ColorGenerator colorGenerator;


    private void Start()
    {
        colorGenerator = new ColorGenerator(shelves.Length);
        shelvesControllers = new ShelfController[shelves.Length];
        for (int i = 0; i < shelves.Length; i++)
        {
            shelvesControllers[i] = new ShelfController(shelves[i], colorGenerator);
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
