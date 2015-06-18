using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Java.Lang;
using Android.Hardware;
using Java.IO;
using Android.Opengl;

//Namespaces present in XamiAndAR library.
using XamiAndAR;
using XamiAndAR.Interfaces;
using XamiAndAR.Exceptions;
using XamiAndAR.Pub;
using XamiAndAR.Utilities;
using XamiAndAR.AndOpenGLCam;



namespace XamiAndARApp
{

 
    [Activity(Label = "Activity1")]
    public class Activity1 : AndARActivity
    {

        ARObject someObject;
        ARToolkit artoolkit;
   
        protected override void OnCreate(Bundle savedInstanceState)
        {
                
            base.OnCreate(savedInstanceState);
         
                CustomRenderer renderer = new CustomRenderer();//Optional, may be set to null.
                base.SetNonARRenderer(renderer);//Or might be omited.

                try {
  
   //Register an object for each marker type. Here, the patt.hiro is a file which defines the marker that you print. Please print the marker present in the "Marker" folder inside the project.
                    artoolkit = base.Artoolkit;
                    someObject = new CustomObject
                        ("test", "patt.hiro", 100.0, new double[] { 0, 0 });


   //A custom 3D object created, you can check the file CustomObject1.cs. Comment the above line of code and uncomment the below one and check the output!
                    
                    //someObject = new CustomObject1
                    //   ("test", "patt.hiro", 100.0, new double[] { 0, 0 });
                   
                    artoolkit.RegisterARObject(someObject);

                } catch (AndARException ex){
                    //handle the exception, that means: show the user what happened
                    throw ex;
                }


                StartPreview();
            }


       


        public override void StartPreview()
        {

            base.StartPreview();
        }






        public override void UncaughtException(Thread thread, Throwable ex)
        {
            throw ex;
        }





   
    }
    }
