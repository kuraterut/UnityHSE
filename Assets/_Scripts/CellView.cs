using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _Scripts
{
    public class CellView : MonoBehaviour
{
    private Cell _cell;
    private TextMeshProUGUI _cellText;
    private Image _cellImage; 
    
    public Color startColor = Color.white;
    public Color endColor = Color.red;

    void Awake()
    {
        _cellText = GetComponentInChildren<TextMeshProUGUI>();
        _cellImage = GetComponent<Image>(); 
    }

    public void Initialize(Cell cell)
    {
        this._cell = cell;
        UpdateValue();
        UpdateColor(); 

        cell.OnValueChanged += UpdateValue;
        cell.OnPositionChanged += UpdatePosition;
    }

    private (double x, double y) GetRealPosition((int, int) pos)
    {
        if (pos.Item1 == 0 && pos.Item2 == 0) { return (-68.0625, 72.0); }
        if (pos.Item1 == 0 && pos.Item2 == 1) { return (-22.6875, 72.0); }
        if (pos.Item1 == 0 && pos.Item2 == 2) { return (22.6875, 72.0); }
        if (pos.Item1 == 0 && pos.Item2 == 3) { return (68.0625, 72.0); }
        if (pos.Item1 == 1 && pos.Item2 == 0) { return (-68.0625, 24.0); }
        if (pos.Item1 == 1 && pos.Item2 == 1) { return (-22.6875, 24.0); }
        if (pos.Item1 == 1 && pos.Item2 == 2) { return (22.6875, 24.0); }
        if (pos.Item1 == 1 && pos.Item2 == 3) { return (68.0625, 24.0); }
        if (pos.Item1 == 2 && pos.Item2 == 0) { return (-68.0625, -24.0); }
        if (pos.Item1 == 2 && pos.Item2 == 1) { return (-22.6875, -24.0); }
        if (pos.Item1 == 2 && pos.Item2 == 2) { return (22.6875, -24.0); }
        if (pos.Item1 == 2 && pos.Item2 == 3) { return (68.0625, -24.0); }
        if (pos.Item1 == 3 && pos.Item2 == 0) { return (-68.0625, -72.0); }
        if (pos.Item1 == 3 && pos.Item2 == 1) { return (-22.6875, -72.0); }
        if (pos.Item1 == 3 && pos.Item2 == 2) { return (22.6875, -72.0); }
        if (pos.Item1 == 3 && pos.Item2 == 3) { return (68.0625, -72.0); }

        return (-1, -1);
    }

    public void UpdateValue()
    {
        _cellText.text = (_cell.Value * 2).ToString();
        UpdateColor(); 
    }

    public void UpdateValue(int value)
    {
        _cell.Value = value;
        _cellText.text = _cell.Value.ToString();
        UpdateColor(); 
    }

    private void UpdatePosition()
    {
        var realPos = GetRealPosition(_cell.Position);
        transform.localPosition = new Vector3((float)realPos.x, (float)realPos.y, 0);
    }

    public Cell GetCell() { return _cell; }
    
    private void UpdateColor()
    {
        if (_cell == null || _cellImage == null) return;
        
        float lerpValue = Mathf.Clamp01((float)_cell.Value / 2048f);
        
        _cellImage.color = Color.Lerp(startColor, endColor, lerpValue);
    }
    
}
}