using UnityEngine;
public class MovableObstacle : MainObstacleScript
{
    [SerializeField] float moveSpeed = 5f; // Speed of the obstacle movement.
    private float minX = -1f; // Minimum X position.
    private float maxX = 1f; // Maximum X position.
    private bool moveRight = true;
    float speed;
    public override void InitializeObstacle(float trackSize)
    {
        minX = trackSize / -2f;
        maxX = trackSize / 2f;
        speed = Random.Range(moveSpeed - .5f, moveSpeed + .5f);
        base.InitializeObstacle();
    }
    private void Update()
    {
        // Calculate the horizontal movement.
        float movement = speed * Time.deltaTime * (moveRight ? 1f : -1f);
        // Update the obstacle's position.
        transform.Translate(Vector3.right * movement);
        // Check if the obstacle reaches the boundaries.
        if (transform.position.x >= maxX)
        {
            moveRight = false;
            return;
        }
        if (transform.position.x <= minX)
        {
            moveRight = true;
            return;
        }
    }
}