using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : Players
{

    DiceRoll yellowDiceRoll;
    void Start()
    {
        yellowDiceRoll = GetComponentInParent<YellowPlayerHome>().diceRoll;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.diceRoll != null)
        {
            if (!isReady)
            {
                if(GameManager.gm.diceRoll == yellowDiceRoll && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.playerCanMove)
                {
                    GameManager.gm.yellowPlayerOut += 1;
                    MakePlayerReadyToMove(pathParent.yellowPathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.diceRoll == yellowDiceRoll && isReady && GameManager.gm.playerCanMove)
            {
                GameManager.gm.playerCanMove = false;
                movePlayer(pathParent.yellowPathPoint);
            }

        }
    }

}
