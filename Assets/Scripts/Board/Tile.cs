using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color normalColor, otherColor;
    [SerializeField] private SpriteRenderer renderedTile;
    public void Init(bool isOther)
    {
        if (!isOther)
        {
            renderedTile.color = normalColor;
        }
        else
        {
            renderedTile.color = otherColor;
        }
    }
}
