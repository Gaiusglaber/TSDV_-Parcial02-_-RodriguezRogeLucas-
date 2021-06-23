using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ChunksTest : MonoBehaviour
{
    SpriteShapeController spriteshape;

    private void Start()
    {
        spriteshape = GetComponentInChildren<SpriteShapeController>();
        Debug.Log(spriteshape.cornerAngleThreshold);
    }
}
