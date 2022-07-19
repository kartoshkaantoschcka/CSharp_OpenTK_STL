using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace OpenTK_STL_WinForms
{
    class STLBinary
    {
        public int countTriangles = 0;

        public float max_X;
        public float min_X;
        public float max_Y;
        public float min_Y;
        public float max_Z;
        public float min_Z;

        public float middle_X;
        public float middle_Y;
        public float middle_Z;

        public float scale_X;
        public float scale_Y;
        public float scale_Z;

        public float minZ = float.MaxValue;

        public float _processLoading = 0;

        private string _filePath;

        public float[] _vertices;

        List<TriangleMesh> meshList = new List<TriangleMesh>();

        public bool isLoadFigureInBuffer = false;
        public bool _isLoadFigure = false;
        public event EventHandler OnEndLoadFile;

        public void ReadBinaryFile(string filePath)
        {
            _filePath = filePath;

            Thread loadFileThread = new Thread(new ThreadStart(_ReadBinaryFile));
            loadFileThread.IsBackground = true;
            loadFileThread.Start();
        }

        private void _ReadBinaryFile()
        {
            meshList = new List<TriangleMesh>();
            int numOfMesh = 0;
            int i = 0;
            int byteIndex = 0;
            byte[] fileBytes = File.ReadAllBytes(_filePath);

            byte[] temp = new byte[4];

            max_X = float.MinValue;
            min_X = float.MaxValue;
            max_Y = float.MinValue;
            min_Y = float.MaxValue;
            max_Z = float.MinValue;
            min_Z = float.MaxValue;

            if (fileBytes.Length > 120)
            {

                temp[0] = fileBytes[80];
                temp[1] = fileBytes[81];
                temp[2] = fileBytes[82];
                temp[3] = fileBytes[83];

                numOfMesh = System.BitConverter.ToInt32(temp, 0);

                byteIndex = 83;

                byte[] bt = new byte[4];

                float getval()
                {
                    for (int r = 0; r < 4; r++) bt[r] = fileBytes[++byteIndex];
                    return BitConverter.ToSingle(bt, 0);
                };

                for (i = 0; i < numOfMesh; i++)
                {
                    _processLoading = i / 2.0f / (float)numOfMesh;

                    TriangleMesh newMesh = new TriangleMesh();

                    try
                    {
                        for (int vr = 0; vr < 4; vr++)
                        {
                            if(vr == 0)
                            {
                                newMesh.norm[vr] = new Vector3(getval(), getval(), getval());
                                newMesh.norm[1] = newMesh.norm[0];
                                newMesh.norm[2] = newMesh.norm[0];
                            }
                            else
                            {
                                newMesh.vert[vr - 1] = new Vector3(getval(), getval(), getval());
                            }
                        }

                        max_X = (new List<float>() { max_X, newMesh.vert[0].X, newMesh.vert[1].X, newMesh.vert[2].X }).Max();
                        min_X = (new List<float>() { min_X, newMesh.vert[0].X, newMesh.vert[1].X, newMesh.vert[2].X }).Min();
                        max_Y = (new List<float>() { max_Y, newMesh.vert[0].Y, newMesh.vert[1].Y, newMesh.vert[2].Y }).Max();
                        min_Y = (new List<float>() { min_Y, newMesh.vert[0].Y, newMesh.vert[1].Y, newMesh.vert[2].Y }).Min();
                        max_Z = (new List<float>() { max_Z, newMesh.vert[0].Z, newMesh.vert[1].Z, newMesh.vert[2].Z }).Max();
                        min_Z = (new List<float>() { min_Z, newMesh.vert[0].Z, newMesh.vert[1].Z, newMesh.vert[2].Z }).Min();

                        byteIndex += 2;
                    }
                    catch
                    {
                        break;
                    }

                    meshList.Add(newMesh);
                }
            }
            else
            {
            }

            middle_X = min_X + ((max_X - min_X) / 2.0f);
            middle_Y = min_Y + ((max_Y - min_Y) / 2.0f);
            middle_Z = min_Z + ((max_Z - min_Z) / 2.0f);

            scale_X = Math.Abs(1.0f / (max_X - min_X));
            scale_Y = Math.Abs(1.0f / (max_Y - min_Y));
            scale_Z = Math.Abs(1.0f / (max_Z - min_Z));

            float scale = Math.Max(Math.Max(scale_X, scale_Y), scale_Z);

            _vertices = new float[numOfMesh * 3 * 3 * 2];

            int ind = 0;
            for (int k = 0; k < numOfMesh; k++)
            {
                _processLoading = 0.5f + k / 2.0f / (float)numOfMesh;

                ind = k * 3 * 3 * 2;

                _vertices[ind + 0] = (meshList[k].vert[0].X - middle_X) * scale;
                _vertices[ind + 1] = (meshList[k].vert[0].Y - middle_Y) * scale;
                _vertices[ind + 2] = (meshList[k].vert[0].Z - middle_Z) * scale;
                _vertices[ind + 3] = meshList[k].norm[0].X;
                _vertices[ind + 4] = meshList[k].norm[0].Y;
                _vertices[ind + 5] = meshList[k].norm[0].Z;

                _vertices[ind + 6] = (meshList[k].vert[1].X - middle_X) * scale;
                _vertices[ind + 7] = (meshList[k].vert[1].Y - middle_Y) * scale;
                _vertices[ind + 8] = (meshList[k].vert[1].Z - middle_Z) * scale;
                _vertices[ind + 9] = meshList[k].norm[1].X;
                _vertices[ind + 10] = meshList[k].norm[1].Y;
                _vertices[ind + 11] = meshList[k].norm[1].Z;

                _vertices[ind + 12] = (meshList[k].vert[2].X - middle_X) * scale;
                _vertices[ind + 13] = (meshList[k].vert[2].Y - middle_Y) * scale;
                _vertices[ind + 14] = (meshList[k].vert[2].Z - middle_Z) * scale;
                _vertices[ind + 15] = meshList[k].norm[2].X;
                _vertices[ind + 16] = meshList[k].norm[2].Y;
                _vertices[ind + 17] = meshList[k].norm[2].Z;

                minZ = MathF.Min(MathF.Min(MathF.Min(minZ, _vertices[ind + 2]), _vertices[ind + 8]), _vertices[ind + 14]);
            }

            countTriangles = numOfMesh;
            _processLoading = 1.0f;

            OnEndLoadFile?.Invoke(this, EventArgs.Empty);
        }
    }
}
