using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : Players

{
    DiceRoll greenDiceRoll;
    void Start()
    {
        greenDiceRoll = GetComponentInParent<GreenPlayerHome>().diceRoll;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.diceRoll != null)
        {
            if (!isReady)
            {
                if (GameManager.gm.diceRoll == greenDiceRoll && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.playerCanMove)
                {
                    GameManager.gm.greenPlayerOut += 1;
                    MakePlayerReadyToMove(pathParent.greenPathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.diceRoll == greenDiceRoll && isReady && GameManager.gm.playerCanMove)
            {
                GameManager.gm.playerCanMove = false;
                movePlayer(pathParent.greenPathPoint);
            }
        }
    }
}
