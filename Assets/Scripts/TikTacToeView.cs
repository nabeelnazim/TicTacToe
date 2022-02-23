using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikTacToeView : MonoBehaviour
{
    public GameObject cellsPrefeb;
    public int row;
    public int col;
    public float horizontalspacing;
    public float verticalspacing;
    public float counter;
    TikTacToeGrid tiktactoeGrid;

    void Start()
    {
        InitializeGrid();
    }

    void Update()
    {
        
    }

    public void InitializeGrid()
    {
        tiktactoeGrid = new TikTacToeGrid(row, col);
        tiktactoeGrid.cellCreated += OnCellCreated;
        tiktactoeGrid.initializeCells();

    }
    public void OnCellCreated(Cell cell)
    {
        cellPosition();
        CellView setcell;
        setcell= Instantiate(cellsPrefeb, new Vector3(horizontalspacing,0,verticalspacing), cellsPrefeb.transform.rotation).GetComponent<CellView>();
        setcell.SetCell(cell);
        counter++; 
    }
   public void cellPosition()
    {
        if (counter == row) 
        {
            horizontalspacing = 2;
            counter = 0;
            verticalspacing += 2;
        }
        else
        {
            horizontalspacing += 2;
        }
    }
}
