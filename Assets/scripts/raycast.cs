using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public float rayLength = 5.0f; // 레이 길이
    private LineRenderer lineRenderer;

    void Start()
    {
        // Line Renderer 컴포넌트 추가 및 초기화
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // 시작점과 끝점 두 개의 점으로 구성
        lineRenderer.startWidth = 0.01f; // 레이 시작 부분 두께
        lineRenderer.endWidth = 0.01f; // 레이 끝 부분 두께
    }

    void Update()
    {
        // 레이 시작점 (현재 오브젝트 위치)
        Vector3 rayOrigin = transform.position;

        // 레이 방향 (현재 오브젝트의 앞쪽 방향)
        Vector3 rayDirection = transform.forward;

        // 레이 끝점 계산
        Vector3 rayEnd = rayOrigin + rayDirection * rayLength;

        // Line Renderer 업데이트
        lineRenderer.SetPosition(0, rayOrigin);
        lineRenderer.SetPosition(1, rayEnd);

        // Raycast 실행
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayLength))
        {
            // Raycast가 충돌한 경우, Line Renderer 길이 조절하여 충돌 지점까지 표시
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}