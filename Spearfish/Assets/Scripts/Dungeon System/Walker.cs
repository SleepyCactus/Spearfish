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

    public float GetDistanceFrom(Vector2 _from)
    {
        float dist = 0;
        dist = Vector2.Distance(_from, position);
        return dist;
    }
    public void Move()
    {
        m_steps++;
        if (m_steps >= m_maxSteps)
        {
            dead = true;
            return;
        }

        if (currentCell != null)
        {
            Cell c = currentCell.GetRandomWeightedNeighbour();
            if (c != null)
            {
                currentCell = c;
                currentCell.cellDebugColour = Color.black;
                position = currentCell.position;

            }


            /*
            Vector2 selectedDirection = m_directions[Random.Range(0, m_directions.Length)];
            if (currentCell.GetNeighbour(selectedDirection) != null)
            {
                currentCell = currentCell.GetNeighbour(selectedDirection);
                currentCell.cellDebugColour = Color.black;
                position = currentCell.position;
            }
            */
        }
    }

}
