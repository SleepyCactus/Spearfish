using GridSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private int m_xSize;
    [SerializeField] private int m_ySize;
    [SerializeField] private int m_walkerCount;
    [SerializeField] int m_maxWalkerSteps;
    private Grid m_grid;
    private List<Walker> m_walkers = new List<Walker>();
    #endregion

    #region Private Functions
    private void OnEnable()
    {
        m_walkers.Clear();
        m_grid = new Grid(m_xSize, m_ySize);
        for (int i = 0; i < m_walkerCount; i++)
        {
            m_walkers.Add(new Walker(m_grid.cells[Mathf.FloorToInt(m_xSize / 2), Mathf.FloorToInt(m_ySize / 2)],m_maxWalkerSteps));
        }
    }
        
    public void Start()
    {
        StartCoroutine(MoveTick());
    }
    IEnumerator MoveTick()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < m_walkers.Count; i++)
        {
            m_walkers[i].Move();
        }
        StartCoroutine(MoveTick());
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
                Gizmos.color = m_grid.cells[iX, iY].cellDebugColour;
                Gizmos.DrawCube(new Vector3(iX,0,iY),Vector3.one/2);
            }
        }
        Gizmos.color = Color.blue;
        for (int i = 0; i < m_walkers.Count; i++)
        {
            Gizmos.DrawSphere(new Vector3(m_walkers[i].position.x, 0, m_walkers[i].position.y), 0.5f);
        }
        

    }

    #endregion

    #region Public Functions
    #endregion
}
