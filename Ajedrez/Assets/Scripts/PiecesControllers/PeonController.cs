using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PeonController : PieceController
{
    public float comerAlPaso;
    public float startLine;
    public float transformToQueenLine;
    public GameObject queen;

    public override List<Vector3> LoadPosibleMoves()
    {
        List<Vector3> locations = new List<Vector3>();
        float adelanteDependiendoDireccion = 1 * Mathf.Cos((transform.localEulerAngles.y * Mathf.PI) / 180);

        //Checkea movimiento adelante
        Vector3 adelante = transform.position + new Vector3(0,0, adelanteDependiendoDireccion);
        if (gameController.CheckFree(adelante))
        {
            locations.Add(adelante);

            //Checkea movimiento inicial
            Vector3 dosPasosAdelante = adelante + new Vector3(0, 0, adelanteDependiendoDireccion);
            if (transform.position.z == startLine && gameController.CheckFree(dosPasosAdelante))
            {
                locations.Add(adelante + new Vector3(0, 0, adelanteDependiendoDireccion));

            }
        }

        //Checkea movimiento adelante derecha
        Vector3 adelanteDerecha = transform.position + new Vector3(1, 0, adelanteDependiendoDireccion);
        if (gameController.CheckOponent(adelanteDerecha))
        {
            locations.Add(adelanteDerecha);
        }

        //Checkea movimiento adelante izquierda
        Vector3 adelanteIzquierda = transform.position + new Vector3(-1, 0, adelanteDependiendoDireccion);
        if (gameController.CheckOponent(adelanteIzquierda))
        {
            locations.Add(adelanteIzquierda);
        }

        //Chequear comer al pazo   
        if(gameController.PeonSeMovio != null && comerAlPaso == transform.position.z)
        {
            Vector3 myPosition = transform.position;
            Vector3 peonEnemyPosition = gameController.PeonSeMovio.transform.position;
            if (myPosition.z == peonEnemyPosition.z && (myPosition.x == peonEnemyPosition.x+1|| myPosition.x == peonEnemyPosition.x -1))
            {
                Vector3 comerAlPaso = new Vector3(peonEnemyPosition.x, 0, peonEnemyPosition.z + adelanteDependiendoDireccion);

                locations.Add(comerAlPaso);
            }
        }      
        

        

        return locations;
    }

    override public void MoveTo(Vector3 newPos)
    {
        string queenName = "Queen"+gameObject.tag;
        if(newPos.z  == transformToQueenLine && !GameObject.Find(queenName))
        {
            Instantiate(queen, newPos, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.position = newPos;
        }

        gameController.PeonSeMovio = gameObject;

    }

    


}
