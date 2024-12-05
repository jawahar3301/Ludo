using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

    public bool moveNow;
    public bool isReady;
    public int numberStepsToMove;
    public int numberStepsAlreadyMoved;

    public PathPointParent pathParent;

    Coroutine playerMovement;

    public PathPoint previousPathPoint;
    public PathPoint currentPathPoint;
    private void Awake()
    {
        pathParent = FindObjectOfType<PathPointParent>(); 
    }
    void Start()
    {
        
    }

    public void MakePlayerReadyToMove(PathPoint[] pathParent_)
    {
        isReady = true;
        transform.position = pathParent_[0].transform.position;
        numberStepsAlreadyMoved = 1;
        GameManager.gm.numberOfStepsToMove = 0;
        previousPathPoint = pathParent_[0];
        currentPathPoint = pathParent_[0];
        currentPathPoint.AddPlayer(this); 

        GameManager.gm.AddPathPoint(currentPathPoint);
        GameManager.gm.DiceRollTransfer();
    }
    public void movePlayer(PathPoint[] pathParent_)
    {
       playerMovement= StartCoroutine(stepsToMove_enm(pathParent_));
    }
    IEnumerator stepsToMove_enm(PathPoint[] pathParent_)
    {
        numberStepsToMove = GameManager.gm.numberOfStepsToMove;
        for (int i = numberStepsAlreadyMoved; i < (numberStepsAlreadyMoved + numberStepsToMove); i++)
        {
            if(isPathPointAvailableToMove(numberStepsAlreadyMoved,numberStepsToMove,pathParent_))
            {
                transform.position = pathParent_[i].transform.position;
                yield return new WaitForSeconds(0.4f);
            }
            
        }
        if (isPathPointAvailableToMove(numberStepsAlreadyMoved, numberStepsToMove, pathParent_))
        {
            numberStepsAlreadyMoved += numberStepsToMove;

            GameManager.gm.numberOfStepsToMove = 0;
            GameManager.gm.RemovePathPoint(previousPathPoint);
            previousPathPoint.RemovePlayer(this);
            currentPathPoint = pathParent_[numberStepsAlreadyMoved - 1];
            currentPathPoint.AddPlayer(this);
            GameManager.gm.AddPathPoint(currentPathPoint);

            previousPathPoint = currentPathPoint;
            if(GameManager.gm.numberOfStepsToMove !=6)
            {
                GameManager.gm.diceTransfer = true;
            }
            GameManager.gm.numberOfStepsToMove = 0;
        }
            
        GameManager.gm.playerCanMove = true;
        GameManager.gm.DiceRollTransfer();

        if(playerMovement!=null)
        {
            StopCoroutine("stepsToMove_enm");
        }
    }

    bool isPathPointAvailableToMove(int numberStepsAlreadyMoved,int numberStepsToMove, PathPoint[] pathParent_ )
    {
        if(numberStepsToMove==0)
        {
            return false;
        }
        int numberOfPathsLeft = pathParent_.Length - numberStepsAlreadyMoved;
        if(numberOfPathsLeft>=numberStepsToMove)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
