public class StaticObstacle : MainObstacleScript
{
    public override void InitializeObstacle(float trackSize)
    {
        int randomIndex = UnityEngine.Random.Range(0, 3);
        float[] numbers = { transform.position.x, transform.position.x - .75f, transform.position.x + .75f };
        transform.position = new UnityEngine.Vector3(numbers[randomIndex], transform.position.y, transform.position.z);
        base.InitializeObstacle();
    }
}