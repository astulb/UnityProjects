using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public string turno;

    private GameObject peonSeMovio;

    private PieceController selectedPiece;



    public GameObject PeonSeMovio
    {
        set
        {
            peonSeMovio = value;
        }
        get
        {
            return peonSeMovio;
        }
    }



    // Use this for initialization
    void Start() {
        turno = "Light";
    }

    public void SetSelectedPiece(PieceController piece)
    {
        selectedPiece = piece;
    }

    public PieceController GetSelectedPiece()
    {
        return selectedPiece;
    }

    public bool CheckTurn(string tag)
    {
        if(tag == turno) return true;
        return false;
    }

    public void PassTurn()
    {
        if(turno == "Light")
        {
            turno = "Dark";
        }
        else
        {
            turno = "Light";
        }
    }

    //Borra todos los cuadraditos verdes
    public void DeletePreviousMoveOptions()
    {
        GameObject[] previousPosibleMoves = GameObject.FindGameObjectsWithTag("MoveSpot");
        for (int i = 0; i < previousPosibleMoves.Length; i++)
        {
            Destroy(previousPosibleMoves[i]);
        }
    }
    
    //Checkea si una posicion esta dentro del tablero
    public bool CheckDentroDeTablero(Vector3 lugarACheckear)
    {
        if(lugarACheckear.x >= 0.0f && lugarACheckear.x <= 7.0f)
        {
            if(lugarACheckear.z >= 0.0f && lugarACheckear.z <= 7.0f)
            {
                return true;
            }
        }
        return false;
    }

    //Checkea si un casillero esta libre
    public bool CheckFree(Vector3 lugarACheckear)
    {
        if (Physics.CheckSphere(lugarACheckear + Vector3.up, 0.5f))
        {
            return false;
        }
        return CheckDentroDeTablero(lugarACheckear);
    }

    //Checkea si en un casillero hay una ficha oponente
    public bool CheckOponent(Vector3 lugarACheckear)
    {
        Collider[] hitColliders = Physics.OverlapSphere(lugarACheckear + Vector3.up, 0.5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag != turno )
            {
                return true;
            }
        }
        return false;
    }
}

