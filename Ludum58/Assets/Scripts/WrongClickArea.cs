using UnityEngine;
using UnityEngine.EventSystems;

public class WrongClickArea : MonoBehaviour, IPointerClickHandler
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider == null || hit.collider.GetComponent<DifferenceSpot>() == null)
        {
            levelManager.MissClick();
        }
    }
}
