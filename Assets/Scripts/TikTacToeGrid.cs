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
            CheckWin();
            ChangeTurn();
        }
    }
    public void CheckWin()
    {
       
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
