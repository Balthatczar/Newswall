using UnityEngine;
using System.Collections;

public class newswallControl_grid1 : MonoBehaviour {
	
	public				GameObject[]		gridTiles;
	private				Vector3[]			gridTiles_position;
	private				Vector3[]			gridTiles_screenPosition;

	
	public				string				gridTiles_url;
	private 			WWW					gridTiles_www;
	private				string				gridTiles_imageList;
	private				string[]			gridTiles_imageListArr;
	
	private				WWW[]				gridTiles_imageWWW;
	private				Texture2D[]			gridTiles_texture;
	
	public				string				gridTiles_tileType_url;
	private				WWW					gridTiles_tileType_www;
	private				string				gridTiles_tileType;
	private				string[]			gridTiles_tileTypeArr;
	
	public				string				grid_identifier_url;
	private             WWW                 grid_identifier_www;
	public              string              grid_identifier;
	
	
	
	private				int[]				gridTiles_width;
	private				int[]				gridTiles_height;
	private				int[]				gridTiles_startX;
	private				int[]				gridTiles_endX;
	private				int[]				gridTiles_startY;
	private				int[]				gridTiles_endY;
	
	private             Vector2[]           gridTiles_minB;
	private             Vector2[]           gridTiles_maxB;
	private             Vector2[]           gridTiles_diffB;
	
    private   			float[]				gridTiles_offsetStore;
	private   			float[]				gridTiles_offsetstartStore;
	
	public				GameObject			innerGrid;
	public				GameObject			outerGrid;
	
	public				GameObject          icon_scrollUp;
	public				GameObject          icon_scrollDown;
	private				bool[]				icon_bool;
	private				bool[]				icon_colorBool;
	private				float[]				icon_timeStore;
	private				int 				icon_current;
	private				bool 				icon_currentBool = true;
	private             int[]	            icon_checkList;
	private				int					icon_count;
	private				int					icon_countLength;
	private             float               icon_currentTime;
	private             float               icon_startTime;
	private             bool                icon_startTimeBool = true;
	private             bool                icon_currentTimeBool = true;
	private             bool                icon_loopBool = true;
	
	public 				Camera          	Cam;
	
	
	
	private  			Vector2   			TouchVector;
	public  			Touch     			t;
	private  			Vector2   			TouchStart;
	private  			Vector2				touchDeltaPosition;
	
	private				bool				fadeAllBool = false;
	private  			bool			    allClear = false;
	
	private				Vector2				startPos;
	private				Vector2				touchPos;
	private 			bool				couldBeSwipe = false;
	private				bool				backSwipe = false;
	private 			float				startTime;
	private				float 				swipeTime;
	private	 			Touch				touch;
	
	
	public				float				gridHorizontal_speed;
	private				float				gridHorizontal_offset;
	
	private				Vector2				scrollPos;
	private				float[]				scrollPos_inc;
	private				bool				scrollBool = false;
	
	private				bool				scrollBoolUp = false;
	private				float				scrollUp_time;
	private				bool				scrollBoolDown = false;
	private				float				scrollDown_time;
	
	private				int 				scrollSelect;
	
	public				GameObject			loaderTile;
	private				GameObject			loaderTile_nav;
	private				float				loaderTile_nav_timeStore;
	private				bool			    loaderTile_navBool = true;
	private				bool			    loaderTile_navBoot = true;
	public				Material			loaderTile_navMat;
	private				bool				loaderTile_bool = true;
	private				bool				loaderTile_boolExec = true;
	private				bool				loaderTile_progressBool = false;
	
	
	private				float				switchTile_inc;
	private				float				switchTile_inc2;
	private				float				switchTile_inc3 = 0.5f;
	private             int					switchTile_selected;
	private             int					switchTile_selected2;
	private             bool                switchTile_switch=false;
	private             bool                switchTile_switch2=false;
	private             bool                switchTile_fade=false;
	private             bool                switchTile_ready=true;
 
	private             int					switchTile_selectedFade;

	private             bool                switchTile_active=true;
	private             float				switchTile_timeStore;
	
	private             GameObject[]        readmoreTile;
	public				Material			readmoreTile_readIcon;
	private				int					readmoreTile_selected;
	private				bool[]				readmoreTile_fadeBool;
	private				bool[]				readmoreTile_readyBool;
	
	private				GameObject			infoTile;
	public				Material			infoTile_gridID;
	private				Vector3				infoTile_orgPos;
	private				bool				infoTile_timeBool=true;
	private				bool				infoTile_execBool=true;
	private				float				infoTile_timeStore;
	
	
	
	public				Material			actionButton_videoIcon;
	public				Material			actionButton_pictureIcon;
	public				Material			actionButton_audioIcon;
	public				Material			actionButton_infoIcon;
	
	public				GameObject			actionButton_template;
	private				GameObject[]		actionButton;
	private  			Vector3[]			actionButton_position;
	
	private				int					actionButton_selected;
	private				bool				actionButton_active=false;
	
	private				float				actionButton_timeStore;
	private				bool				actionButton_timeBool=true;
	
	private				bool				actionButton_fade=false;
	private				bool				actionButton_switch=false;
	

	private				bool				fadeOut=false;
	private				bool				fader=false;
	
