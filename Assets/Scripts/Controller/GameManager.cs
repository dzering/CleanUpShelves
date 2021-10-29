using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ShelfView[] shelves;
    ShelfController[] shelvesControllers;
    [SerializeField] TextView score;

    PlayerController playerController;
    EndGameController endGameController;
    ScoreController scoreController;

    ColorGenerator colorGenerator;


    private void Start()
    {
        scoreController = new ScoreController(score);
        colorGenerator = new ColorGenerator(shelves.Length);
        shelvesControllers = new ShelfController[shelves.Length];
        for (int i = 0; i < shelves.Length; i++)
        {
            shelvesControllers[i] = new ShelfController(shelves[i], colorGenerator);
        }

        endGameController = new EndGameController(shelves);
        playerController = new PlayerController();

        playerController.OnSwap += endGameController.Check;
        playerController.OnSwap += scoreController.Update;
    }

    private void Update()
    {
        playerController.Update();
    }
}
