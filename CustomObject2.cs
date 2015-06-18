using System;
using System.Collections.Generic;
using System.Text;


using Java.Lang;
using Android.Hardware;
using Java.IO;
using Javax.Microedition.Khronos.Opengles;
using Java.Nio;
using Android.Opengl;

using XamiAndAR;
using XamiAndAR.Interfaces;
using XamiAndAR.Exceptions;
using XamiAndAR.Pub;
using XamiAndAR.Utilities;
using XamiAndAR.AndOpenGLCam;


namespace XamiAndARApp
{
    public class CustomObject2 : ARObject
    {


        private Cube mCube;


       public CustomObject2(string name, string patternName,
           double markerWidth, double[] markerCenter)
            : base(name, patternName, markerWidth, markerCenter) {

            mCube = new Cube();   
           
       }


        public override void Draw(IGL10 gl) {
            base.Draw(gl);



            gl.GlClear(GL10.GlColorBufferBit | GL10.GlDepthBufferBit);
            gl.GlLoadIdentity();

            gl.GlTranslatef(0.0f, 0.0f, 12.0f);
            //gl.GlRotatef(mCubeRotation, 1.0f, 1.0f, 1.0f);

            gl.GlViewport(0, 0, Convert.ToInt32(MarkerWidth), Convert.ToInt32(MarkerWidth));
            gl.GlMatrixMode(GL10.GlProjection);
            gl.GlLoadIdentity();
            GLU.GluPerspective(gl, 45.0f, (float)Convert.ToInt32(MarkerWidth) / (float)Convert.ToInt32(MarkerWidth), 0.1f, 100.0f);
            gl.GlViewport(0, 0, Convert.ToInt32(MarkerWidth), Convert.ToInt32(MarkerWidth));

            gl.GlMatrixMode(GL10.GlModelview);
            gl.GlLoadIdentity();

            mCube.draw(gl);
        
	}

    public override void Init(IGL10 p0)
        {
            
        }
    }
}
