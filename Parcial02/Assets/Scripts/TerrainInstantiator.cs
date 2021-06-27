using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainInstantiator : MonoBehaviour
{
    public SpriteShapeController terrain;
    public float MaxY = 20;
    public float MinY = 10;
    public GameObject TerrainPrefab;
    public int pointsSpriteShape = 5;
    private Camera camera;
    private void Start()
    {
        float InitialPos = TerrainPrefab.transform.localScale.x / 2;
        terrain.spline.Clear();
        camera = Camera.main;
        for (int i = 0; i < pointsSpriteShape; i++)
        {
            terrain.spline.InsertPointAt(i, new Vector3(InitialPos * i, Random.Range(MinY, MaxY), 0));
        }
        terrain.spline.InsertPointAt(pointsSpriteShape, terrain.spline.GetPosition(pointsSpriteShape - 1) + Vector3.down * terrain.spline.GetPosition(pointsSpriteShape - 1).y);
        terrain.spline.InsertPointAt(pointsSpriteShape + 1, new Vector3(InitialPos, 0, 0));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
