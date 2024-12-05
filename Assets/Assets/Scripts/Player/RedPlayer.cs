using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : Players
{

    DiceRoll redDiceRoll;
    void Start()
    {
        redDiceRoll = GetComponentInParent<RedPlayerHome>().diceRoll;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.diceRoll != null)
        {
            if (!isReady)
            {
                if (GameManager.gm.diceRoll == redDiceRoll && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.playerCanMove)
                {
                    GameManager.gm.redPlayerOut += 1;
                    MakePlayerReadyToMove(pathParent.redPathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.diceRoll == redDiceRoll && isReady && GameManager.gm.playerCanMove)
            {
                GameManager.gm.playerCanMove = false;
                movePlayer(pathParent.redPathPoint);
            }
        }
    }
}
