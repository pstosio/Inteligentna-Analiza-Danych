using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms.DataVisualization.Charting;

namespace IAD_1
{
    /// <summary>
    /// Klasa slużąca do przekazania obliczeń statystycznych 
    /// </summary>
    class AccountantClass
    {
        #region Fields
        List<double> list1 { get; set; }
        List<double> list2 { get; set; }
        List<double> list3 { get; set; }
        public double averageList1 { get; set; } // Wartość średnia z listy 1
        public double averageList2 { get; set; } // Wartość średnia z listy 2
        public double averageList3 { get; set; } // Wartość średnia z listy 3
        public double varianceList1 { get; set; } // Wariancja z listy 1
        public double varianceList2 { get; set; } // Wariancja z listy 2
        public double varianceList3 { get; set; } // Wariancja z listy 3
        public double stdDev1 { get; set; } // Odchylenie standardowe 1
        public double stdDev2 { get; set; } // Odchylenie standardowe 2
        public double stdDev3 { get; set; } // Odchylenie standardowe 3
        public double factorZ { get; set; } // Współczynnik "Z"
        public double probability { get; set; } // Prawdopodobieństwo
        public double slant1 { get; set; } // Skośność 1
        public double slant2 { get; set; } // Skośność 2
        public double slant3 { get; set; } // Skośność 3 
        #endregion

        public AccountantClass(List<double> _list1, List<double> _list2)
        {
            list1 = _list1;
            list2 = _list2;

            averageList1 = this.countAverage(_list1);
            averageList2 = this.countAverage(_list2);

            varianceList1 = this.countVariance(_list1, averageList1);
            varianceList2 = this.countVariance(_list2, averageList2);

            stdDev1 = this.countStandardDeviation(varianceList1);
            stdDev2 = this.countStandardDeviation(varianceList2);

            factorZ = this.countFactorZ();

            probability = this.countProbability();
        }

        /// <summary>
        /// Konstruktor pod dane irisów - setosa, versicolor i virginica
        /// </summary>
        /// <param name="_list1"></param>
        /// <param name="_list2"></param>
        /// <param name="_list3"></param>
        public AccountantClass(List<double> _list1, List<double> _list2, List<double> _list3)
        {
            list1 = _list1;
            list2 = _list2;
            list3 = _list3;

            // Średnie
            averageList1 = this.countAverage(_list1);
            averageList2 = this.countAverage(_list2);
            averageList3 = this.countAverage(_list3);

            // Wariancje
            varianceList1 = this.countVariance(_list1, averageList1);
            varianceList2 = this.countVariance(_list2, averageList2);
            varianceList3 = this.countVariance(_list3, averageList3);

            // Odchylenia standardowe
            stdDev1 = this.countStandardDeviation(varianceList1);
            stdDev2 = this.countStandardDeviation(varianceList2);
            stdDev3 = this.countStandardDeviation(varianceList3);

            // Wskaźniki skośności
            slant1 = this.countSlant(averageList1, stdDev1, this.getDominant(list1));
            slant2 = this.countSlant(averageList2, stdDev2, this.getDominant(list2));
            slant3 = this.countSlant(averageList3, stdDev3, this.getDominant(list3));
        }

        /// <summary>
        /// Funkcja służy do zwrócenia średniej wartości z listy
        /// </summary>
        /// <param name="_list"> list wartości</param>
        /// <returns> średnia </returns>
        public double countAverage(List<double> _list)
        {
            return _list.Average();
        }

        /// <summary>
        /// Funkcja licząca wariancją - funkcja statyczna
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="_average"></param>
        /// <returns></returns>
        public double countVariance(List<double> _list, double _average)
        {
            double sumaKwadratów = new double();

            // Suma kwadratów różnic
            foreach(double element in _list)
            {
                sumaKwadratów += Math.Pow((element - _average), 2);
            }

            // Wariancja
            return sumaKwadratów / _list.Count;
        }

        /// <summary>
        /// Fukcja licząca odchylenie standardowe
        /// </summary>
        /// <param name="_Variance"></param>
        /// <returns></returns>
        public double countStandardDeviation(double _Variance)
        {
            return Math.Sqrt(_Variance);
        }

        /// <summary>
        /// Współczynnik 'z'
        /// </summary>
        /// <returns></returns>
        public double countFactorZ()
        {
            return (averageList1 - averageList2) / Math.Sqrt((varianceList1 / list1.Count) + (varianceList2 / list2.Count));
        }

        /// <summary>
        /// Prawdopodobieństwo - rozkład normalny
        /// </summary>
        /// <returns></returns>
        public double countProbability()
        {
            Chart chart = new Chart();

            return chart.DataManipulator.Statistics.NormalDistribution(factorZ);
        }

        /// <summary>
        /// Funkcja oblicza dominantę
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        private double getDominant(List<double> _list)
        {
            List<double> listTmp = new List<double>();
            Dictionary<double, int> dictTmp = new Dictionary<double, int>();
            listTmp = _list;
            listTmp.Sort();

            foreach(double element in listTmp)
            {
                if (!dictTmp.ContainsKey(element))
                    dictTmp.Add(element, 1);
                else
                    dictTmp[element] += 1;
            }

            return dictTmp.OrderByDescending(x => x.Value).FirstOrDefault().Key;
        }

        /// <summary>
        /// Funkcja oblicza klasyczny wskaźnik skośności
        /// </summary>
        /// <param name="_avg"> średnia </param>
        /// <param name="_dev"> odchylenie standardowe </param>
        /// <param name="_dom"> dominanta </param>
        /// <returns></returns>
        private double countSlant(double _avg, double _dev, double _dom)
        {
            return (_avg - _dom) / _dev;
        }
    }
}
