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
    public partial class ChartTypeColumn : Window
    {
        public ChartTypeColumn(List<double> _list, double _shiftFactor)
        {
            InitializeComponent();

            LoadColumnChartData(_list, _shiftFactor);
        }

        private void LoadColumnChartData(List<double> _list, double _shiftFactor)
        {
            // double - x; int - y (ilość elementów)
            KeyValuePair<double, int>[] keyValuePair = new KeyValuePair<double, int>[_list.Count];
            int treshold_Counter = 0;
            int elementsInTreshold = 0;
            bool treshold_sets = false;
            double treshold_Left = 0;
            double treshold_Right = 0;
            double shift_factor = _shiftFactor;

            // Posortowanie listy z elementami
            _list.Sort();
        
            foreach(double elements in _list)
            {
                // Wartością musi być określony przedział, a ilością ilość elementów mieszczących się w przedziale
                if (elements < treshold_Right)
                {
                    if (treshold_sets == false)
                    {
                        treshold_Left = elements;
                        treshold_Right = treshold_Left + shift_factor;

                        treshold_sets = true;
                        treshold_Counter++;
                    }

                    elementsInTreshold++;
                }
                else
                {
                    keyValuePair[treshold_Counter] = new KeyValuePair<double, int>(
                        Math.Round(((treshold_Left)),2), 
                        elementsInTreshold);

                    treshold_sets = false;
                    elementsInTreshold = 1;

                    if (treshold_sets == false)
                    {
                        treshold_Left = elements;
                        treshold_Right = treshold_Left + shift_factor;

                        treshold_sets = true;
                        treshold_Counter++;
                    }
                }
                
            }

            ((ColumnSeries)chart.Series[0]).ItemsSource = keyValuePair;
            
        }

    }
}
