using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabola : MonoBehaviour
{
    public GameObject block;
    Vector3 offset;
    Vector3 target;
    float dag;

    IEnumerator ThrowBall()
    {
        float b = Mathf.Tan(dag * Mathf.Deg2Rad);
        float a = (target.y - b * target.x) / (target.x * target.x);

        for (float x = 0; x <= this.target.x; x += 0.3f)
        {

            float y = (a * x * x) +b * x;
            transform.position = new Vector3(x, y, 0) + this.offset;
            //Debug.Log("a: " + a);
            //Debug.Log("x: " + x);
            //Debug.Log("y: " + y);
            //Debug.Log("b: " + b);
            yield return null;
            
        }
    }

    public void SetTargat(Vector3 target, float dag)
    {
        this.offset = transform.position;
        this.target = target - this.offset;
        this.dag = dag;

        StartCoroutine("ThrowBall");
    }
    void Start()
    {
        //Debug.Log("block: " + block);
        SetTargat(block.transform.position, 60);
    }
}