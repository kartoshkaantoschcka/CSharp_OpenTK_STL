using OpenTK.Mathematics;

namespace OpenTK_STL_WinForms
{
    class GLObjectCoordinatSystem : GLObject
    {
        public GLObjectCoordinatSystem() : base()
        {
            _vertices = new float[]
            {
                // Position          Normal
                -1.0f, -1.0f, 0.0f,  0.0f,  0.0f, -1.0f, // Front face
                 1.0f, -1.0f, 0.0f,  0.0f,  0.0f, -1.0f,
                 1.0f,  1.0f, 0.0f,  0.0f,  0.0f, -1.0f,
                 1.0f,  1.0f, 0.0f,  0.0f,  0.0f, -1.0f,
                -1.0f,  1.0f, 0.0f,  0.0f,  0.0f, -1.0f,
                -1.0f, -1.0f, 0.0f,  0.0f,  0.0f, -1.0f,

                 0.1f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f, // Left face
                 0.1f,  0.5f, -0.1f, -1.0f,  0.0f,  0.0f,
                 0.1f, -0.0f, -0.1f, -1.0f,  0.0f,  0.0f,
                 0.1f, -0.0f, -0.1f, -1.0f,  0.0f,  0.0f,
                 0.1f, -0.0f,  0.5f, -1.0f,  0.0f,  0.0f,
                 0.1f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,
            };

            countTriangles = 2;
            minZ = 0;
            lightColor = new Vector3(0.1f, 0.9f, 0.1f);
        }
    }
}
