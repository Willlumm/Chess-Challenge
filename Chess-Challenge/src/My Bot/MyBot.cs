using System;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    public static float Eval(Board board)
    {
        int myMoveCount = board.GetLegalMoves().Length;
        board.TrySkipTurn();
        int enemyMoveCount = board.GetLegalMoves().Length;
        // Console.WriteLine(myMoveCount.ToString()+" - "+enemyMoveCount.ToString());
        return myMoveCount - enemyMoveCount;
    } 

    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();
        Move bestMove = moves[0];
        float bestEval = -100;
        foreach(Move move in board.GetLegalMoves())
        {
            board.MakeMove(move);
            int enemyMoveCount = board.GetLegalMoves().Length;
            board.ForceSkipTurn();
            int myMoveCount = board.GetLegalMoves().Length;
            board.UndoSkipTurn();
            int eval = myMoveCount - enemyMoveCount;
            if(eval > bestEval)
            {
                bestMove = move;
                bestEval = myMoveCount - enemyMoveCount;
            }
            board.UndoMove(move);
            Console.WriteLine(move.MovePieceType.ToString() + " " + move.TargetSquare.Name + " " + myMoveCount + " - " + enemyMoveCount + "\t= " + eval);
        }
        Console.WriteLine();
        return bestMove;
    }
}