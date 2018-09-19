using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinaController : PieceController
{
    public override List<Vector3> LoadPosibleMoves()
    {
        List<Vector3> locations = new List<Vector3>();
        for (int ejeXvar = -1; ejeXvar <= 1; ejeXvar++)
        {
            for (int ejeZvar = -1; ejeZvar <= 1; ejeZvar++)
            {
                Vector3 posToCheck = new Vector3(transform.position.x + ejeXvar, 0, transform.position.z + ejeZvar);

                while (gameController.CheckFree(posToCheck))
                {
                    locations.Add(posToCheck);
                    posToCheck = new Vector3(posToCheck.x + ejeXvar, 0, posToCheck.z + ejeZvar);
                }
                if (gameController.CheckOponent(posToCheck))
                {
                    locations.Add(posToCheck);
                }
            }
        }
        return locations;
    }
}
