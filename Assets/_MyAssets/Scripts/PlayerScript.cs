using PathCreation.Examples;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PathFollower[] pathFollowers;
    [SerializeField] float speed = 3f;
    [SerializeField] float minDistanceForSwipe = 450f;
    [SerializeField] int maxPath = 3;
    [SerializeField] int minPath = 1;
    int pathNumber = 2;
    bool isStarted = false;
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        if(!isStarted)
        {
            return;
        }
        GetTouch();
        transform.position = Vector3.Lerp(transform.position, pathFollowers[pathNumber - 1].transform.position, .5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            CollideWithObstacle();
            return;
        }
        if (other.CompareTag("Finish"))
        {
            Finish();
            return;
        }
        Jump();
    }
    void InitializePlayer()
    {
        foreach(PathFollower pathFollower in pathFollowers)
        {
            pathFollower.speed = speed;
        }
        animator.SetFloat("Speed", speed);
        isStarted = true;
    }
    void GetTouch()
    {
        if(Input.touchCount <= 0)
        {
            return;
        }
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            fingerDownPosition = touch.position;
            return;
        }
        if (touch.phase == TouchPhase.Moved)
        {
            fingerUpPosition = touch.position;
            DetectSwipe();
            return;
        }
        if (touch.phase == TouchPhase.Ended)
        {
            fingerUpPosition = touch.position;
            DetectSwipe();
            return;
        }
    }
    void CheckNumber(int checkNumber)
    {
        pathNumber += checkNumber;
        if(pathNumber > maxPath)
        {
            pathNumber--;
            return;
        }
        if(pathNumber < minPath)
        {
            pathNumber++;
            return;
        }
    }
    private void DetectSwipe()
    {
        if (Vector3.Distance(fingerDownPosition, fingerUpPosition) < minDistanceForSwipe)
        {
            return;
        }
        var direction = fingerUpPosition - fingerDownPosition;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal swipe
            if (direction.x > 0)
            {
                CheckNumber(1);
            }
            else
            {
                CheckNumber(-1);
            }
        }
        fingerDownPosition = fingerUpPosition;
    }
    void CollideWithObstacle()
    {
        animator.SetTrigger("Lose");
        isStarted = false;
        UIManager.instance.LoseGame();
    }
    void Finish()
    {
        animator.SetTrigger("Win");
        isStarted = false;
        UIManager.instance.WinGame();
    }
    void Jump()
    {
        animator.SetTrigger("Jump");
    }
}