using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikTacToeGrid : Matrix
{
    int rows;
    int cols;
    
    List<List<Cell>> cellsGrid;
    Cell.Status currentTurn = Cell.Status.cross;

    public delegate void OnCellCreated(Cell cell);
    public event OnCellCreated cellCreated;

    public TikTacToeGrid(int numofrows, int numofcol) : base(numofrows, numofcol)
    {
        rows = numofrows;
        cols = numofcol;
        cellsGrid = new List<List<Cell>>();
    }

    public void initializeCells()
    {
        for (int row = 0; row < rows; row++)
        {
            cellsGrid.Add(new List<Cell>());
            for (int col = 0; col < cols; col++)
            {
                Cell temp = new Cell(row,col);
                cellsGrid[row].Add(temp);
                temp.rowandcol+=GridStatus;
                cellCreated?.Invoke(cellsGrid[row][col]);
                setElement(row, col, (int)Cell.Status.none);
            }
        }
    }
    public void GridStatus(int row,int col)
    {
        if (cellsGrid[row][col].GetStatus() == Cell.Status.none)
        {
            cellsGrid[row][col].SetStatus(currentTurn);
            setElement(row, col, (int)currentTurn);
            ChangeTurn();
        }
        if (CheckWin())
        {
            Debug.Log("Game Finished");
                        
        }
    }
    public void FreezGrid()
    {
        for (int i = 0; i < list1.Count; i++)
        {
            for (int j = 0; j < list1[0].Count; j++)
            {
                if (cellsGrid[i][j].GetStatus() == Cell.Status.none)
                {
                    cellsGrid[i][j].SetStatus(Cell.Status.loose);
                }
            }
        }
    }
    public bool CheckWin()
    {
        if (checkRowWin()) return true;
        if (checkColWin()) return true;
        if (checkDiagnolWin()) return true;
        if (checkinverseDiagnolWin()) return true;
        return false;
    }
    public bool checkRowWin()
    {
        for(int i = 0; i < rows; i++)
        {
            if(isRowSame(i) && getElemet(i, 0) != 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    cellsGrid[i][j].SetStatus(Cell.Status.win);
                }
                //RowSet(i, (int)Cell.Status.win);
                return true;
            }
        }
        return false;
    }
    public bool checkColWin()
    {
        for (int i = 0; i < cols; i++)
        {
            if (isColSame(i) && getElemet(0, i) != 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    cellsGrid[j][i].SetStatus(Cell.Status.win);
                }
                return true;
            }
        }
        return false;
    }
    public bool checkinverseDiagnolWin()
    {
       if(IsinverseDiagonalSame() && getElemet(0, 0) != 0)
        { 
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool checkDiagnolWin()
    {
        if (IsDiagonalSame() && getElemet(0, 0) != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeTurn()
    {
        if (currentTurn == Cell.Status.cross)
        {
            currentTurn = Cell.Status.cicle;
        }
        else
        {
            currentTurn = Cell.Status.cross;
        }
    }
}
