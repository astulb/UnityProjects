using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : PieceController {

    public override List<Vector3> LoadPosibleMoves()
    {
        List<Vector3> locations = new List<Vector3>();

        string tagEnemigos = ColorEnemigo();

        List<Vector3> enemyPosibleMoves = EnemyPosibleMoves(tagEnemigos);

        for (int ejeXvar = -1; ejeXvar <= 1; ejeXvar++)
        {
            for (int ejeZvar = -1; ejeZvar <= 1; ejeZvar++)
            {
                Vector3 posToCheck = new Vector3(transform.position.x + ejeXvar, 0, transform.position.z + ejeZvar);

                if (gameController.CheckFree(posToCheck))
                {
                    if (!enemyPosibleMoves.Contains(posToCheck))
                    {
                        locations.Add(posToCheck);
                    }
                }
                if (gameController.CheckOponent(posToCheck))
                {
                    locations.Add(posToCheck);
                }
            }
        }
        return locations;
    }

    private List<Vector3> EnemyPosibleMoves(string tagEnemigos)
    {
        var enemigos = GameObject.FindGameObjectsWithTag(tagEnemigos);

        List<Vector3> posibleMovePositions = new List<Vector3>();

        for (int i = 0; i < enemigos.Length ; i++)
        {
            GameObject enemigo = enemigos[i];

            if(enemigo.name != ("King" + tagEnemigos))
            {
                posibleMovePositions.AddRange(enemigos[i].GetComponent<PieceController>().LoadPosibleMoves());
            }
            else
            {
                for (int ejex = -1; ejex <= 1; ejex++)
                {
                    for (int ejez = -1; ejez <= 1; ejez++)
                    {
                        Vector3 movReyEnemigo = new Vector3(enemigo.transform.position.x + ejex, 0, enemigo.transform.position.z + ejez);
                        posibleMovePositions.Add(movReyEnemigo);
                    }
                }
            }
            
        }
        return posibleMovePositions;
    }

    private string ColorEnemigo()
    {
        if(gameObject.tag == "Light")
        {
            return "Dark";
        }
        else
        {
            return "Light";
        }
    }
}
