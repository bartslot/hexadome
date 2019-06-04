using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateHexagon : MonoBehaviour
{
    public float _rowSize = 32;
    public float _columnSize = 32;
    public GameObject _HexagonPrefab;
    GameObject[] _Hexagon = new GameObject[32];
    public int _hexWidth;
    public int _hexHeight;

    void Awake()
    {
        for (int i = 1; i < _rowSize + 1; i++)
        {

            GameObject _instanceHexagonX = (GameObject)Instantiate(_HexagonPrefab);
            _instanceHexagonX.transform.position = this.transform.position;
            _instanceHexagonX.transform.parent = this.transform;
            _instanceHexagonX.name = "Hexagon" + i;
            _instanceHexagonX.transform.position = new Vector3(i * _hexWidth, 10, i * _hexHeight);
            this.transform.eulerAngles = new Vector3(0, -60f * i, 0);
            _instanceHexagonX.transform.position = Vector3.forward * _hexHeight;
            _Hexagon[i] = _instanceHexagonX;

            _HexagonPrefab.transform.position = new Vector3(i * _hexWidth, 0, i * _hexWidth);
        }
    }
}
