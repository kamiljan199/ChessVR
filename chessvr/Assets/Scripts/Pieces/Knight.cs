using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    Vector2Int[] offsets = new Vector2Int[]
    {
        new Vector2Int(2, 1),
        new Vector2Int(2, -1),
        new Vector2Int(1, 2),
        new Vector2Int(1, -2),
        new Vector2Int(-2, 1),
        new Vector2Int(-2, -1),
        new Vector2Int(-2, 1),
        new Vector2Int(-1, -2),
    };
    public override List<Vector2Int> SelectAvailableSquares()
    {
        availableMoves.Clear();

        for (int i = 1; i < offsets.Length; i++)
        {
            Vector2Int nextCoordinates = occupiedSquare + offsets[i];
            Piece piece = board.GetPieceOnSquare(nextCoordinates);
            if (!board.CheckIfCoordinatesAreOnBoard(nextCoordinates))
                continue;
            if (piece == null || (!piece.IsFromSameTeam(this))
                TryToAddMove(nextCoordinates);
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
