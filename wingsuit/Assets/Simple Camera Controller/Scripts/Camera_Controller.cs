using UnityEngine;
using System.Collections;
 
public class Camera_Controller : MonoBehaviour
{

 

    public float Normal_Speed = 25.0f; //Normal movement speed
   
    public float Shift_Speed = 54.0f; //multiplies movement speed by how long shift is held down.
   
    public float Speed_Cap = 54.0f; //Max cap for speed when shift is held down
  
    public float Camera_Sensitivity = 0.6f; //How sensitive it with mouse
   
    static public Vector3 Mouse_Location = new Vector3(255, 255, 255); //Mouse location on screen during play (Set to near the middle of the screen)
    
    private float Total_Speed = 1.0f; //Total speed variable for shift



    void Update()
    {



        //Camera angles based on mouse position
        Mouse_Location = Input.mousePosition - Mouse_Location;
        
        Mouse_Location = new Vector3(-Mouse_Location.y * Camera_Sensitivity, Mouse_Location.x * Camera_Sensitivity, 0);
        
        Mouse_Location = new Vector3(transform.eulerAngles.x + Mouse_Location.x, transform.eulerAngles.y + Mouse_Location.y, 0);
       
        transform.eulerAngles = Mouse_Location;
       
        Mouse_Location = Input.mousePosition;


        Vector3 newPosition = transform.position;
       
     
    }

    
}