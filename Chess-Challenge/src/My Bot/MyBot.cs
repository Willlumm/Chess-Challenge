using System;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    public static float Eval(Board board)
    {
        return 0;
    } 

    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();
        Move best_move = moves[0];
        float best_eval = -100;
        foreach(Move move in board.GetLegalMoves())
        {
            board.MakeMove(move);
            float eval = Eval(board);
            if(eval > best_eval)
            {
                best_move = move;
                best_eval = Eval(board);
            }
            board.UndoMove(move);
        }
        return best_move;
    }
}