using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaballoController : PieceController {

    public override List<Vector3> LoadPosibleMoves()
    {
        List<Vector3> locations = new List<Vector3>();
        for (int ejeXvar = -2; ejeXvar <= 2; ejeXvar++)
        {
            for (int ejeZvar = -2; ejeZvar <= 2; ejeZvar++)
            {
                Vector3 posToCheck = new Vector3(transform.position.x + ejeXvar, 0, transform.position.z + ejeZvar);

                bool soloUnEjeEs2 = (Mathf.Abs(ejeXvar) == 2) ^ (Mathf.Abs(ejeZvar) == 2);
                bool ningunEjeEs0 = (ejeXvar != 0) && (ejeZvar != 0);

                if (soloUnEjeEs2 && ningunEjeEs0)
                {
                    if (gameController.CheckFree(posToCheck))
                    {
                        locations.Add(posToCheck);
                    }                   
                    else if (gameController.CheckOponent(posToCheck))
                    {
                        locations.Add(posToCheck);
                    }
                }
            }
        }
        return locations;
    }
}
