using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PointGenerator : MonoBehaviour
{
    [SerializeField]
	protected PolygonCollider2D bounds;

    public List<Vector2> samplePoints;

	protected float width;
	protected float height;

    public void SetBounds(float width, float height)
    {
		this.width = width;
		this.height = height;
		bounds.SetPath (0, new Vector2[]{
			new Vector2(0,0),
			new Vector2(0,height),
			new Vector2(width,0),
			new Vector2(width,height)
		});
    }

    public virtual Vector2 RandPoint()
    {
        float x = UnityEngine.Random.Range(0, width);
        float y = UnityEngine.Random.Range(0, height);
        return new Vector2(x, y);
    }

    public virtual Vector2 NextPoint()
    {
        return RandPoint();
    }


    public Vector2[] Corners()
    {
		return bounds.points;
    }

    public abstract void Init();
    public abstract void Init(Vector2[] sourcePoints);
    public abstract void Generate(out List<Vector2> results);
    public abstract void Generate(float width, float height, float minDstance, int maxPointsDesired, out List<Vector2> results);
   
}