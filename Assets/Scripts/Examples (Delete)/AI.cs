using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float detectionRadius;

    private void Update()
    {
        var hit = Physics2D.OverlapCircle(transform.position, detectionRadius, targetLayer);
        if (hit == null) return;
        transform.position = Vector2.MoveTowards(transform.position, hit.transform.position, speed * Time.deltaTime);
    }
}