using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    Vector2Int[] directions = new Vector2Int[]
    {
        new Vector2Int(-1, 1),
        new Vector2Int(0, 1),
        new Vector2Int(1, 1),
        new Vector2Int(-1, 0),
        new Vector2Int(1, 0),
        new Vector2Int(-1, -1),
        new Vector2Int(0, -1),
        new Vector2Int(1, -1),
    };
    public override List<Vector2Int> SelectAvailableSquares()
    {
        availableMoves.Clear();
        float range = 1;
        foreach (var direction in directions)
        {
            for (int i = 1; i <= range; i++)
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
}
