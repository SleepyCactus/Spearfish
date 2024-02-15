using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private int m_xSize;
    [SerializeField] private int m_ySize;
    private Grid m_grid;
    #endregion

    #region Private Functions
    private void Start()
    {
        m_grid = new Grid(m_xSize,m_ySize);
        m_grid.DebugGrid();
        
    }
    #endregion

    #region Public Functions
    #endregion
}