	private				int 				bootCount;
	private				int					navHistory;
	
	

	
	// Use this for initialization
	void Start () {
	

		bootCount = PlayerPrefs.GetInt("bootCount");
		navHistory = PlayerPrefs.GetInt("navHistory");

		
				
		icon_bool = new bool[gridTiles.Length];
		
		icon_colorBool = new bool[gridTiles.Length];
		
		icon_timeStore = new float[gridTiles.Length];
			
		gridTiles_position = new Vector3[gridTiles.Length];
		
		gridTiles_screenPosition = new Vector3[gridTiles.Length];
		
		gridTiles_minB = new Vector2[gridTiles.Length];
		
		gridTiles_maxB = new Vector2[gridTiles.Length];
		
		gridTiles_diffB = new Vector2[gridTiles.Length];
				
		gridTiles_offsetStore = new float[gridTiles.Length];
		
		gridTiles_offsetstartStore = new float[gridTiles.Length];
		
		gridTiles_width = new int[gridTiles.Length];
		
		gridTiles_height = new int[gridTiles.Length];
		
		gridTiles_startX = new int[gridTiles.Length];
		
		gridTiles_startY = new int[gridTiles.Length];
		
		gridTiles_endX = new int[gridTiles.Length];
		
		gridTiles_endY = new int[gridTiles.Length];
		
		scrollPos_inc = new float[gridTiles.Length];
		
		gridTiles_www = new WWW(gridTiles_url);
		
		gridTiles_tileType_www = new WWW(gridTiles_tileType_url);
		
		grid_identifier_www = new WWW(grid_identifier_url);
		
		readmoreTile_fadeBool = new bool[gridTiles.Length];
		
		readmoreTile_readyBool = new bool[gridTiles.Length];
		
		
	
		loaderTile_nav = Instantiate(actionButton_template, new Vector3(loaderTile.transform.position.x, loaderTile.transform.position.y, loaderTile.transform.position.z), Quaternion.identity) as GameObject;
		loaderTile_nav.renderer.material = loaderTile_navMat;
		loaderTile_nav.renderer.material.color=new Color(1F,1F,1F,0F);
		loaderTile_nav.transform.localScale = new Vector3(20F,1F,5F);
		loaderTile_nav.transform.position += new Vector3(0F,0F,7.5f);
		
		infoTile = Instantiate(actionButton_template, new Vector3(0F, 0F, 0F), Quaternion.identity) as GameObject;
		infoTile.transform.localScale = new Vector3(8F,1F,3F);
		infoTile.transform.position = Cam.camera.ScreenToWorldPoint(new Vector3(850F,680F,0F));
		infoTile.transform.position = new Vector3(infoTile.transform.position.x,gridTiles_screenPosition[0].y,infoTile.transform.position.z);
		infoTile.renderer.material = infoTile_gridID;
		infoTile_orgPos = infoTile.transform.position;
		infoTile.transform.position += new Vector3(-20F,0F,0F);
		
		
		for ( int i=0 ; i < gridTiles.Length ; i++ ) 
		{
			
			gridTiles_position[i] = Cam.camera.WorldToViewportPoint(gridTiles[i].transform.position);
			
			gridTiles_screenPosition[i] = Cam.camera.WorldToScreenPoint(gridTiles[i].transform.position);
			
			gridTiles_screenPosition[i] = new Vector3(gridTiles_screenPosition[i].x,gridTiles_screenPosition[i].y,gridTiles_screenPosition[i].z-1F);
						
			gridTiles[i].renderer.material.color = new Color(0.0f,0.0f,0.0f,1.0f);
			
			gridTiles_minB[i] = Cam.camera.WorldToScreenPoint(gridTiles[i].renderer.bounds.min);
			gridTiles_maxB[i] = Cam.camera.WorldToScreenPoint(gridTiles[i].renderer.bounds.max);
		    gridTiles_diffB[i] = gridTiles_minB[i] - gridTiles_maxB[i];
			
			gridTiles_width[i] = (int) Mathf.CeilToInt(gridTiles_diffB[i].x);
			gridTiles_height[i] = (int) Mathf.CeilToInt(gridTiles_diffB[i].y);
			
			gridTiles_startY[i] = (int) gridTiles_screenPosition[i].y - (gridTiles_height[i]/2) + 30;
			gridTiles_endY[i] = (int) gridTiles_screenPosition[i].y + (gridTiles_height[i]/2) - 30;
			gridTiles_startX[i] = (int) gridTiles_screenPosition[i].x - (gridTiles_width[i]/2) + 30;
			gridTiles_endX[i] = (int) gridTiles_screenPosition[i].x + (gridTiles_width[i]/2) - 30;
			
			readmoreTile_fadeBool[i] = false;
			
			readmoreTile_readyBool[i] = false;
			
		}
		
		
		
		outerGrid.renderer.material.color = new Color(0.0f,0.0f,0.0f,1.0f);
		
		for (int j=0;j<innerGrid.renderer.materials.Length;j++)
		{
			innerGrid.renderer.materials[j].color = new Color(0.0f,0.0f,0.0f,1.0f);
		}
		
		
		StartCoroutine(loadTilesTexture());
		
		TouchVector.x=1000F;
		TouchVector.y=1000F;
		
		
	
	}
	
	
	
