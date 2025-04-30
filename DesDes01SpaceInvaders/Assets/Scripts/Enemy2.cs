using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    [Header("Fiender")]
    public Enemy2 baseEnemy; // Single enemy object in scene
    public AnimationCurve speed = new AnimationCurve();
    private Vector3 direction = Vector3.right;
    private Vector3 initialPosition;

    [Header("Grid")]
    public int rows = 5;
    public int columns = 11;

    private void Awake()
    {
        initialPosition = transform.position;
        CreateInvaderGrid();
    }

    private void CreateInvaderGrid()
    {
        float width = 2f * (columns - 1);
        float height = 2f * (rows - 1);
        Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(centerOffset.x + 2f * j, centerOffset.y + 2f * i, 0f);

                // Instantiate clone
                Enemy2 enemy = Instantiate(baseEnemy, transform);
                enemy.transform.localPosition = position;
                enemy.gameObject.SetActive(true);
            }
        }

        // Optional: hide the base object visually but don't disable if needed for prefab-like behavior
        baseEnemy.gameObject.SetActive(false);
    }

    private void Update()
    {
        int totalCount = rows * columns;
        int amountAlive = GetAliveCount();
        int amountKilled = totalCount - amountAlive;
        float percentKilled = amountKilled / (float)totalCount;

        float currentSpeed = this.speed.Evaluate(percentKilled);
        transform.position += currentSpeed * Time.deltaTime * direction;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;

            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 1f))
            {
                AdvanceRow();
                break;
            }
            else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 1f))
            {
                AdvanceRow();
                break;
            }
        }
    }

    private void AdvanceRow()
    {
        direction = new Vector3(-direction.x, 0f, 0f);
        Vector3 position = transform.position;
        position.y -= 1f;
        transform.position = position;
    }

    public void ResetInvaders()
    {
        direction = Vector3.right;
        transform.position = initialPosition;

        foreach (Transform invader in transform)
        {
            invader.gameObject.SetActive(true);
        }
    }

    public int GetAliveCount()
    {
        int count = 0;
        foreach (Transform invader in transform)
        {
            if (invader.gameObject.activeSelf)
                count++;
        }
        return count;
    }


}

