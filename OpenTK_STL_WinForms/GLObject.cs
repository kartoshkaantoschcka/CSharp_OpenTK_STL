using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;

namespace OpenTK_STL_WinForms
{

    class GLObject
    {
        public float[] _vertices;
        public int countTriangles = 0;

        public bool isLoadFigureInBuffer = false;
        public bool isLoadFigure = false;

        private STLBinary stlObject = new STLBinary();

        public int _vertexBufferObject;

        public Shader _shader;
        public int _vaoModel;

        public float angleX = 0;
        public float angleZ = 0;
        public float transX = 0;
        public float transY = 0;
        public float scale  = 1;
        public float processLoadingFile 
        {
            get => stlObject._processLoading;
        }

        public float minZ = 0;

        public string pathApp = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";

        public Vector2 _WidthHeigh = new Vector2(800, 600);

        public Matrix4 matrixModel = Matrix4.Identity;
        public Matrix4 matrixView  = Matrix4.Identity;
        public Matrix4 matrixProj;

        protected Vector3 lightColor;

        public GLObject()
        {
            matrixProj = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, _WidthHeigh.X / _WidthHeigh.Y, 0.01f, 10f);
            lightColor = new Vector3(0.9f, 0.1f, 0.9f);
        }

        public GLObject(string pFileName) : this()
        {
            stlObject = new STLBinary();
            stlObject.OnEndLoadFile += OnEndLoadFile;
            stlObject.ReadBinaryFile(pFileName);
        }

        private void OnEndLoadFile(object sender, EventArgs e)
        {
            countTriangles = stlObject.countTriangles;
            _vertices = stlObject._vertices;
            minZ = stlObject.minZ - 0.001f;
            isLoadFigure = true;
        }

        public void LoadObjectGL()
        {
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _shader = new Shader(pathApp + "Shaders/shader.vert", pathApp + "Shaders/lighting.frag");

            {
                _vaoModel = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel);

                var positionLocation = _shader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);

                var normalLocation = _shader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            }
        }

        public void RenderObjectGL()
        {
            GL.BindVertexArray(_vaoModel);

            _shader.Use();
            matrixModel = Matrix4.CreateTranslation(transX, transY, -minZ) *
                            Matrix4.CreateScale(scale);
            matrixView = Matrix4.CreateFromAxisAngle(new Vector3(0, 0, 1), angleZ) *
                            Matrix4.CreateFromAxisAngle(new Vector3(1, 0, 0), -angleX) *
                            Matrix4.CreateTranslation(0, 0, -2.0f);

            _shader.SetMatrix4("model",      matrixModel);
            _shader.SetMatrix4("view",       matrixView);
            _shader.SetMatrix4("projection", matrixProj);

            _shader.SetVector3("viewPos", new Vector3(0, 0, 2));

            _shader.SetVector3("material.ambient",  new Vector3(1.0f, 0.5f, 0.31f));
            _shader.SetVector3("material.diffuse",  new Vector3(1.0f, 0.5f, 0.31f));
            _shader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
            _shader.SetFloat("material.shininess", 32.0f);

            Vector3 ambientColor = lightColor * new Vector3(0.2f);
            Vector3 diffuseColor = lightColor * new Vector3(0.5f);

            _shader.SetVector3("light.position", new Vector3(0, -2, -2));
            _shader.SetVector3("light.ambient", ambientColor);
            _shader.SetVector3("light.diffuse", diffuseColor);
            _shader.SetVector3("light.specular", new Vector3(1.0f, 1.0f, 1.0f));

            GL.DrawArrays(PrimitiveType.Triangles, 0, countTriangles * 3);
        }
    }
}
