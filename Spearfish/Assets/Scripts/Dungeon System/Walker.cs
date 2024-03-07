using GridSystem;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Walker
{
    public Vector2 position;
    public Cell currentCell;
    public bool dead;

    private int m_maxSteps;
    private int m_steps = 0;
    private Vector2[] m_directions = { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0) };
    public Walker(Cell _cell,int _max)
    {
        currentCell = _cell;
        position = _cell.position;
        m_maxSteps = _max;
    }


    public void Move()
    {
        m_steps++;
        if(m_steps >= m_maxSteps)
        {
            dead = true;
            return;
        }
        Vector2 selectedDirection = m_directions[Random.Range(0, m_directions.Length)];
        if (currentCell.GetNeighbour(selectedDirection) != null)
        {
            currentCell = currentCell.GetNeighbour(selectedDirection);
            currentCell.cellDebugColour = Color.black;
            position = currentCell.position;
        }
    }


}
