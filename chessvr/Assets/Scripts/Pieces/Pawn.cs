using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Vector2Int> SelectAvailableSquares()
    {
        availableMoves.Clear();

        //black pawns can move ony down and white only up
        Vector2Int direction = team == TeamColor.White ? Vector2Int.up : Vector2Int.down;
        
        //its 2 - when has not moved yet, 1 - when its not its first move
        float range = hasMoved ? 1 : 2;
        for(int i = 1; i <= range; i++)
        {
            Vector2Int nextCoordinates = occupiedSquare + direction * i;
            Piece piece = board.GetPieceOnSquare(nextCoordinates);
            if (!board.CheckIfCoordinatesAreOnBoard(nextCoordinates))
                break;
            if (piece == null)
                TryToAddMove(nextCoordinates);
            else if (piece.IsFromSameTeam(this))
                break;
        }

        Vector2Int[] takeDirections = new Vector2Int[] { new Vector2Int(1, direction.y), new Vector2Int(-1, direction.y) };
        for (int i = 1; i < takeDirections.Length; i++)
        {
            Vector2Int nextCoordinates = occupiedSquare + takeDirections[i];
            Piece piece = board.GetPieceOnSquare(nextCoordinates);
            if (!board.CheckIfCoordinatesAreOnBoard(nextCoordinates))
                break;
            if (piece != null && piece.IsFromSameTeam(this))
                TryToAddMove(nextCoordinates);
        }
        return availableMoves;
    }
}
