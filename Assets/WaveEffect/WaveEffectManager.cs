﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEffectManager : MonoBehaviour
{
    public GameObject toInstantiate;
    public Transform startPoint;
    public float frequency;
    private float widthToInstantiate;
    private float timeElapsed = 0;
    private List<Transform> instancedShapes = new List<Transform>();
    private int count = 0;
    private int max = 360;

    private void Start()
    {
        widthToInstantiate = toInstantiate.GetComponent<Renderer>().bounds.size.x;
        StartCoroutine(SpawnShapes());

    }

    void Update()
    {
        //timeElapsed += Time.deltaTime;
        //if (timeElapsed >= frequency)
        //{
        //    timeElapsed = 0;
        //    GameObject instantiated = Instantiate(toInstantiate, startPoint.position, new Quaternion(0, 0, 0, 0));
        //    instancedShapes.Add(instantiated.transform);
        //    foreach (Transform transformInstancedShape in instancedShapes)
        //    {
        //        transformInstancedShape.position = new Vector3(
        //            transformInstancedShape.transform.position.x - widthToInstantiate,
        //            transformInstancedShape.position.y,
        //            transformInstancedShape.position.z);
        //    }
        //    Debug.Log(Time.time);
        //    instantiated.transform.localScale = new Vector3(1, Mathf.Sin(Time.time * frequency) * 10, 1);
        //}

        //GameObject instantiated = Instantiate(toInstantiate, startPoint.position, new Quaternion(0, 0, 0, 0));
        //instancedShapes.Add(instantiated.transform);
        //foreach (Transform transformInstancedShape in instancedShapes)
        //{
        //    transformInstancedShape.position = new Vector3(
        //        transformInstancedShape.transform.position.x - widthToInstantiate,
        //        transformInstancedShape.position.y,
        //        transformInstancedShape.position.z);
        //}
        //Debug.Log(Time.time);
        //instantiated.transform.localScale = new Vector3(1, Mathf.Sin(Time.time) * 20, 1);

        //count = (count +1 ) % max;
        //GameObject instantiated = Instantiate(toInstantiate, startPoint.position, new Quaternion(0, 0, 0, 0));
        //instancedShapes.Add(instantiated.transform);
        //foreach (Transform transformInstancedShape in instancedShapes)
        //{
        //    transformInstancedShape.position = new Vector3(
        //        transformInstancedShape.transform.position.x - widthToInstantiate,
        //        transformInstancedShape.position.y,
        //        transformInstancedShape.position.z);
        //}
        //instantiated.transform.localScale = new Vector3(1, Mathf.Sin(count * max) * 20, 1);
    }

    IEnumerator SpawnShapes()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            count = (count + 1) % max;
            GameObject instantiated = Instantiate(toInstantiate, startPoint.position, new Quaternion(0, 0, 0, 0));
            instancedShapes.Add(instantiated.transform);
            foreach (Transform transformInstancedShape in instancedShapes)
            {
                transformInstancedShape.position = new Vector3(
                    transformInstancedShape.transform.position.x - widthToInstantiate,
                    transformInstancedShape.position.y,
                    transformInstancedShape.position.z);
            }
            Debug.Log(Mathf.Sin(max / 60 * count));
            instantiated.GetComponent<Renderer>().material.color = new Color32(0, 0 ,(byte)(count * 255 / 100), 255);
            instantiated.transform.localScale = new Vector3(
                instantiated.transform.localScale.x,
                Mathf.Sin(max / 60 * count * Mathf.Deg2Rad) * 33,
                instantiated.transform.localScale.z);
        }
    }
}
