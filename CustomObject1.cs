using System;
using System.Collections.Generic;
using System.Text;


using Java.Lang;
using Android.Hardware;
using Java.IO;
using Javax.Microedition.Khronos.Opengles;
using Java.Nio;

using XamiAndAR;
using XamiAndAR.Interfaces;
using XamiAndAR.Exceptions;
using XamiAndAR.Pub;
using XamiAndAR.Utilities;
using XamiAndAR.AndOpenGLCam;


namespace XamiAndARApp
{
    public class CustomObject1 : ARObject
    {
        private SimpleBox box = new SimpleBox();

 
       public CustomObject1(string name, string patternName,
           double markerWidth, double[] markerCenter)
            : base(name, patternName, markerWidth, markerCenter) {            
  
       }

        public override void Draw(IGL10 gl) {
            base.Draw(gl);
	    gl.GlColor4f(0, 1.0f, 0, 1.0f);
	    gl.GlTranslatef( 0.0f, 0.0f, 12.5f );
	    box.Draw(gl);
           
	}
        public override void Init(IGL10 p0)
        {
           // throw new NotImplementedException();
        }
    }
}
