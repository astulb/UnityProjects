using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectedPiece : MonoBehaviour
{

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("No hay game controller");
        }
    }

    void OnMouseDown()
    {
        DeleteEnemy();
        gameController.GetSelectedPiece().MoveTo(transform.position);
        gameController.DeletePreviousMoveOptions();
        gameController.PassTurn();
    }

    void DeleteEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + Vector3.up, 0.5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Destroy(hitColliders[i].gameObject);
        }

        if (gameController.PeonSeMovio != null)
        {

            if (gameController.PeonSeMovio.transform.position.x == transform.position.x && hitColliders.Length == 0)
            {
                Destroy(gameController.PeonSeMovio);
            }
        }
    }
}
