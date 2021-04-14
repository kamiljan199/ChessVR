using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    private Vector2Int[] directions = { Vector2Int.left, Vector2Int.up, Vector2Int.right, Vector2Int.down };
    public override List<Vector2Int> SelectAvailableSquares()
    {
        availableMoves.Clear();
        float range = Board.BOARD_SIZE;
        foreach(var direction in directions)
        {
            for(int i = 1; i < range; i++)
            {
                Vector2Int nextCoordinates = occupiedSquare + direction * i;
                Piece piece = board.GetPieceOnSquare(nextCoordinates);
                if (!board.CheckIfCoordinatesAreOnBoard(nextCoordinates))
                    break;
                if (piece == null)
                    TryToAddMove(nextCoordinates);
                else if (!piece.IsFromSameTeam(this))
                {
                    TryToAddMove(nextCoordinates);
                    break;
                }
                else if (piece.IsFromSameTeam(this))
                    break;
            }
        }
        return availableMoves;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}