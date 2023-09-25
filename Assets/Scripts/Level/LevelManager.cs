using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private List<GameObject> levels;

    [Header("Pieces")]
    [SerializeField] private List<LevelPieceBase> levelPiecesStart;
    [SerializeField] private List<LevelPieceBase> levelPieces;
    [SerializeField] private List<LevelPieceBase> levelPiecesEnd;
    [SerializeField] private int piecesNumber = 5;
    [SerializeField] private int index;
    private List<LevelPieceBase> spawnedPieces;

    [SerializeField] private GameObject currentLevel;

    [SerializeField] private List<Material> materials;

    private void Awake()
    {
        CreateLevelPieces();
        RandomMaterialsColor();
    }

    private void SpawnLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
            index++;

            if (index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        currentLevel = Instantiate(levels[index], container);
        currentLevel.transform.position = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        index = 0;
    }

    private void CreateLevelPieces()
    {
        spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(i);
        }
    }

    private void CreateLevelPiece(int piecesNumberParam)
    {
        if (piecesNumberParam == 0)
        {
            var piece = levelPiecesStart[Random.Range(0, levelPiecesStart.Count)];
            var spawnedPiece = Instantiate(piece, container);
            AddPiece(spawnedPiece);
        }
        else if (piecesNumberParam > 0 && piecesNumberParam < piecesNumber-1)
        {
            var piece = levelPieces[Random.Range(0, levelPieces.Count)];
            var spawnedPiece = Instantiate(piece, container);
            AddPiece(spawnedPiece);
        }
        else
        {
            var piece = levelPiecesEnd[Random.Range(0, levelPiecesEnd.Count)];
            var spawnedPiece = Instantiate(piece, container);
            AddPiece(spawnedPiece);
        }

    }

    private void AddPiece(LevelPieceBase spawnedPieceParam)
    {
        if (spawnedPieces.Count > 0)
        {
            var lastPiece = spawnedPieces[spawnedPieces.Count - 1];

            spawnedPieceParam.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPieceParam.transform.localPosition = Vector3.zero;
        }
        spawnedPieces.Add(spawnedPieceParam);


    }

    private void RandomMaterialsColor()
    {
        foreach(Material levelMaterial in materials)
        {
            levelMaterial.SetColor("_BaseColor", new Color(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f)));
        }
    }
}
