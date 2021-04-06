using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PieceCreator))]
public class ChessGameController : MonoBehaviour
{
    [SerializeField] private BoardLayout startingBoardLayout;
    [SerializeField] private Board board;

    private PieceCreator pieceCreator;

    private void Awake()
    {
        pieceCreator = GetComponent<PieceCreator>();
    }

    void Start()
    {
        StartNewGame();
    }

    // Update is called once per frame
    private void StartNewGame()
    {
        CreatePiecesFromLayout(startingBoardLayout);
    }

    private void CreatePiecesFromLayout(BoardLayout layout)
    {
        for (int i = 0; i < layout.GetPiecesCount(); i++)
        {
            Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
            TeamColor teamColor = layout.GetSquareTeamColorAtIndex(i);
            string typeName = layout.GetSquarePieceNameAtIndex(i);
            Type type = Type.GetType(typeName);

            CreatePieceAndInit(squareCoords, teamColor, type);
        }
    }

    private void CreatePieceAndInit(Vector2Int squareCoords, TeamColor teamColor, Type type)
    {
        Piece newPiece = pieceCreator.CreatePiece(type).GetComponent<Piece>();
        newPiece.SetData(squareCoords, teamColor, board);

        Material teamMaterial = pieceCreator.GetTeamMaterial(teamColor);
        newPiece.SetMaterial(teamMaterial);
    }
}
