using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    public GameObject[] cellstate;
    Cell cell;
    TikTacToeGrid tiktactoeGrid;
    void Start()
    {
        cell.statusupdated += SetStatus;

    }

    void Update()
    {

    }
    public void SetStatus(Cell.Status status)
    {
        for (int i = 0; i < cellstate.Length; i++)
        {
            if (i == (int)status)
            {
                cellstate[i].SetActive(true);
            }
            else
            {
                cellstate[i].SetActive(false);
            }
        }

    }
    public void SetCell(Cell cell)
    {
        this.cell = cell;
    }

    private void OnMouseDown()
    {
        cell.cellInteraction();

    }
    private void OnDestroy()
    {
        cell.statusupdated -= SetStatus;
    }
}