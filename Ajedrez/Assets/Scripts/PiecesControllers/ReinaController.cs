﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinaController : PieceController
{
    public override void ShowPosibleMoves()
    {
        for (int ejeXvar = -1; ejeXvar <= 1; ejeXvar++)
        {
            for (int ejeZvar = -1; ejeZvar <= 1; ejeZvar++)
            {
                Vector3 posToCheck = new Vector3(transform.position.x + ejeXvar, 0, transform.position.z + ejeZvar);

                while (gameController.CheckFree(posToCheck))
                {
                    Instantiate(validZone, posToCheck, transform.rotation);
                    posToCheck = new Vector3(posToCheck.x + ejeXvar, 0, posToCheck.z + ejeZvar);
                }
                if (gameController.CheckOponent(posToCheck))
                {
                    Instantiate(validZone, posToCheck, transform.rotation);
                }
            }
        }
    }
}
