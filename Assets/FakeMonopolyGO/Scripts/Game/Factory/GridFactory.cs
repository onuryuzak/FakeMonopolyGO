using MyGame.Models;
using UnityEngine;

public class GridSlotFactory
{
    private readonly GameObject _gridSlotPrefab;

    public GridSlotFactory(GameObject gridSlotPrefab)
    {
        _gridSlotPrefab = gridSlotPrefab;
    }

    public GridSlot CreateGridSlot(Vector3 position)
    {
        GameObject slotObject = Object.Instantiate(_gridSlotPrefab, position, Quaternion.identity);
        return slotObject.GetComponent<GridSlot>();
    }
}