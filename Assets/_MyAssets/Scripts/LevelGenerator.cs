using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform[] blockPoints;
    [SerializeField] GameObject[] blockGenerators;
    [SerializeField] GameObject startBlock;
    [SerializeField] GameObject endBlock;
    [SerializeField] float trackSize;
    public void GenerateLevel(int levelSize)
    {
        Instantiate(startBlock, blockPoints[0].position, Quaternion.identity)
                .GetComponent<BlockGenerator>().GenerateBlock(trackSize);
        for (int i = 1; i <= levelSize; i++)
        {
            Instantiate(blockGenerators[Random.Range(0, blockGenerators.Length)], blockPoints[i].position, Quaternion.identity)
                .GetComponent<BlockGenerator>().GenerateBlock(trackSize);
        }
        Instantiate(endBlock, new Vector3 ( blockPoints[levelSize].position.x, blockPoints[levelSize].position.y, blockPoints[levelSize].position.z + 12.5f), Quaternion.identity)
        .GetComponent<BlockGenerator>().GenerateBlock(trackSize);
    }
}