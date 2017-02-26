using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticleEffect : MonoBehaviour {

	public GameObject particlePrefab;
	public float ratePerSecond = 500f;

	protected float timeSinceLastSpawn = 0f;
	protected PolygonCollider2D pCollider;

	// Use this for initialization
	void Start () {
		pCollider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn += Time.deltaTime;
		float correctTime = 1f/ratePerSecond;

		while(timeSinceLastSpawn > correctTime){
			SpawnFireAlongOutline();
			timeSinceLastSpawn -= correctTime;
		}
	}

	void SpawnFireAlongOutline(){
		int pathIndex = Random.Range(0,pCollider.pathCount);
		Vector2[] points = pCollider.GetPath(pathIndex);
		int pointIndex = Random.Range(0,points.Length);
		Vector2 spawnPointA = points[pointIndex];
		Vector2 spawnPointB = points[(pointIndex+1) % points.Length];

		Vector2 spawnPoint = Vector2.Lerp(spawnPointA,spawnPointB, Random.Range(0f,1f));
		SpawnFireAtPosition((spawnPoint + (Vector2)transform.position)*(Vector2) transform.localScale);
	}

	void SpawnFireAtPosition(Vector2 position){
		SimplePool.Spawn(particlePrefab,position, Quaternion.identity);
	}
}
