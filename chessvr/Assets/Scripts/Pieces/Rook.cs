using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override List<Vector2Int> SelectAvailableSquares()
    {
        availableMoves.Clear();
        availableMoves.Add(occupiedSquare + new Vector2Int(0, 1));
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