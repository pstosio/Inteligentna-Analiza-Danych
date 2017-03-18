using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.DataVisualization.Charting;



namespace IAD_1
{
    /// <summary>
    /// Interaction logic for ChartTypeColumn.xaml
    /// </summary>
    public partial class ChartTypeColumnIris : Window
    {


        public ChartTypeColumnIris(List<double> _setosa, List<double> _versicolor, List<double> _virginica, int _feature)
        {
            InitializeComponent();

            LoadColumnChartDataIris(_setosa, _versicolor, _virginica, _feature);
        }

        private void LoadColumnChartDataIris(List<double> _setosa, List<double> _versicolor, List<double> _virginica, int _feature)
        {
            // double - x (wartość); int - y (ilość elementów)
            KeyValuePair<double, int>[] keyValuePairSetosa = new KeyValuePair<double, int>[81]; // 41 : od 4.0 - 8.0 co 0.1
            KeyValuePair<double, int>[] keyValuePairVersicolor = new KeyValuePair<double, int>[81];
            KeyValuePair<double, int>[] keyValuePairVirginica = new KeyValuePair<double, int>[81];

            // Posortowanie listy z elementami
            _setosa.Sort();
            _versicolor.Sort();
            _virginica.Sort();

            int counter = 0;
            int keyCounter = 0;

            double rangeFrom =0;
            double rangeTo = 0;

            switch (_feature)
            {
                case 0:
                    rangeFrom = 4.0;
                    rangeTo = 8.0;
                    break;

                case 1:
                    rangeFrom = 1.5;
                    rangeTo = 4.5;
                    break;

                case 2:
                    rangeFrom = 0.8;
                    rangeTo = 7.0;
                    break;

                case 3:
                    rangeFrom = 0;
                    rangeTo = 3.0;
                    break;
            }
            

            for (double i = rangeFrom; i <= rangeTo; i += 0.1)
            {
                foreach (double element in _setosa)
                {
                    if (element == Math.Round(i, 1))
                    {
                        counter++;
                    }
                }

                keyValuePairSetosa[keyCounter] = new KeyValuePair<double, int>(Math.Round(i, 1), counter);

                counter = 0;
                keyCounter++;
            }


            counter = 0;
            keyCounter = 0;

            for (double i = rangeFrom; i <= rangeTo; i += 0.1)
            {
                foreach (double element in _versicolor)
                {
                    if (element == Math.Round(i, 1))
                    {
                        counter++;
                    }
                }

                keyValuePairVersicolor[keyCounter] = new KeyValuePair<double, int>(Math.Round(i, 1), counter);

                counter = 0;
                keyCounter++;
            }

            counter = 0;
            keyCounter = 0;

            for (double i = rangeFrom; i <= rangeTo; i += 0.1)
            {
                foreach (double element in _virginica)
                {
                    if (element == Math.Round(i, 1))
                    {
                        counter++;
                    }
                }

                keyValuePairVirginica[keyCounter] = new KeyValuePair<double, int>(Math.Round(i, 1), counter);

                counter = 0;
                keyCounter++;
            }

            ((ColumnSeries)chart.Series[0]).ItemsSource = keyValuePairSetosa;
            ((ColumnSeries)chart.Series[1]).ItemsSource = keyValuePairVersicolor;
            ((ColumnSeries)chart.Series[2]).ItemsSource = keyValuePairVirginica;


        }
    }
}
