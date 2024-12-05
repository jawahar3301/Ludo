using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : Players

{
    DiceRoll blueDiceRoll;
    void Start()
    {
        blueDiceRoll = GetComponentInParent<BluePlayerHome>().diceRoll;
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.diceRoll != null)
        {
            if (!isReady)
            {
                if (GameManager.gm.diceRoll == blueDiceRoll && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.playerCanMove)
                {
                    GameManager.gm.bluePlayerOut += 1;
                    MakePlayerReadyToMove(pathParent.bluePathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.diceRoll == blueDiceRoll && isReady && GameManager.gm.playerCanMove)
            {
                GameManager.gm.playerCanMove = false;
                movePlayer(pathParent.bluePathPoint);
            }
        }
      
       
    }

    
}
