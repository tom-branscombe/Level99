using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [Tooltip("This effects Speed of the Enemy")]
    [SerializeField] private float speed;
   
    [Tooltip("This effects how far the enemy will go")]
    [SerializeField] private float distance;

    //Private
    private float dir;
    float PlayerPos;
    private float pointA;
    private float pointB;

    [SerializeField] LayerMask targetLayer;
    [SerializeField] float detectionRadius;



    //Component
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        var hit = Physics2D.OverlapCircle(transform.position, detectionRadius, targetLayer);
        if (hit == null)
        {
            OnMove();
            return;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, hit.transform.position, speed * Time.deltaTime);
    }
    private void OnMove()
    {
        
        rb.velocity = new Vector2(dir, 0);
        PlayerPos = transform.position.x;
        if(PlayerPos > pointA)
        {
            dir = -speed;
        }
        if(PlayerPos < pointB)
        {
            dir = speed;
        }
    }
    private void Init()
    {

        dir = speed;
        rb = GetComponent<Rigidbody2D>();
        PlayerPos = transform.position.x;

        pointA = PlayerPos + distance;
        pointB = PlayerPos - distance;
    }
    
}
//[SerializeField] Transform targetGameObject;
//[SerializeField] float speed;
//[SerializeField] LayerMask targetLayer;
//[SerializeField] float detectionRadius;

//private void Update()
//{
    //if (targetGameObject == null) return;
    //var hit = Physics2D.OverlapCircle(transform.position, detectionRadius, targetLayer);
    //if (hit == null) return;
    //transform.position = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed * Time.deltaTime);
//}