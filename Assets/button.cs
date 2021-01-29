using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using homework2DLL;
using UnityEngine.UI;
public class button : MonoBehaviour
{
  string name;
  string daynight;
  public static double clock;
  //public double Clock {get{return clock;}}
  public GameObject inputTEXT;
  public GameObject Outouttext;
 private void Start() 
 {
    
  }
  public void click()
   {
       name = inputTEXT.GetComponent<Text>().text;
       smartInput insert = new smartInput(name); 
       clock = insert.Clock;
       clock = clock%24;
       if(clock<=12)
       {
         daynight = "AM";
       }
       else
       {
         daynight = "PM";
       }
       Outouttext.GetComponent<Text>().text = clock.ToString()+" "+daynight;

   }
}
