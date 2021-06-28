using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainInstantiator : MonoBehaviour
{
    public GameObject plataformPrefab;
    public SpriteShapeController terrain;
    public float MaxY = 20;
    public float MinY = 10;
    public GameObject TerrainPrefab;
    public int pointsSpriteShape = 5;
    private void Start()
    {
        float InitialPos = TerrainPrefab.transform.localScale.x / 2;
        terrain.spline.Clear();
        for (int i = 0; i < pointsSpriteShape; i++)
        {
            terrain.spline.InsertPointAt(i, new Vector3(InitialPos * i, Random.Range(MinY, MaxY), 0));
        }
        terrain.spline.InsertPointAt(pointsSpriteShape, terrain.spline.GetPosition(pointsSpriteShape - 1) + Vector3.down * terrain.spline.GetPosition(pointsSpriteShape - 1).y);
        terrain.spline.InsertPointAt(pointsSpriteShape + 1, new Vector3(InitialPos, 0, 0));

        int RandomPositionX= Random.Range(0, terrain.spline.GetPointCount() - 3);
        for (int i = RandomPositionX; i < RandomPositionX + 3; i++)
        {
            terrain.spline.SetPosition(i, new Vector3(terrain.spline.GetPosition(i).x, terrain.spline.GetPosition(RandomPositionX).y, terrain.spline.GetPosition(i).z));
        }
        Instantiate(plataformPrefab,new Vector3(terrain.spline.GetPosition(RandomPositionX+2).x+terrain.transform.position.x, terrain.spline.GetPosition(RandomPositionX + 2).y+0.6f, terrain.spline.GetPosition(RandomPositionX + 2).z),Quaternion.identity );
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameManager.GetInstance().win = false;
            GameManager.GetInstance().gameOver = true;
            GameManager.GetInstance().GameOver();
        }
    }
}
