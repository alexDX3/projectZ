using UnityEngine;
using System.Collections;

public class playerCh : MonoBehaviour {
	private int money, health ;
	public int showMoney(){
		return money;
	}
 	public bool getmonetbuild(int x){
 		Debug.Log(1111);
 		if(money-x>=0){money-=x;return true;}else return false;
 	}
	// Use this for initialization
	void Start () {
		money = 1000;
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(health<=0)Debug.Log("DEAD!!!!!");
	}
	void OnCollisionEnter2D(Collision2D collision) {
		
		if(collision.gameObject.tag=="enemyGun"){
			
			health-=collision.gameObject.GetComponent<EnemyCh>().Fire;
			Debug.Log(health);
			Destroy(collision.gameObject);
		}
	}
}
