﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreController : PieceController {

    override public void LoadPosibleMoves()
    {
        MoveLocations = new List<Vector3>();

        for (int ejeXvar = -1; ejeXvar <= 1; ejeXvar++)
        {
            for (int ejeZvar = -1; ejeZvar <= 1; ejeZvar++)
            {
                if (ejeZvar == 0 || ejeXvar == 0)
                {
                    Vector3 posToCheck = new Vector3(transform.position.x + ejeXvar, 0, transform.position.z + ejeZvar);

                    while (gameController.CheckFree(posToCheck))
                    {
                        MoveLocations.Add(posToCheck);
                        posToCheck = new Vector3(posToCheck.x + ejeXvar, 0, posToCheck.z + ejeZvar);
                    }
                    if (gameController.CheckOponent(posToCheck))
                    {
                        MoveLocations.Add(posToCheck);
                    }
                }
                
            }
        }
    }
}
