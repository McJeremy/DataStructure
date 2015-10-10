using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    /// <summary>
    /// 矩阵类
    /// </summary>
    public class Matrix
    {

        #region fields

        private double[,] _matrix;

        #endregion

        #region 构造

        /// <summary>
        /// 构造n阶矩阵
        /// </summary>
        /// <param name="iC"></param>
        public Matrix(int n)
        {
            _matrix = new double[n, n];
        }

        /// <summary>
        /// 构造m*n矩阵
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        public Matrix(int m, int n)
        {
            _matrix = new double[m, n];
        }

        /// <summary>
        /// 从某个矩阵构造
        /// </summary>
        /// <param name="m"></param>
        public Matrix(Matrix m)
        {
            _matrix = new double[m.Row, m.Col];
            double[,] _tmp = m.Elements;
            for (int i = 0; i < m.Row; i++)
            {
                for (int j = 0; j < m.Col; j++)
                {
                    _matrix[i, j] = _tmp[i, j];
                }
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// 矩阵的元素(数组表示)
        /// </summary>
        public double[,] Elements
        {
            get { return _matrix; }
        }

        public int Row
        {
            get { return _matrix.GetLength(0); }
        }

        public int Col
        {
            get { return _matrix.GetLength(1); }
        }

        public double this[int iRow, int iCol]
        {
            get {
                return _matrix[iRow, iCol];
            }
            set { 
                _matrix[iRow, iCol] = value;
            }
        }

        #endregion

        #region methods

        public void SetValue(double d)
        {
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Col; j++)
                {
                    _matrix[i, j] = d;
                }
            }
        }

        /// <summary>
        /// 设置为单位矩阵
		///  单位矩阵：它是个方阵，从左上角到右下角的对角线（称为主对角线）上的元素均为1以外全都为0。
        /// </summary>
        public void SetUnit()
        {
            if (Col != Row)
            {
                throw new Exception("矩阵不是方阵");
            }
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Col; j++)
                {
                    _matrix[i, j] = (i == j) ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// 是否对称矩阵
		/// 对称矩阵：元素以主对角线为对称轴对应相等的矩阵
        /// </summary>
        /// <returns></returns>
        public bool IsSymmetric()
        {
            if (Col != Row)
            {
                return false;
            }
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Col; j++)
                {
                    if (this[i, j] != this[j, i])
                        return false;
                }
            }
            return true;
        }

        #region 矩阵变换

        /// <summary>
        /// 矩阵变换之交换两行
        /// </summary>
        public Matrix Exchange(int iFirstRow, int iLastRow)
        {
            double tmp;
            for (var i = 0; i < Col; i++)
            {
                tmp = _matrix[iFirstRow, i];
                _matrix[iFirstRow, i] = _matrix[iLastRow, i];
                _matrix[iLastRow, i] = tmp;
            }
            return this;
        }

        /// <summary>
        /// 矩阵变换之某一行*某值
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="mul"></param>
        public Matrix Exchange(int iRow, double mul)
        {
            for (var i = 0; i < Col; i++)
            { 
                _matrix[iRow,i] *= mul;
            }
            return this;
        }

        /// <summary>
        /// 矩阵变换之某一行*某值,然后加到另一行上
        /// </summary>
        /// <param name="iFirstRow"></param>
        /// <param name="mul"></param>
        /// <param name="iToRow"></param>
        public Matrix Exchange(int iFirstRow, double mul, int iToRow)
        {
            for (var i = 0; i < Col; i++)
            {
                _matrix[iToRow, i] += (_matrix[iFirstRow, i] * mul);
            }
            return this;
        }

        #endregion

        /// <summary>
        /// 矩阵相加 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.Col != B.Col || A.Row != B.Row)
            {
                throw new Exception("相加的两个矩阵需要行列相等");
            }

            Matrix _tmp = new Matrix(A.Row, A.Col);

            for (var i = 0; i < A.Row; i++)
            {
                for (var j = 0; j < A.Col; j++)
                {
                    _tmp[i, j] = (A[i, j] + B[i, j]);
                }
            }
            return _tmp;
        }

        /// <summary>
        /// 矩阵相减 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.Col != B.Col || A.Row != B.Row)
            {
                throw new Exception("相加的两个矩阵需要行列相等");
            }

            Matrix _tmp = new Matrix(A.Row, A.Col);

            for (var i = 0; i < A.Row; i++)
            {
                for (var j = 0; j < A.Col; j++)
                {
                    _tmp[i, j] = (A[i, j] - B[i, j]);
                }
            }
            return _tmp;
        }

        /// <summary>
        /// 矩阵相乘
		/// mn矩阵 * np矩阵  = mp矩阵
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Col != B.Row)
            {
                throw new Exception("左乘矩阵的列数不等于右乘矩阵的行数.");
            }

            //mn矩阵 * np矩阵  = mp矩阵
            Matrix _tmp = new Matrix(A.Row, B.Col);

            double tmp;
            for (var i = 0; i < A.Row; i++)
            {
                tmp = 0;
                for (var j = 0; j < B.Col; j++)
                {
                    for (var k = 0; k < A.Col; k++)
                    {
                        /*
                         *  举例,新矩阵的第1行,第1列的值计算方式:
                         *  左矩阵的第一行的每一列,与右矩阵的第一列的每一行,分别对应相乘,并将结果加起来.
                         *  同理,第2行,第3列的计算方式:
                         *  左矩阵的第2行的每一列,与右矩阵的第3列的第一行.
                         */
                        //此时,左矩阵的列,其实就是右矩阵的行.
                        tmp += A[i, k] * B[k, j];
                    }
                    _tmp[i, j] = tmp;
                }
            }
            return _tmp;
        }


        #endregion

        public override string ToString()
        {
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Col; j++)
                {
                    Console.Write("{0,5}", this[i, j]);
                }
                Console.WriteLine();
            }
            return "";
        }
    }
}
