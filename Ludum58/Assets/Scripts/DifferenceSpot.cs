using UnityEngine;

public class DifferenceSpot : MonoBehaviour
{
    private bool isFound = false;
    private LevelManager levelManager;
    public GameObject markPrefab;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnMouseDown()
    {
        if (isFound) return;
        Instantiate(markPrefab, transform.position, Quaternion.identity, transform.parent);

        isFound = true;
        levelManager.FoundDifference();
    }
}