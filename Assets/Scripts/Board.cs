using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Board
{
    public string username { get; set; }
    public List<int> gameBoard { get; set; }
    public string opponent { get; set; }
    public bool turn { get; set; }

    public string winner { get; set; }
    public Board(string username, List<int> gameBoard)
    {
        this.username = username;
        this.gameBoard = gameBoard;
    }
}

