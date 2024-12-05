using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public int numberOfStepsToMove;
    public DiceRoll diceRoll;
    public bool playerCanMove = true;


    List<PathPoint> PlayerOnPathPointList = new List<PathPoint>();

    public bool canRollDice = true;
    public bool diceTransfer = false;
    public List<DiceRoll> diceRollList;

    public int bluePlayerOut;
    public int redPlayerOut;
    public int greenPlayerOut;
    public int yellowPlayerOut;

    private void Awake()
    {
        gm = this;

    }

    public void AddPathPoint(PathPoint pathPoint)
    {
        PlayerOnPathPointList.Add(pathPoint);
    }

    public void RemovePathPoint(PathPoint pathPoint)
    {
        if(PlayerOnPathPointList.Contains(pathPoint))
        {
            PlayerOnPathPointList.Remove(pathPoint);
        }
    }

    public void DiceRollTransfer()
    {
        int nextDice;
        if(diceTransfer)
        {
            for (int i = 0;i< diceRollList.Count;i++)
            {
                if (i == (diceRollList.Count - 1)) { nextDice = 0; } else { nextDice = i + 1; }
                 
               if(diceRoll==diceRollList[i])
               {
                  diceRollList[i].gameObject.SetActive(false);
                  diceRollList[nextDice].gameObject.SetActive(true);
               }

            }
        }
         canRollDice  = true;
        diceTransfer = false;  
    }
}
