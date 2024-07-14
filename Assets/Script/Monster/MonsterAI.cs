using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour
{
    public float moveSpeed = 3f; // 몬스터 이동 속도
    public float rotationSpeed = 2f; // 몬스터 회전 속도
    public float changeDirectionInterval = 2f; // 방향을 변경하는 시간 간격
    public float movementRange = 10f; // 몬스터가 이동할 수 있는 범위

    private Vector3 targetPosition;

    void Start()
    {
        StartCoroutine(MoveRandomly());
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            SetNewRandomPosition();
            float timeToChangeDirection = changeDirectionInterval;

            while (timeToChangeDirection > 0)
            {
                timeToChangeDirection -= Time.deltaTime;
                MoveTowardsTarget();
                yield return null;
            }
        }
    }

    void MoveTowardsTarget()
    {
        // 이동
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 회전
        if (direction != Vector3.zero) // 방향 벡터가 0이 아닌 경우에만 회전
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0); // y축 회전만 유지
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }

        // 타겟 위치에 도달했는지 체크
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewRandomPosition();
        }
    }

    void SetNewRandomPosition()
    {
        float randomX = Random.Range(-movementRange, movementRange);
        float randomZ = Random.Range(-movementRange, movementRange);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}
