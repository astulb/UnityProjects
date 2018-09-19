using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceController : MonoBehaviour {

    public GameObject validZone;
    protected GameController gameController;

	// Use this for initialization
	void Start () {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("No hay game controller");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (gameController.CheckTurn(tag)) 
        {
            gameController.SetSelectedPiece(gameObject.GetComponent<PieceController>());
            gameController.DeletePreviousMoveOptions();
            ShowPosibleMoves();
        }
    }

    public virtual void MoveTo(Vector3 newPos)
    {
        gameObject.transform.position = newPos;
    }

    public abstract void ShowPosibleMoves();


}
