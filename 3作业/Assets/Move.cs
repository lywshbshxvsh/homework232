using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform leftBlock;
    public Transform rightBlock;

    private Vector3 direction = Vector3.right;
    private float speed = 2f;
    private bool isMoving = true;

    private Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, Color.white };
    private int colorIndex = 0;

    private void Start()
    {
        StartCoroutine(ChangeColorRoutine());
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            if (transform.position.x >= rightBlock.position.x || transform.position.x <= leftBlock.position.x)
            {
                isMoving = false;
                StartCoroutine(ChangeDirectionAndColor());
            }
        }
    }

    private IEnumerator ChangeDirectionAndColor()
    {
        yield return new WaitForSeconds(1f);

        direction = -direction;

        if (colorIndex < colors.Length - 1)
        {
            colorIndex++;
        }
        else
        {
            colorIndex = 0;
        }

        GetComponent<Renderer>().material.color = colors[colorIndex];

        isMoving = true;
    }

    private IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (colorIndex < colors.Length - 1)
            {
                colorIndex++;
            }
            else
            {
                colorIndex = 0;
            }

            GetComponent<Renderer>().material.color = colors[colorIndex];
        }
    }
}
