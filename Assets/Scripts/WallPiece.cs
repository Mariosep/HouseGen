using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPiece : MonoBehaviour
{
    [SerializeField] private Transform leftCorner;
    [SerializeField] private Transform rightCorner;

    public Vector3 LeftCornerPosition => leftCorner.position;
    public Vector3 RightCornerPosition => rightCorner.position;
}
