using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
	[SerializeField]
	private GameObject fogObject;
	[SerializeField]
	private Transform player;
	[SerializeField]
	private LayerMask fogLayer;
	[SerializeField]
	private float r = 1f;

	private Mesh mesh;
	private Vector3[] vertices;
	private Color[] colors;
	private float r2;

	void Start()
	{
		SetVariables();
		
		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = fogObject.transform.TransformPoint(vertices[i]);
		}
	}

	void SetVariables()
	{
		r2 = r * r;
		mesh = fogObject.GetComponent<MeshFilter>().mesh;
		vertices = mesh.vertices;
		Debug.Log(vertices.Length);
		colors = new Color[vertices.Length];

		for (int i = 0; i < colors.Length; i++)
		{
			colors[i] = Color.black;
		}

		ChangeColor();
	}

	void Update()
	{
		Ray r = new Ray(transform.position, player.position - transform.position);
		RaycastHit hit;
		if (Physics.Raycast(r, out hit, 1000, fogLayer, QueryTriggerInteraction.Collide))
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				float dist = Vector3.SqrMagnitude(vertices[i] - hit.point);
				if (dist < r2)
				{
					float alpha = Mathf.Min(colors[i].a, dist / r2);
					colors[i].a = alpha;
				}
			}
			ChangeColor();
		}
	}

	void ChangeColor()
	{
		mesh.colors = colors;
	}
}