using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Wall : MonoBehaviour
{
    public GameObject wallPiecePrefab;

    [Range(1, 10)]
    public int wallSize = 1;
    public List<WallPiece> wallPieceList = new List<WallPiece>();
    
    void Start()
    {
        InitializeWallPieceList();
    }

    [ContextMenu("InitializeWallPieceList")]
    void InitializeWallPieceList()
    {
        wallSize = transform.childCount;

        wallPieceList.Clear();
        wallPieceList.AddRange(GetComponentsInChildren<WallPiece>());
    }

    private void OnValidate()
    {
        int dif = wallSize - wallPieceList.Count;

        if (dif > 0)
        {
            while (dif != 0)
            {
                AddWallPiece();
                dif--;
            }
            
        }
        else if (dif < 0)
        {
            while (dif != 0)
            {
                RemoveWallPiece();
                dif++;
            }
        }
    }

    public void AddWallPiece()
    {
        Vector3 targetPosition;
        
        if (wallPieceList.Count > 0)
        {
            WallPiece lastWallPiece = GetLastWallPiece();
            targetPosition = lastWallPiece.RightCornerPosition + (Vector3.right * 0.5f);    
        }
        else
        {
            targetPosition = Vector3.zero;
        }
        
        WallPiece newWallPiece = Instantiate(wallPiecePrefab, targetPosition, Quaternion.identity, transform).GetComponent<WallPiece>();
        
        wallPieceList.Add(newWallPiece);
        wallSize = wallPieceList.Count; 
        
        Debug.Log("Added wall piece");
    }
    
    public void RemoveWallPiece()
    {
        if(wallPieceList.Count == 0)
            return;
            
        WallPiece lastWallPiece = GetLastWallPiece();

        wallPieceList.Remove(lastWallPiece);
        wallSize = wallPieceList.Count;
        
        UnityEditor.EditorApplication.delayCall+=()=>
        {
            UnityEditor.Undo.DestroyObjectImmediate(lastWallPiece.gameObject);
        };
        Debug.Log("Removed wall piece");
    }

    private WallPiece GetLastWallPiece()
    {
        return wallPieceList[wallPieceList.Count - 1];
    }
    
    IEnumerator DestroyGO(GameObject go) {
        yield return new WaitForSeconds(0);
        DestroyImmediate(go);
    }
}