	public IEnumerator loadTilesTexture() {
		
		
		yield return grid_identifier_www;
		
		if (grid_identifier_www.isDone) grid_identifier = grid_identifier_www.text;
		
		
		yield return gridTiles_tileType_www;
		
		if (gridTiles_tileType_www.isDone)
		{
		
			gridTiles_tileType = gridTiles_tileType_www.text;
			
			gridTiles_tileTypeArr = gridTiles_tileType.Split('\n');
			
		}
		
		
		yield return gridTiles_www;
		
		if (gridTiles_www.isDone)
		{
			
			gridTiles_imageList = gridTiles_www.text;
			
			gridTiles_imageListArr = gridTiles_imageList.Split('\n');
		
			gridTiles_imageWWW = new WWW[gridTiles_imageListArr.Length];
			
			gridTiles_texture = new Texture2D[gridTiles_imageListArr.Length];
			
			
			for (int i = 0 ; i < gridTiles_texture.Length ; i++)
			{
			   
				gridTiles_imageWWW[i] = new WWW(gridTiles_imageListArr[i]);
				
				yield return gridTiles_imageWWW[i];
				
				gridTiles_texture[i] = gridTiles_imageWWW[i].texture; 
							
			}
			
			
			if (gridTiles_imageWWW[gridTiles.Length-1].progress > 0.9f) loaderTile_progressBool = true;
			
			int x = 0;
			
			for (int i = 0 ; i < gridTiles_texture.Length ; i++)
			{
				
				 if ( gridTiles_imageWWW[i].isDone ) x++;
						
			}
						
			
			if (x==gridTiles_texture.Length)
			{
				
				for (int i = 0 ; i < gridTiles_texture.Length ; i++)
				{
					
					gridTiles[i].renderer.material.mainTexture = gridTiles_texture[i];
					
					if (gridTiles_texture[i].height > gridTiles_height[i])
					{
						
						gridTiles_offsetStore[i] = (1F/gridTiles_texture[i].height)*gridTiles_height[i]; 
						
						gridTiles[i].renderer.material.SetTextureScale ("_MainTex", new Vector2( 1F ,   ( 1F/gridTiles_texture[i].height)*gridTiles_height[i] ));
						
						gridTiles[i].renderer.material.SetTextureOffset("_MainTex", new Vector2( 0.0f , ( 1F/gridTiles_texture[i].height)*gridTiles_height[i] ) * ( gridTiles_texture[i].height / gridTiles_height[i] - 1) );
						
						gridTiles[i].renderer.material.SetTextureOffset("_MainTex", new Vector2( 0.0f , 1F - ( 1F/gridTiles_texture[i].height)*gridTiles_height[i]) );
						
						scrollPos_inc[i] = gridTiles[i].renderer.material.mainTextureOffset.y;
						
						gridTiles_offsetstartStore[i] = gridTiles[i].renderer.material.mainTextureOffset.y;
						
						icon_countLength += 1;
						
				
					}
					
					if (gridTiles_texture[i].width > gridTiles_width[i])
					{
						
						gridTiles[i].renderer.material.SetTextureScale ("_MainTex", new Vector2( (1F/gridTiles_texture[i].width)*gridTiles_width[i] , 1F  ));
						
						gridTiles[i].renderer.material.SetTextureOffset("_MainTex", new Vector2( 1F - (1F/gridTiles_texture[i].width)*gridTiles_width[i] , 0.0F  ));

						
					}
					
				}
				
				int n = 0;
				
				icon_checkList = new int[icon_countLength];
				
				
				   for (int j = 0 ; j < gridTiles_texture.Length ; j++)
				   {
					
					 
					 if (gridTiles_tileTypeArr[j]=="switch" || gridTiles_tileTypeArr[j]=="switchphoto" || gridTiles_tileTypeArr[j]=="switchinfo" || gridTiles_tileTypeArr[j]=="switchaudio")
					 {
						gridTiles[j].renderer.material.SetTextureOffset("_MainTex",new Vector2(0F,0F));
					 }
					
				     if (gridTiles_texture[j].height > gridTiles_height[j])
					 {
						
						n++;	
					
						icon_checkList[n-1] = j;	
							
					 }
						
				   }
					
				
				if (icon_checkList.Length>0) icon_current = icon_checkList[0];
				
				
				readmoreTile = new GameObject[gridTiles.Length];
				actionButton = new GameObject[gridTiles.Length];
				actionButton_position = new Vector3[gridTiles.Length];
				
				for (int j = 0 ; j < actionButton.Length ; j++)
				{
					actionButton[j] = Instantiate(actionButton_template, new Vector3(actionButton_template.transform.position.x, actionButton_template.transform.position.y, actionButton_template.transform.position.z), Quaternion.identity) as GameObject;					
					if (gridTiles_tileTypeArr[j]=="switch" || gridTiles_tileTypeArr[j]=="video") actionButton[j].renderer.material = actionButton_videoIcon;
					if (gridTiles_tileTypeArr[j]=="picture" || gridTiles_tileTypeArr[j]=="switchphoto") actionButton[j].renderer.material = actionButton_pictureIcon;
					if (gridTiles_tileTypeArr[j]=="audio" || gridTiles_tileTypeArr[j]=="switchaudio") actionButton[j].renderer.material = actionButton_audioIcon;
					if (gridTiles_tileTypeArr[j]=="switchinfo") actionButton[j].renderer.material = actionButton_infoIcon;
					
					actionButton[j].renderer.material.color = new Color(0f,0f,0f,0.0f);
					
					
					readmoreTile[j] = Instantiate(actionButton_template, new Vector3(actionButton_template.transform.position.x, actionButton_template.transform.position.y, actionButton_template.transform.position.z), Quaternion.identity) as GameObject;
					
					readmoreTile[j].SetActiveRecursively(false);
					if (gridTiles_texture[j].height > gridTiles_height[j]) readmoreTile[j].SetActiveRecursively(true);
					
					readmoreTile[j].transform.position = new Vector3(gridTiles[j].transform.position.x,gridTiles[j].transform.position.y+1F,gridTiles[j].transform.position.z);
					readmoreTile[j].transform.position = Cam.camera.ScreenToWorldPoint(new Vector3(gridTiles_screenPosition[j].x,(gridTiles_screenPosition[j].y-(gridTiles_height[j]/2))+60F,gridTiles_screenPosition[j].z));
					readmoreTile[j].transform.localScale += new Vector3(3F,0F,0.25F);
					readmoreTile[j].renderer.material = readmoreTile_readIcon;
					readmoreTile[j].renderer.material.color -= new Color(0F,0F,0F,1F);
					readmoreTile[j].transform.localScale = new Vector3(0F,readmoreTile[j].transform.localScale.y,0F);
				
				}
				
				
				for (int j = 0 ; j < gridTiles.Length ; j++)
				{
					 if (gridTiles_tileTypeArr[j]=="switch" || gridTiles_tileTypeArr[j]=="switchphoto" || gridTiles_tileTypeArr[j]=="switchinfo" || gridTiles_tileTypeArr[j]=="switchaudio" || gridTiles_tileTypeArr[j]=="video" || gridTiles_tileTypeArr[j]=="picture" || gridTiles_tileTypeArr[j]=="audio")
					 {
						actionButton[j].transform.position = new Vector3(gridTiles[j].transform.position.x,gridTiles[j].transform.position.y+1F,gridTiles[j].transform.position.z);
						actionButton[j].transform.localScale = new Vector3(2.55f,1f,2.55f);
					 }	
					
				}
			}
		}
	}
	
	
	void actionButton_fadeOut(float duration)
	{
		 for (int i = 0 ; i < gridTiles.Length ; i++)
		 {  
		    if (actionButton[i].renderer.material.color.a > 0.0f) 
	        {
			     actionButton[i].renderer.material.color-= new Color((Time.fixedDeltaTime*duration)/3.2f,(Time.fixedDeltaTime*duration)/3.2f,(Time.fixedDeltaTime*duration)/3.2f,(Time.fixedDeltaTime*duration)/3.2f); 
			}
		 }
	}
	
	
	void fadeAllOut(float duration)
	{	    
		
		    fader = true;
		
			for (int i = 0 ; i < gridTiles.Length ; i++)
		    {
				if (gridTiles[i].renderer.material.color.r > 0.0f) 
	        	{
		      		 gridTiles[i].renderer.material.color-= new Color((Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,0.0f);
				}
			
				if (readmoreTile[i].renderer.material.color.a > 0.0f)
			    {
					readmoreTile[i].renderer.material.color-= new Color(0F,0F,0F,(Time.fixedDeltaTime*duration)/3.5f);
			    }
			
					if (readmoreTile[i].transform.localScale.x > 0F) readmoreTile[i].transform.localScale -= new Vector3((Time.fixedDeltaTime*duration*5F)/3.5f,0F,(Time.fixedDeltaTime*duration*5F)/3.5f);

		    }
		    
		   /*  for (int i = 0 ; i < gridTiles.Length ; i++)
		     {  
			   if (actionButton[i].renderer.material.color.a > 0.0f) 
	           {
			     actionButton[i].renderer.material.color-= new Color((Time.fixedDeltaTime*duration)/3.2f,(Time.fixedDeltaTime*duration)/3.2f,(Time.fixedDeltaTime*duration)/3.2f,(Time.fixedDeltaTime*duration)/3.2f); 
			   }
			
		     }*/
				
				if (outerGrid.renderer.material.color.r > 0.0f) 
	        	{
		      		outerGrid.renderer.material.color-= new Color((Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,0.0f);
				}
				
				if (infoTile.renderer.material.color.a > 0.0f)
				{
					infoTile.renderer.material.color-= new Color(0f,0f,0f,(Time.fixedDeltaTime*duration)/3.5f);
				}
		
				
				for ( int j=0;j<innerGrid.renderer.materials.Length;j++)
				{
					if (innerGrid.renderer.materials[j].color.r > 0.0f)
					{
		         	   innerGrid.renderer.materials[j].color-= new Color((Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,0.0f);
					}
				}
		
		       
		          icon_scrollUp.SetActiveRecursively(false);
				  icon_scrollDown.SetActiveRecursively(false);
				    
	  }			
			  
		
	
	
	void fadeAllIn(float startTime, float duration, int i)
	{
			
			if (Time.timeSinceLevelLoad > startTime)
			{
				if (!fadeAllBool && loaderTile.renderer.material.color.a <= 0.0f)
				{
		
				if (outerGrid.renderer.material.color.r < 1.0f) 
	        	{
		      		outerGrid.renderer.material.color+= new Color((Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,0.0f);
				}
				
				
				for ( int j=0;j<innerGrid.renderer.materials.Length;j++)
				{
					if (innerGrid.renderer.materials[j].color.r < 1.0f)
					{
		         	   innerGrid.renderer.materials[j].color+= new Color((Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,0.0f);
					}
				}
						
				for ( int x = 0 ; x < gridTiles.Length ; x++)
				{
					if (gridTiles_tileTypeArr[x]=="video" || gridTiles_tileTypeArr[x]=="picture" || gridTiles_tileTypeArr[x]=="audio")
						{
						   if (actionButton[x].renderer.material.color.a < 1f)
						    {
							 actionButton[x].renderer.material.color+=new Color((Time.fixedDeltaTime*duration)/0.5f,(Time.fixedDeltaTime*duration)/0.5f,(Time.fixedDeltaTime*duration)/0.5f,(Time.fixedDeltaTime*duration)/0.5f);
						    }
						}
				}
				
				
				for ( int x = 0; x < i ; x++ )
				{
				  	if (gridTiles[x].renderer.material.color.r < 1.0f) 
	        	  	{	
		      			gridTiles[x].renderer.material.color+= new Color((Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,(Time.fixedDeltaTime*duration)/3.5f,0.0f);
				  	}
				  		if (gridTiles[x].renderer.material.color.r >= 1.0f)  fadeAllBool = true;
				 }
				
				
			  }
					
		   }
				
		}
	
	
	
	void checkBackSwipe(float Length,float Height,float s1,float s2)
	{
		if (Input.touchCount > 0)
		{
			touch = Input.touches[0];
				
			switch ( touch.phase )
			{
				case TouchPhase.Began:
			
				startPos = touch.position;
				startTime = Time.time;		
					
				break;
				
				case TouchPhase.Moved:
				
				couldBeSwipe = true;
				
				break;
					
				case TouchPhase.Stationary:
					
				couldBeSwipe = false;
					
				break;
					
				case TouchPhase.Ended:
					
				swipeTime = Time.time - startTime;	
					
				touchPos = touch.position;
					
				 	if (startPos.y > touchPos.y)
					{
						if ( couldBeSwipe && (startPos.x - touchPos.x) > Length && (startPos.y - touchPos.y) < Height && ( swipeTime > s1 && swipeTime < s2))
						{
							
							backSwipe = true;
								
						}
					}
					
					if (startPos.y < touchPos.y)
					{
						if ( couldBeSwipe && (startPos.x - touchPos.x) > Length && (touchPos.y - startPos.y) < Height && ( swipeTime > s1 && swipeTime < s2))
						{
							
							backSwipe = true;
					
						}
					}
								
				break;
					
			}
		
		}
	}
	
	
	void progressLoader()
	{
		
		if (bootCount==0)
	  	{	
			if (loaderTile_navBool)
			{
				if (loaderTile_nav.renderer.material.color.a < 1F)
	 			{
		   			loaderTile_nav.renderer.material.color += new Color(0F,0F,0F,(Time.fixedDeltaTime*7F)/3.5f);
				}
			
				if (loaderTile_nav.renderer.material.color.a>1F) 
				{ 
					loaderTile_navBool=false; 
					loaderTile_nav_timeStore = Time.time; 	
				}
			}
	  
			if ( Time.time > (loaderTile_nav_timeStore+12F) && !loaderTile_navBool)
			{
				if (loaderTile_nav.renderer.material.color.a > 0.0f)
	 			{
		   			loaderTile_nav.renderer.material.color -= new Color(0F,0F,0F,(Time.fixedDeltaTime*7F)/3.5f);
				}
			}		
		
	     }
		
		
	 //if (bootCount==1 && navHistory!=1)
	 if (bootCount==1)		
	  {
		
			if (loaderTile_navBoot)
			{
				loaderTile_nav.transform.localScale = new Vector3(13.33F,1F,3.33F);
				//loaderTile_nav.transform.position += new Vector3(-11F,0F,-17.5f);
				
				loaderTile_navBoot = false;
			}
			
			if (loaderTile_navBool)
			{
				if (loaderTile_nav.renderer.material.color.a < 1.0f)
	 			{
		   			loaderTile_nav.renderer.material.color += new Color(0F,0F,0F,(Time.fixedDeltaTime*7F)/6.5f);
				}
			
				if (loaderTile_nav.renderer.material.color.a>1F) 
				{ 
					loaderTile_navBool=false; 
					loaderTile_nav_timeStore = Time.time; 
				}
			}
			
			if ( Time.time > (loaderTile_nav_timeStore+3F) && !loaderTile_navBool)
			{
				if (loaderTile_nav.renderer.material.color.a > 0.0f)
	 			{
		   			loaderTile_nav.renderer.material.color -= new Color(0F,0F,0F,(Time.fixedDeltaTime*7F)/3.5f);
				}
			}
		
		}
		
	
	 	if (loaderTile_bool)
	 	{
			loaderTile.transform.Rotate(new Vector3(0.0f,Time.fixedDeltaTime*500F,0.0f));
			loaderTile.transform.localScale = new Vector3(6f+Mathf.PingPong((Mathf.Sin(Time.time*1.25F)),1F)*2,1F,6f+Mathf.PingPong((Mathf.Sin(Time.time*1.25F)),1F)*2);
			
	 		if (loaderTile.renderer.material.color.a < 1.0f)
	 		{
		   		loaderTile.renderer.material.color += new Color(0F,0F,0F,(Time.fixedDeltaTime*7F)/3.5f);
		   
			}
	  	}
		
		
			
	  	if (loaderTile_progressBool)
	  	{
			loaderTile_bool = false;
			
			if (loaderTile.renderer.material.color.a > 0.0f)
	 		{
				loaderTile.renderer.material.color -= new Color(0F,0F,0F,(Time.fixedDeltaTime*15F)/3.5f);
				loaderTile.transform.Rotate(new Vector3(0.0f,Time.fixedDeltaTime*500F,0.0f));
				loaderTile.transform.localScale = new Vector3(6f+Mathf.PingPong((Mathf.Sin(Time.time*23.25F)),1F)*3,1F,6f+Mathf.PingPong((Mathf.Sin(Time.time*23.25F)),1F)*3);
			}	
	  	 }
			
		 if (loaderTile.renderer.material.color.a <= 0.0f && loaderTile_nav.renderer.material.color.a <= 0.0f)	{ loaderTile_boolExec = false; allClear = true; PlayerPrefs.SetInt("navHistory",0); }	
	
	}
	
	
	
	
	// Update is called once per frame
	
	void Update () {
	  
	  
		
	  if (loaderTile_boolExec) progressLoader();	
		
	  if (allClear)
	  {
						
		checkBackSwipe(200F,50F,0.1F,1F);	
	
		fadeAllIn(1.0f,4.0f,gridTiles.Length);
		
		if (icon_startTimeBool)
		{
			icon_startTime = Time.time;
			icon_startTimeBool = false;
		}
			
		if (backSwipe)
		{
			Cam.transform.position = Vector3.Lerp( Cam.transform.position, new Vector3(Cam.transform.position.x+10.0f,Cam.transform.position.y,Cam.transform.position.z),Time.deltaTime*10F);
			
			if ( Cam.transform.position.x > 32F )
			{
				fadeAllOut(14F);
					
				
				if (outerGrid.renderer.material.color.r<=0.0f) 
				{ 
					if (grid_identifier=="bioGrid2" || grid_identifier=="gitaarGrid" || grid_identifier=="drumsGrid" || grid_identifier=="keyboardGrid" || grid_identifier=="vioolGrid" || grid_identifier=="youriGrid")
					{
					    Application.LoadLevel("dhgGrid");
					}
						
					else {
							
						Application.LoadLevel("mainGrid");
					}
				}
			}				
		  }
			
		
		if (!backSwipe)
		{
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !actionButton_active) 
			{
				PlayerPrefs.SetInt("bootCount",1);
	
    	  		t = Input.touches[0];
          		TouchStart = t.position; 
          		TouchVector = Cam.camera.ScreenToViewportPoint(TouchStart);
	    	}
			
			if (Input.touchCount > 0 && !actionButton_active)
			{	
				t = Input.touches[0];
				
				switch ( touch.phase )
				{
					case TouchPhase.Began:
			
					scrollPos = t.position;
						
					scrollBool = true;	
				
					break;
				}
			}
			
				
			if (infoTile_execBool)
			{	
		    	if (Time.time > (icon_startTime + 2.4F))
				{
					infoTile.transform.position = Vector3.Lerp(infoTile.transform.position,infoTile_orgPos,Time.fixedDeltaTime*5F);
					
					if (infoTile.transform.position==infoTile_orgPos)
					{
						if (infoTile_timeBool)
						{
							infoTile_timeStore = Time.time;
							infoTile_timeBool = false;
						}	
					}
				
					if (!infoTile_timeBool)
					{
						if (Time.time > (infoTile_timeStore+5F))
						{
					    	infoTile.transform.position = Vector3.Lerp(infoTile.transform.position,new Vector3(infoTile.transform.position.x-20F,infoTile.transform.position.y,infoTile.transform.position.z),Time.fixedDeltaTime*3.35F);	
						}
						
						if (infoTile.transform.position.x < 0) infoTile_execBool=false;
					}
				}	
			}
				
			for (int i=0;i<gridTiles.Length;i++)
			{		
				if (gridTiles_texture[i].height > gridTiles_height[i])
				{
					if (Time.time > (icon_startTime + 1.8F) && icon_loopBool)
					{
						if (icon_currentBool)
						{
						
				    		icon_scrollUp.transform.position = Cam.camera.ScreenToWorldPoint(new Vector3(gridTiles_screenPosition[icon_current].x,gridTiles_screenPosition[icon_current].y+(gridTiles_height[icon_current]/2)-30F,gridTiles_screenPosition[icon_current].z));
						
							icon_scrollDown.transform.position = Cam.camera.ScreenToWorldPoint(new Vector3(gridTiles_screenPosition[icon_current].x,gridTiles_screenPosition[icon_current].y-(gridTiles_height[icon_current]/2)+30F,gridTiles_screenPosition[icon_current].z));		
					
				    		icon_timeStore[icon_current] = Time.time;
								
				    		icon_colorBool[icon_current] = true;
							
							icon_currentBool = false;		
						}
						
					
				   if (Time.time > (icon_timeStore[icon_current]+4F) && icon_scrollUp.renderer.material.color.a<0.1F) 
				   {
					   icon_currentBool = true;
							
					   if (icon_current<icon_checkList[icon_checkList.Length-1])  icon_count+=1;
							
					   icon_current = icon_checkList[icon_count];			
				   }
						
				    if ( icon_current == icon_checkList[icon_checkList.Length-1])
					   {
							if (icon_currentTimeBool)
							{
								icon_currentTime = Time.time;
								icon_currentTimeBool = false;
							}
							
							if (Time.time > (icon_currentTime + 4F))
							{
							  
							  icon_currentBool = false;
							  icon_loopBool = false;	
						  }		
					   }	
					}
					
		
						
				   if ( Vector2.Distance(TouchVector,gridTiles_position[i]) < (0.1f)/2F || (readmoreTile_readyBool[i] && readmoreTile[i].renderer.material.color.a < 0.2f))
				   {	
						if (!icon_bool[i])
						{
							 					
						  icon_scrollUp.transform.position = Cam.camera.ScreenToWorldPoint(new Vector3(gridTiles_screenPosition[i].x,gridTiles_screenPosition[i].y+(gridTiles_height[i]/2)-30F,gridTiles_screenPosition[i].z));
						    	
						  icon_scrollDown.transform.position = Cam.camera.ScreenToWorldPoint(new Vector3(gridTiles_screenPosition[i].x,gridTiles_screenPosition[i].y-(gridTiles_height[i]/2)+30F,gridTiles_screenPosition[i].z));
								
						  icon_timeStore[i] = Time.time;
								
						  icon_colorBool[i] = true;
								
						  icon_bool[i] = true;
								
						  readmoreTile_readyBool[i] = false;
						
						}
							
				    } else {
						
					   icon_bool[i] = false;
							
				     } 
						
					if (icon_colorBool[i])
					{
							
						if (readmoreTile[i].renderer.material.color.a < 1F) readmoreTile[i].renderer.material.color+=new Color(0F,0F,0F,Time.fixedDeltaTime*3F);
						
						if (!fader)
						{
							if (readmoreTile[i].transform.localScale.x < 4F ) readmoreTile[i].transform.localScale+=new Vector3(Time.fixedDeltaTime*20F,0F,0F);
							if (readmoreTile[i].transform.localScale.z < 1F ) readmoreTile[i].transform.localScale+=new Vector3(0F,0F,Time.fixedDeltaTime*10F);
						}
							
						if (readmoreTile[i].renderer.material.color.a >= 1F) readmoreTile_readyBool[i]=true;
							
					    icon_scrollUp.renderer.material.color = new Color(1.0f,1.0f,1.0f,Mathf.PingPong(Time.time*4F,1F));
								
						icon_scrollDown.renderer.material.color = new Color(1.0f,1.0f,1.0f,Mathf.PingPong(Time.time*4F,1F));
							
						if (Time.time > (icon_timeStore[i]+4F) && icon_scrollUp.renderer.material.color.a<0.1F)
						{ 
							icon_scrollUp.renderer.material.color = new Color(1.0f,1.0f,1.0f,0.0f);
								
							icon_scrollDown.renderer.material.color = new Color(1.0f,1.0f,1.0f,0.0f);
								
							icon_colorBool[i] = false;	
						}
					}
						
					if (readmoreTile_fadeBool[i])
					{	
						if (readmoreTile[i].renderer.material.color.a > 0F) readmoreTile[i].renderer.material.color-=new Color(0F,0F,0F,Time.fixedDeltaTime*4.75F);
					}
						
							
					if ( t.position.y > scrollPos.y && ( t.position.x > gridTiles_startX[i] && t.position.x < gridTiles_endX[i] && t.position.y > gridTiles_startY[i] && t.position.y < gridTiles_endY[i] ) )
					{	
					   if (scrollBool)
					   {
							if ( ( t.position.y > ( gridTiles_startY[i] + gridTiles_height[i] / 2 )) && (t.position.y < gridTiles_endY[i] ) )
							{												
							    scrollUp_time = Time.time;
									
								scrollBoolUp = true;	
							}
							
							if ( ( t.position.y > ( gridTiles_startY[i] ) ) && (t.position.y < ( gridTiles_endY[i] - gridTiles_height[i] / 2 ) ) && gridTiles[i].renderer.material.mainTextureOffset.y >= 0F )
							{					
								 scrollDown_time = Time.time;	
									
								 scrollBoolDown = true;
									
								 readmoreTile_fadeBool[i] = true;	
							}
						 }
							
							if (scrollBoolUp)
							{
								if ( gridTiles[i].renderer.material.mainTextureOffset.y < gridTiles_offsetstartStore[i] ) scrollPos_inc[i] += (gridTiles_offsetStore[i]/10F)/10F;
								
								gridTiles[i].renderer.material.SetTextureOffset("_MainTex", new Vector2(0.0f,scrollPos_inc[i]));
								
								if (Time.time > (scrollUp_time+0.7F)) scrollBoolUp = false;
							}
							
							if (scrollBoolDown)
							{
								if ( gridTiles[i].renderer.material.mainTextureOffset.y>0F ) scrollPos_inc[i] -= (gridTiles_offsetStore[i]/10F)/10F;
								
								gridTiles[i].renderer.material.SetTextureOffset("_MainTex", new Vector2(0.0f,scrollPos_inc[i]));
								
								if (Time.time > (scrollDown_time+0.7F)) scrollBoolDown = false;
							}
								
					   scrollBool = false;		
					}	
				 }
					
					
			 if (gridTiles_tileTypeArr[i]=="scroll")
			 {
				if (gridTiles_texture[i].width > gridTiles_width[i])
				{
						
	         		gridHorizontal_offset =  Mathf.Repeat((Time.time * 0.05f) * Time.fixedDeltaTime * gridHorizontal_speed ,1.0f); 
		
		 			gridTiles[i].renderer.material.SetTextureOffset("_MainTex", new Vector2(gridHorizontal_offset,0.0f));	
									
				}
						
			  }
			}
				
		
			for (int i=0;i<gridTiles.Length;i++)
			{
			  if (gridTiles_tileTypeArr[i]!="scroll") 
			   {
				if (gridTiles_tileTypeArr[i]=="video" || gridTiles_tileTypeArr[i]=="picture" || gridTiles_tileTypeArr[i]=="audio")
				{   
				   actionButton_position[i] = Cam.camera.WorldToViewportPoint(actionButton[i].transform.position);
						
				  if ( Vector2.Distance(TouchVector,actionButton_position[i]) < 0.05F)
				   {
					   actionButton_selected = i;
					   
					   actionButton_active = true;		
				   }	
				}	
				
			
				if (gridTiles[i].renderer.material.mainTextureOffset.x==0F)
				{
					
				 if (switchTile_ready)
				 {
			   		if ( Vector2.Distance(TouchVector,gridTiles_position[i])<0.1F && switchTile_active)
					{
						if (gridTiles_tileTypeArr[i]=="switch" || gridTiles_tileTypeArr[i]=="switchphoto" || gridTiles_tileTypeArr[i]=="switchinfo" || gridTiles_tileTypeArr[i]=="switchaudio" )
			            {	
							switchTile_ready = false;			
							switchTile_selected = i;
							switchTile_switch =  true;
							switchTile_inc = 0F;
							switchTile_inc2 = 0.5F;
						
							TouchVector.x = 1000F;
							TouchVector.y = 1000F;
							
							actionButton_position[switchTile_selected] = Cam.camera.WorldToViewportPoint(actionButton[switchTile_selected].transform.position);
		
							if (switchTile_active)
							{
					  	  	  switchTile_timeStore = Time.time;
						      switchTile_active = false;
							}		
						}		
					}	
				}
			 }
				
				if (gridTiles[i].renderer.material.mainTextureOffset.x != 0F && i!=switchTile_selected)
				{
					switchTile_selected2 = i;
					switchTile_switch2 = true;
				}
			  }
			}
				
				
			if (switchTile_switch)
			{	
			   if (switchTile_inc<0.5F) switchTile_inc+=(0.05F)/2F;
			
			   gridTiles[switchTile_selected].renderer.material.SetTextureOffset("_MainTex", new Vector2(switchTile_inc,0.0f));
			   
			   if (gridTiles[switchTile_selected].renderer.material.mainTextureOffset.x >= 0.5F)
			   {
					actionButton[switchTile_selected].SetActiveRecursively(true);
						
			        if (!actionButton_active) 
					{
						if (actionButton[switchTile_selected].renderer.material.color.r<1F) actionButton[switchTile_selected].renderer.material.color += new Color((Time.fixedDeltaTime*12f)/3.5f,(Time.fixedDeltaTime*12f)/3.5f,(Time.fixedDeltaTime*12f)/3.5f,(Time.fixedDeltaTime*12f)/3.5f);	
					}
						
			   		if ( Vector2.Distance(TouchVector,actionButton_position[switchTile_selected]) < 0.05F)
			   		{
						actionButton_selected = switchTile_selected;
						actionButton_active=true;
						actionButton_switch=true;	
			   		}			
			    }
			}
			
						   
		
			if (switchTile_switch2)
			{
			 if (gridTiles[switchTile_selected2].renderer.material.mainTextureOffset.x != 0F)
			 {			
				if (gridTiles_tileTypeArr[switchTile_selected2]=="switch" || gridTiles_tileTypeArr[switchTile_selected2]=="switchphoto" || gridTiles_tileTypeArr[switchTile_selected2]=="switchinfo" || gridTiles_tileTypeArr[switchTile_selected2]=="switchaudio")
				{
							
			        if (switchTile_inc2>0F) switchTile_inc2-=(0.05F)/2F;		
						
			        gridTiles[switchTile_selected2].renderer.material.SetTextureOffset("_MainTex", new Vector2(switchTile_inc2,0.0f));
							
					actionButton[switchTile_selected2].renderer.material.color = new Color(1F,1F,1F);		
					
					switchTile_selectedFade = switchTile_selected2;
					switchTile_fade=true;		
		
					//actionButton[switchTile_selected2].SetActiveRecursively(false);		
				}
			  }			
			}
			
			if (switchTile_fade)
			{
				actionButton[switchTile_selectedFade].renderer.material.color -= new Color((Time.fixedDeltaTime*14f)/3.5f,(Time.fixedDeltaTime*14f)/3.5f,(Time.fixedDeltaTime*14f)/3.5f,(Time.fixedDeltaTime*14f)/3.5f);		
	            actionButton[switchTile_selectedFade].transform.localScale-=new Vector3((Time.fixedDeltaTime*14f)/3.5f,0f,(Time.fixedDeltaTime*14f)/3.5f);
				
				if (actionButton[switchTile_selectedFade].transform.localScale.x<=0f) 
				{
				   switchTile_fade=false; 
				   actionButton[switchTile_selectedFade].renderer.material.color = new Color(0f,0f,0f,0f); 
				   actionButton[switchTile_selectedFade].transform.localScale=new Vector3(2.55f,1f,2.55f);
				}
			}
				
			if (Time.time > (switchTile_timeStore+1F)) {switchTile_active=true;	switchTile_switch2=false;}
			if (Time.time > (switchTile_timeStore+1.1F)) switchTile_ready=true;	
				
			if (actionButton_active)
			{  
			   if (actionButton_timeBool)
			   {
				   actionButton_timeStore = Time.time;
				   actionButton_timeBool = false;
				   Debug.Log(actionButton_timeStore);
			   }
					
			   if (Time.time < (actionButton_timeStore+3F))  actionButton[actionButton_selected].renderer.material.color = new Color(Mathf.PingPong(Time.fixedTime*2.5f,1F),Mathf.PingPong(Time.fixedTime*2.5f,1F),Mathf.PingPong(Time.fixedTime*2.5f,1F));	
			   
			   if (Time.time > (actionButton_timeStore+3F)) 
			   { 
				
				  if (actionButton[actionButton_selected].renderer.material.color.r<1f && !fadeOut)	actionButton[actionButton_selected].renderer.material.color += new Color((Time.fixedDeltaTime*14f)/3.5f,(Time.fixedDeltaTime*14f)/3.5f,(Time.fixedDeltaTime*14f)/3.5f,(Time.fixedDeltaTime*14f)/3.5f);
				 
				  if (Time.time > (actionButton_timeStore+3.25F))  actionButton_fadeOut(34f);
				  if (Time.time > (actionButton_timeStore+3.45F))  fadeAllOut(14f);
				 
				
				  if (gridTiles_tileTypeArr[actionButton_selected]=="switch" || gridTiles_tileTypeArr[actionButton_selected]=="switchphoto" || gridTiles_tileTypeArr[actionButton_selected]=="switchinfo" || gridTiles_tileTypeArr[actionButton_selected]=="switchaudio")
				  {
					TouchVector.x=1000F;
					TouchVector.y=1000F;
							
					if (gridTiles[actionButton_selected].renderer.material.mainTextureOffset.x > 0f && actionButton[actionButton_selected].renderer.material.color.r<=0F)
					{
					  if (switchTile_inc3>0F) switchTile_inc3-=(0.05F)/1F;		
			          gridTiles[actionButton_selected].renderer.material.SetTextureOffset("_MainTex", new Vector2(switchTile_inc3,0.0f));			
					}
				   }
						
				   if (Time.time > (actionButton_timeStore+4.0F)) loaderHUB._loaderHUB(grid_identifier,gridTiles_tileTypeArr,actionButton_selected);
			   }
					
			  }
				
				
				
		  
		 }
			
			

	  }
		
   }
	
}
