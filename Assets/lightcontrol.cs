using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using homework2DLL;
using System;
[ExecuteAlways]
public class lightcontrol : MonoBehaviour
{
   [SerializeField] private Light DirectionalLight;
   [SerializeField] private Lightgas Preset;
   [SerializeField,Range(0,24)] private float TimeOfDay;
   //button test2 = new button();
    private void Update() 
    {
        if(Preset ==null)
        return;
        if(Application.isPlaying)
        {
            //TimeOfDay += Time.deltaTime;
           
            TimeOfDay = Convert.ToSingle(button.clock);
            TimeOfDay %= 24;
            UpdateLighting(TimeOfDay/24f);
        }
        else
        {
            UpdateLighting(TimeOfDay/24f);
        }
   }
   
   void UpdateLighting(float timePercent)
   {
       RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
       RenderSettings.fogColor = Preset.Fogcolor.Evaluate(timePercent);
       if(DirectionalLight !=null)
       {
           DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
           DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent*360f)-90f,170,0));
       }

   }
     void OnValidate()
   {
       if(DirectionalLight !=null)
          return;
       if(RenderSettings.sun != null)
       {
           DirectionalLight = RenderSettings.sun;
       } 
       else
       {
           Light[] lights = GameObject.FindObjectsOfType<Light>();
           foreach (Light light in lights)
           {
               if(light.type == LightType.Directional)
               {
                   DirectionalLight = light;
                   return;
               }
           }
       }  
   }
}
