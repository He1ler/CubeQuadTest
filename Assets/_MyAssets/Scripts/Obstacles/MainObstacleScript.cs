using UnityEngine;
public class MainObstacleScript : MonoBehaviour
{
    protected bool isStarted = false;
    public virtual void InitializeObstacle(float trackSize = 0)
    {
        isStarted = true;
    }
}