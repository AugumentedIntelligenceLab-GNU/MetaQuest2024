using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public float rayLength = 5.0f; // ���� ����
    private LineRenderer lineRenderer;

    void Start()
    {
        // Line Renderer ������Ʈ �߰� �� �ʱ�ȭ
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // �������� ���� �� ���� ������ ����
        lineRenderer.startWidth = 0.01f; // ���� ���� �κ� �β�
        lineRenderer.endWidth = 0.01f; // ���� �� �κ� �β�
    }

    void Update()
    {
        // ���� ������ (���� ������Ʈ ��ġ)
        Vector3 rayOrigin = transform.position;

        // ���� ���� (���� ������Ʈ�� ���� ����)
        Vector3 rayDirection = transform.forward;

        // ���� ���� ���
        Vector3 rayEnd = rayOrigin + rayDirection * rayLength;

        // Line Renderer ������Ʈ
        lineRenderer.SetPosition(0, rayOrigin);
        lineRenderer.SetPosition(1, rayEnd);

        // Raycast ����
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayLength))
        {
            // Raycast�� �浹�� ���, Line Renderer ���� �����Ͽ� �浹 �������� ǥ��
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}