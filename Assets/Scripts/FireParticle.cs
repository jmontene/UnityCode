using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour {

	public Vector2 minVelocity = new Vector2(-0.1f,0.2f);
	public Vector2 maxVelocity = new Vector2(0.1f,0.4f);

	public float lifeSpan = 2f;

	float actualLifeSpan;
	float timeAlive = 0f;
	Vector2 velocity;

	// Use this for initialization
	void OnEnable() {
		velocity = new Vector2(Random.Range(minVelocity.x,maxVelocity.x), Random.Range(minVelocity.y,maxVelocity.y));
		actualLifeSpan = lifeSpan * Random.Range(0.9f,1.1f);
		timeAlive = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;
		if(timeAlive >= actualLifeSpan){
			SimplePool.Despawn(gameObject);
			return;
		}
		transform.Translate(velocity*Time.deltaTime);
	}
}
