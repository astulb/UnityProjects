using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PeonController : PieceController
{

    public float startLine;
    public float transformToQueenLine;
    public GameObject queen;

    public override void ShowPosibleMoves()
    {
        float adelanteDependiendoDireccion = 1 * Mathf.Cos((transform.localEulerAngles.y * Mathf.PI) / 180);

        //Checkea movimiento adelante
        Vector3 adelante = transform.position + new Vector3(0,0, adelanteDependiendoDireccion);
        if (gameController.CheckFree(adelante))
        {
            Instantiate(validZone, adelante, transform.rotation);

            //Checkea movimiento inicial
            Vector3 dosPasosAdelante = adelante + new Vector3(0, 0, adelanteDependiendoDireccion);
            if (transform.position.z == startLine && gameController.CheckFree(dosPasosAdelante))
            {
                Instantiate(validZone, adelante + new Vector3(0, 0, adelanteDependiendoDireccion), transform.rotation);
            }
        }

        //Checkea movimiento adelante derecha
        Vector3 adelanteDerecha = transform.position + new Vector3(1, 0, adelanteDependiendoDireccion);
        if (gameController.CheckOponent(adelanteDerecha))
        {
            Instantiate(validZone, adelanteDerecha, transform.rotation);
        }

        //Checkea movimiento adelante izquierda
        Vector3 adelanteIzquierda = transform.position + new Vector3(-1, 0, adelanteDependiendoDireccion);
        if (gameController.CheckOponent(adelanteIzquierda))
        {
            Instantiate(validZone, adelanteIzquierda, transform.rotation);
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
