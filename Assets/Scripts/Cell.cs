
using System;

public class Cell
{
    int row;
    int col;
    Status status;
    public delegate void Statusupdated(Status status);
    public Statusupdated statusupdated;

    public delegate void RowandCol(int row, int col);
    public RowandCol rowandcol;
    public Cell()
    {
        
    }

    public Cell(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

   /* public Cell()
    {
        status = Status.win;
        row = 0;
        col = 0;
    }*/
 
    public enum Status { none,cross,cicle,win,loose}
    public void SetStatus(Status state)
    {
        this.status = state;
        
        statusupdated?.Invoke(status);
    }
    public Status GetStatus()
    {
        return status;
    }
    public void SetRow(int row)
    {
        this.row=row;
    }
    public int GetRow()
    {
        return row;
    }
    public void SetCol(int col)
    {
        this.col = col;
    }
    public int GetCol()
    {
        return col;
    }

    internal void cellInteraction()
    {
        rowandcol?.Invoke(row, col);
        //SetStatus(Status.win);
    }
}
