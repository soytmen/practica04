using UnityEngine;
using Random = UnityEngine.Random;

public class EventsEnemy : MonoBehaviour
{
    #region VARIABLES

    private float speed = 2f;
    private Vector2 startPosition = new Vector2(0, 1.5f);
    [SerializeField] private Vector2 nextPosition;
    
    private float xLim = 8f;
    private float yLim = 3f;

    private float minDistanceFromOrigin = 1.5f;

    private float distanceToDestinyThreshold = 0.1f;

    private bool canMove;

    #endregion

    private void Awake()
    {
        canMove = true;
        nextPosition = startPosition;
    }

    private void Update()
    {
        if (!canMove) return;

        // In scene, position is 3D, but we operate internally with 2D positions
        if (Vector3.Distance(transform.position, nextPosition) < distanceToDestinyThreshold)
        {
            // If we arrive to the nextPosition, we calculate a new nextPosition away from the origin
            do
            {
                nextPosition = RandomPosition();
            } while (!IsFarFromOrigin(nextPosition));
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, 
            speed * Time.deltaTime);
    }

    private Vector2 RandomPosition()
    {
        float x = Random.Range(-xLim, xLim);
        float y = Random.Range(-yLim, yLim);

        return new Vector2(x, y);
    }

    private bool IsFarFromOrigin(Vector2 pos)
    {
        return Vector2.Distance(pos, Vector2.zero) > minDistanceFromOrigin;
    }

    private void StopMovement()
    {
        canMove = false;
    }
    
    private void RestartMovement()
    {
        canMove = true;
    }
}
