using UnityEngine;
using System.Collections;

public class Change : MonoBehaviour {
private delegate void InputHandler();
	bool build = false;
	GameObject GuiCam, Player,CanvasBuild, agreementBut;
	public GameObject house, ghouse;
	public  bool remoteTesting, buildClick;
	private InputHandler CurrentInputHandler;
	private int flagbuild;
	private Vector3 cclick;
	public void onChangeBuild(){
		Debug.Log("Button press)");
		if(build){GetComponent<Camera>().orthographicSize  = 5;GuiCam.active = true;CanvasBuild.active = false;}
		else {GetComponent<Camera>().orthographicSize  = 10;GuiCam.active = false;CanvasBuild.active = true;}
		 build=!build;
		
	}
	public void buildhouse(int flag){
		flagbuild = flag;
		agreementBut.active = false;
		buildClick = false;
		Debug.Log(flag);
	}
	public void buildAnyBuilding(){
		
		switch(flagbuild){
		case 1:{
			if(Player.GetComponent<playerCh>().getmonetbuild(100))Instantiate(house, new Vector3(this.GetComponent<Camera>().ScreenToWorldPoint(cclick).x,this.GetComponent<Camera>().ScreenToWorldPoint(cclick).y,0), this.transform.rotation);
			break;
		}
		}
		agreementBut.active = false;
	}
    void TouchInputHandler()
    {

    }
    void MouseInputHandler()
    {
    	if(Input.GetKeyDown(KeyCode.Mouse0)){

    		cclick = Input.mousePosition;
    		Debug.Log(cclick);
    		if(flagbuild!=2&&!buildClick){
    			agreementBut.GetComponent<RectTransform>().transform.position = cclick;
    			agreementBut.active = true;
    			buildClick=!buildClick;
    		}
    	
    	}
    }
	// Use this for initialization
	void Start () {
		flagbuild = 0;
		agreementBut = GameObject.Find("agreement");
		agreementBut.active=false;
		GuiCam  = GameObject.FindWithTag("Gtag");
		Player = GameObject.FindWithTag("Player");
		CanvasBuild = GameObject.Find("build");
		CanvasBuild.active = false;
		#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY
        CurrentInputHandler = TouchInputHandler;
		#endif
		#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE
		        // gameObject.SetActive(false);
		        CurrentInputHandler = MouseInputHandler;
		#endif
		        if (remoteTesting)
            CurrentInputHandler = TouchInputHandler;
    
	}
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,this.transform.position.z);
		if(build&&flagbuild!=0){
			CurrentInputHandler();
		}
	}

}
