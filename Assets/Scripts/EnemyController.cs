using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minDistance = 1f;
    public float maxDistance = 3f;
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;
    public float direction;

    private Vector3 startPos;
    private float moveDistance;
    private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;

        moveDistance = Random.Range(minDistance, maxDistance);
        moveSpeed = Random.Range(minSpeed, maxSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = startPos + Vector3.right * offset * direction;
    }

}
