using System.Collections;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Vector2 lastInput;
    private bool isMoving;
    private Vector3 targetPosition;
    private float moveDuration = 0.15f; // �ƶ�����ʱ��
    private float moveTimer = 0f;

    private void Start()
    {
        //transform.position = new Vector3(0, 0.1f, 0);
        //targetPosition = transform.position; // ��ʼ��Ŀ��λ��
    }

    private void Update()
    {
        Vector2 currentInput = GetInput();

        if (currentInput != lastInput && currentInput.magnitude > 0 && !isMoving)
        {
            isMoving = true;
            moveTimer = 0f;

            // ����Ŀ��λ�õ��������ƶ�
            Vector3 movement = CalculateMovement(currentInput);
            targetPosition = transform.position + movement;
        }
        else if (currentInput.magnitude == 0)
        {
            isMoving = false;
        }

        // ƽ���ƶ��߼�
        if (isMoving)
        {
            moveTimer += Time.deltaTime;
            float progress = Mathf.Clamp01(moveTimer / moveDuration);

  
            float easeProgress = EaseInOutQuad(progress);
            transform.position = Vector3.Lerp(transform.position, targetPosition, easeProgress);

            // �ƶ�����ж�
            if (progress >= 1f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }

        lastInput = currentInput;
    }

    private Vector3 CalculateMovement(Vector2 input)
    {
        Vector3 movement = Vector3.zero;
        if (input.x != 0 && input.y != 0)
        {
            movement.x = input.x * 0.16f;
            movement.y = input.y * 0.18f;
        }
        else if (input.x != 0)
        {
            movement.x = input.x * 0.32f;
        }
        else if (input.y != 0)
        {
            movement.y = input.y * 0.32f;
        }
        return movement;
    }

    private Vector2 GetInput()
    {
        Vector2 input = Vector2.zero;

        // �����ƶ����
        if (Input.GetKey(KeyCode.A)) input.x = -1;
        else if (Input.GetKey(KeyCode.S)) input.x = 1;

        // б���ƶ����
        if (Input.GetKey(KeyCode.W)) { input.x = 1; input.y = 1; }
        if (Input.GetKey(KeyCode.X)) { input.x = 1; input.y = -1; }
        if (Input.GetKey(KeyCode.Q)) { input.x = -1; input.y = 1; }
        if (Input.GetKey(KeyCode.Z)) { input.x = -1; input.y = -1; }

        return input;
    }

    // �������� - ���η����뻺��
    private float EaseInOutQuad(float t)
    {
        return t < 0.5 ? 2f * t * t : -1f + (4f - 2f * t) * t;
    }
}