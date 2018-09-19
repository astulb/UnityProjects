using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PeonController : PieceController
{

    public float startLine;
    public float transformToQueenLine;
    public GameObject queen;

    public override void LoadPosibleMoves()
    {
        MoveLocations = new List<Vector3>();
        float adelanteDependiendoDireccion = 1 * Mathf.Cos((transform.localEulerAngles.y * Mathf.PI) / 180);

        //Checkea movimiento adelante
        Vector3 adelante = transform.position + new Vector3(0,0, adelanteDependiendoDireccion);
        if (gameController.CheckFree(adelante))
        {
            MoveLocations.Add(adelante);

            //Checkea movimiento inicial
            Vector3 dosPasosAdelante = adelante + new Vector3(0, 0, adelanteDependiendoDireccion);
            if (transform.position.z == startLine && gameController.CheckFree(dosPasosAdelante))
            {
                MoveLocations.Add(adelante + new Vector3(0, 0, adelanteDependiendoDireccion));

            }
        }

        //Checkea movimiento adelante derecha
        Vector3 adelanteDerecha = transform.position + new Vector3(1, 0, adelanteDependiendoDireccion);
        if (gameController.CheckOponent(adelanteDerecha))
        {
            MoveLocations.Add(adelanteDerecha);
        }

        //Checkea movimiento adelante izquierda
        Vector3 adelanteIzquierda = transform.position + new Vector3(-1, 0, adelanteDependiendoDireccion);
        if (gameController.CheckOponent(adelanteIzquierda))
        {
            MoveLocations.Add(adelanteIzquierda);
        }
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
    }

    


}
