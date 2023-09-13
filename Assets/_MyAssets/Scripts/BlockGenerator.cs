using UnityEngine;
public class BlockGenerator : MonoBehaviour
{
    [SerializeField] Transform[] obstaclePoints;
    [SerializeField] GameObject[] mainObstacleScripts;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Gradient gradient;
    Color color = Color.white;
    public void GenerateBlock(float trackSize)
    {
        color = gradient.colorKeys[Random.Range(0, gradient.colorKeys.Length)].color;
        meshRenderer.material.color = color;
        for (int i = 0; i < obstaclePoints.Length; i++)
        {
            Instantiate(mainObstacleScripts[Random.Range(0, mainObstacleScripts.Length)], obstaclePoints[i].position, Quaternion.identity)
                .GetComponent<MainObstacleScript>().InitializeObstacle(trackSize);
        }
    }
}