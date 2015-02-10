using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MathСalculator.Domain.Methods
{
     public class GausMethod
    {
        public uint RowCount;
        public uint ColumCount;
        public double[][] Matrix { get; set; }
        public double[] RightPart { get; set; }
        public double[] Answer { get; set; }

        public GausMethod(uint Row, uint Colum)
        {
            RightPart = new double[Row];
            Answer = new double[Row];
            Matrix = new double[Row][];
            for (int i = 0; i < Row; i++)
                Matrix[i] = new double[Colum];
            RowCount = Row;
            ColumCount = Colum;

            //обнулим массив
            for (int i = 0; i < Row; i++)
            {
                Answer[i] = 0;
                RightPart[i] = 0;
                for (int j = 0; j < Colum; j++)
                    Matrix[i][j] = 0;
            }
        }

        private void SortRows(int sortIndex)
        {

            var maxElement = Matrix[sortIndex][sortIndex];
            var maxElementIndex = sortIndex;
            for (var i = sortIndex + 1; i < RowCount; i++)
            {
                if (!(Matrix[i][sortIndex] > maxElement)) continue;
                maxElement = Matrix[i][sortIndex];
                maxElementIndex = i;
            }

            if (maxElementIndex <= sortIndex) return;
            var temp = RightPart[maxElementIndex];
            RightPart[maxElementIndex] = RightPart[sortIndex];
            RightPart[sortIndex] = temp;

            for (var i = 0; i < ColumCount; i++)
            {
                temp = Matrix[maxElementIndex][i];
                Matrix[maxElementIndex][i] = Matrix[sortIndex][i];
                Matrix[sortIndex][i] = temp;
            }
        
        }

        public int SolveMatrix()
        {
            if (RowCount != ColumCount)
                return 1; //нет решения

            for (int i = 0; i < RowCount - 1; i++)
            {
                SortRows(i);
               
                for (int j = i + 1; j < RowCount; j++)
                {
                    if (Matrix[i][i] == 0) continue;
                    double multElement = Matrix[j][i] / Matrix[i][i];
                    for (int k = i; k < ColumCount; k++)
                        Matrix[j][k] -= Matrix[i][k] * multElement;
                    RightPart[j] -= RightPart[i] * multElement;
                    //для нулевого главного элемента просто пропускаем данный шаг
                }
               
            }
           
            //ищем решение
            for (int i = (int)(RowCount - 1); i >= 0; i--)
            {
                Answer[i] = RightPart[i];

                for (int j = (int)(RowCount - 1); j > i; j--)
                    Answer[i] -= Matrix[i][j] * Answer[j];

                if (Matrix[i][i] == 0)
                    if (RightPart[i] == 0)
                        return 2; //множество решений
                    else
                        return 1; //нет решения

                Answer[i] /= Matrix[i][i];

            }
            return 0;
        }



        public override String ToString()
        {
            String S = "";
            for (int i = 0; i < RowCount; i++)
            {
                S += "\r\n";
                for (int j = 0; j < ColumCount; j++)
                {
                    S += Matrix[i][j].ToString("F04") + "\t";
                }

                S += "\t" + Answer[i].ToString("F08");
                S += "\t" + RightPart[i].ToString("F04");
            }
            return S;
        }

    }
}
