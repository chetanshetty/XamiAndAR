//The below "Cube" class source code is converted to C# - Xamarin.Android and the original Android source can be found on the webpage: https://androidcookbook.com/Recipe.seam;jsessionid=55018D48CF4275BAB976D874D32FDB87?recipeId=1529

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
   public class Cube:Java.Lang.Object
    {
        public FloatBuffer mVertexBuffer;
        public FloatBuffer mColorBuffer;
        public ByteBuffer mIndexBuffer;

        private float[] vertices = {
                                -1.0f, -1.0f, -1.0f,
                                1.0f, -1.0f, -1.0f,
                                1.0f,  1.0f, -1.0f,
                                -1.0f, 1.0f, -1.0f,
                                -1.0f, -1.0f,  1.0f,
                                1.0f, -1.0f,  1.0f,
                                1.0f,  1.0f,  1.0f,
                                -1.0f,  1.0f,  1.0f
                                };
        private float[] colors = {
                               0.0f,  1.0f,  0.0f,  1.0f,
                               0.0f,  1.0f,  0.0f,  1.0f,
                               1.0f,  0.5f,  0.0f,  1.0f,
                               1.0f,  0.5f,  0.0f,  1.0f,
                               1.0f,  0.0f,  0.0f,  1.0f,
                               1.0f,  0.0f,  0.0f,  1.0f,
                               0.0f,  0.0f,  1.0f,  1.0f,
                               1.0f,  0.0f,  1.0f,  1.0f
                            };

        private byte[] indices = {
                              0, 4, 5, 0, 5, 1,
                              1, 5, 6, 1, 6, 2,
                              2, 6, 7, 2, 7, 3,
                              3, 7, 4, 3, 4, 0,
                              4, 7, 6, 4, 6, 5,
                              3, 0, 1, 3, 1, 2
                              };

        public Cube()
        {
            ByteBuffer byteBuf = ByteBuffer.AllocateDirect(vertices.Length * 4);
            byteBuf.Order(ByteOrder.NativeOrder());
            mVertexBuffer = byteBuf.AsFloatBuffer();
            mVertexBuffer.Put(vertices);
            mVertexBuffer.Position(0);

            byteBuf = ByteBuffer.AllocateDirect(colors.Length * 4);
            byteBuf.Order(ByteOrder.NativeOrder());
            mColorBuffer = byteBuf.AsFloatBuffer();
            mColorBuffer.Put(colors);
            mColorBuffer.Position(0);

            mIndexBuffer = ByteBuffer.AllocateDirect(indices.Length);
            mIndexBuffer.Put(indices);
            mIndexBuffer.Position(0);
        }

        public void draw(IGL10 gl) {  
           
           
            gl.GlFrontFace(GL10.GlCw);
            
            gl.GlVertexPointer(3, GL10.GlFloat, 0, mVertexBuffer);
            gl.GlColorPointer(4, GL10.GlFloat, 0, mColorBuffer);
            
            gl.GlEnableClientState(GL10.GlVertexArray);
            gl.GlEnableClientState(GL10.GlColorArray);
             
            gl.GlDrawElements(GL10.GlTriangles, 36, GL10.GlUnsignedByte, 
                            mIndexBuffer);
                
            gl.GlDisableClientState(GL10.GlVertexArray);
            gl.GlDisableClientState(GL10.GlColorArray);
    }
    }
}
