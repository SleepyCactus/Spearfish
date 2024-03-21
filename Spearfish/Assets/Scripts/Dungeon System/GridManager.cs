using GridSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    [Header("Settings")]
    [SerializeField] private int m_xSize;
    [SerializeField] private int m_ySize;
    [SerializeField] private int m_walkerCount;
    [SerializeField] int m_maxWalkerSteps;
    [SerializeField] float m_stepTime;
    [Header("Options")]
    [SerializeField] private bool m_drawWalkers;
    private Vector2 origin;
    private Grid m_grid;
    private List<Walker> m_walkers = new List<Walker>();

    //temporary
    private Cell m_startCell;
    
    #endregion

    #region Private Functions
        
    IEnumerator MoveTick()
    {
        yield return new WaitForSeconds(m_stepTime);
        int deadWalkers = 0;
        for (int i = 0; i < m_walkers.Count; i++)
        {
            m_walkers[i].Move();
            if (m_walkers[i].dead)
            {
                deadWalkers++;
            }
        }
        if(deadWalkers < m_walkerCount)
        {
            StartCoroutine(MoveTick());
        }
        else
        {
            m_drawWalkers = false;
            AddStartTile();
            AddEndTile();

            TileMapManager.Inst.DisplayGrid(m_grid);
        }
        
    }
    private void AddStartTile()
    {
        List<float> walkerDistances = new List<float>();
        for (int i = 0; i < m_walkers.Count; i++)
        {
            walkerDistances.Add(m_walkers[i].GetDistanceFrom(origin));
        }

        int iLargest = 0;
        float largest = 0;
        for (int i = 0; i < walkerDistances.Count; i++)
        {
            if (walkerDistances[i] > largest)
            {
                largest = walkerDistances[i];
                iLargest = i;
            }
        }

        m_startCell = m_walkers[iLargest].currentCell;
        m_startCell.cellContent = TileMapManager.Inst.GetTile("Start");

    }
    private void AddEndTile()
    {
        List<float> walkerDistances = new List<float>();
        for (int i = 0; i < m_walkers.Count; i++)
        {
            walkerDistances.Add(m_walkers[i].GetDistanceFrom(m_startCell.position));
        }

        int iLargest = 0;
        float largest = 0;
        for (int i = 0; i < walkerDistances.Count; i++)
        {
            if (walkerDistances[i] > largest)
            {
                largest = walkerDistances[i];
                iLargest = i;
            }
        }

        m_walkers[iLargest].currentCell.cellContent = TileMapManager.Inst.GetTile("End");

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if(m_grid == null)
        {
            return;
        }
        for (int iX = 0; iX < m_xSize; iX++)
        {
            for (int iY = 0; iY < m_ySize; iY++)
            {
                Cell currentCell = m_grid.cells[iX, iY];
                Gizmos.color = currentCell.cellContent.Colour * ((1-currentCell.heat)+0.5f);
                Gizmos.DrawCube(new Vector3(iX,0,iY),Vector3.one);
            }
        }
        if(m_drawWalkers)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < m_walkers.Count; i++)
            {
                Gizmos.DrawSphere(new Vector3(m_walkers[i].position.x, 0, m_walkers[i].position.y), 0.5f);
            }
        }
        
        

    }

    #endregion

    #region Public Functions

    public void GenerateLevel()
    {
        m_drawWalkers = true;
        m_walkers.Clear();
        m_grid = new Grid(m_xSize, m_ySize);
        origin = new Vector2(Mathf.FloorToInt(m_xSize / 2), Mathf.FloorToInt(m_ySize / 2));
        for (int i = 0; i < m_walkerCount; i++)
        {
            m_walkers.Add(new Walker(m_grid.cells[(int)origin.x, (int)origin.y], m_maxWalkerSteps));
        }
        StartCoroutine(MoveTick());
    }
    #endregion
}
