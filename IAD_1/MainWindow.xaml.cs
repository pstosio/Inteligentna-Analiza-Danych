using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
// --> Charting libraries 
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.DataVisualization.Charting;
// <--
// --> BackgroudWorker library
using System.ComponentModel;
// <--

namespace IAD_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // BackgroudWorker
        private readonly BackgroundWorker worker = new BackgroundWorker();
        // Listy z wartościami etykiet 1 i 2
        List<double> listLabel1 = new List<double>();
        List<double> listLabel2 = new List<double>();
        // Klasa odpowiadająca za obliczenia
        private AccountantClass accountant;

        // Listy z wartościami 4 cech 3 klas irisów

        /******   Setosa ******/
        List<double> seSepalLength = new List<double>(); // sepal lenght
        List<double> seSepalWidth = new List<double>(); // sepal width
        List<double> sePetalLendth = new List<double>(); // petal lenght
        List<double> sePetalWidth = new List<double>(); // petal width


        /******   VERSICOLOR ******/
        List<double> veSepalLength = new List<double>(); // sepal lenght
        List<double> veSepalWidth = new List<double>(); // sepal width
        List<double> vePetalLendth = new List<double>(); // petal lenght
        List<double> vePetalWidth = new List<double>(); // petal width


        /******   VIRINICA ******/
        List<double> viSepalLength = new List<double>(); // sepal lenght
        List<double> viSepalWidth = new List<double>(); // sepal width
        List<double> viPetalLendth = new List<double>(); // petal lenght
        List<double> viPetalWidth = new List<double>(); // petal width

        private AccountantClass accountantSepalLen;
        private AccountantClass accountantSepalWid;
        private AccountantClass accountantPetalLen;
        private AccountantClass accountantPetalWid;

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            string[] commandLineArgsTab = Environment.GetCommandLineArgs();

            // index 0 - system information with process path .exe
            // index 1 - file name filled in project properties
            FileUploadClass fileUpload = new FileUploadClass(commandLineArgsTab[1]);
            try
            {
                listLabel1 = fileUpload.uploadData("1");
                listLabel2 = fileUpload.uploadData("2");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Environment.Exit(0);
            }
            finally
            {
                textBox_Count.Text = String.Format("{0}", listLabel1.Count + listLabel2.Count);
                textBox_Label1_Count.Text = String.Format("{0}", listLabel1.Count);
                textBox_Label2_Count.Text = String.Format("{0}", listLabel2.Count);

                foreach (double element in listLabel1)
                {
                    textBox_Label1.Text += element.ToString() + "\n";
                }

                foreach (double element in listLabel2)
                {
                    textBox_Label2.Text += element.ToString() + "\n";
                }

                /* Niezaimplementowany backgroud worker
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;

                worker.RunWorkerAsync();
                */

                // Odblokowanie przycisku uruchamiającego przeliczanie.
                button_loadData.IsEnabled = false;
                button_Count.IsEnabled = true;
                button_histogram_1.IsEnabled = true;
                button_histogram_2.IsEnabled = true;
            }

        }

        #region BackgroudWorker methods
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // run all background tasks here
            
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
        }
        #endregion

        private void button_Count_Click(object sender, RoutedEventArgs e)
        {
            accountant = new AccountantClass(listLabel1, listLabel2);

            // Średnie
            textBox_average_1.Text   = Math.Round(accountant.averageList1, 3).ToString();
            textBox_average_2.Text   = Math.Round(accountant.averageList2, 3).ToString();

            // Wariancje
            textBox_Variance_1.Text  = Math.Round(accountant.varianceList1, 3).ToString();
            textBox_Variance_2.Text  = Math.Round(accountant.varianceList2, 3).ToString();

            // Odchylenia standardowe
            textBox_Variation_1.Text = Math.Round(accountant.stdDev1, 3).ToString();
            textBox_Variation_2.Text = Math.Round(accountant.stdDev2, 3).ToString();

            // Współczynnik z 
            textBox_z.Text = accountant.factorZ.ToString();

            // Prawdopodobieństwo - rozkład normalny
            textBox_probability.Text = accountant.probability.ToString();
        }

        private void button_hist1_Click(object sender, RoutedEventArgs e)
        {
            ChartTypeColumn columnChart = new ChartTypeColumn(listLabel1, Double.Parse(textBox_shiftFactor.Text, CultureInfo.InvariantCulture));
            columnChart.Owner = this;
            columnChart.Show();
        }

        private void button_hist2_Click(object sender, RoutedEventArgs e)
        {
            ChartTypeColumn columnChart = new ChartTypeColumn(listLabel2, Double.Parse(textBox_shiftFactor.Text, CultureInfo.InvariantCulture));
            columnChart.Owner = this;
            columnChart.Show();
        }

        private void button_load_iris_Click(object sender, RoutedEventArgs e)
        {
            string[] commandLineArgsTab = Environment.GetCommandLineArgs();

            // index 0 - system information with process path .exe
            // index 2 - file name filled in project properties -irisy

            // Dla Irysów są 3 klasy i 4 cechy
            FileUploadClass fileUpload = new FileUploadClass(commandLineArgsTab[2]);
            try
            {
                seSepalLength = fileUpload.uploadIrisData("se", 0); // setosa sepal length
                seSepalWidth = fileUpload.uploadIrisData("se", 1); // setosa sepal width
                sePetalLendth = fileUpload.uploadIrisData("se", 2); // setosa petal length
                sePetalWidth = fileUpload.uploadIrisData("se", 3); // setosa petal width

                veSepalLength = fileUpload.uploadIrisData("ve", 0); // versicolor sepal length
                veSepalWidth = fileUpload.uploadIrisData("ve", 1); // versicolor sepal width
                vePetalLendth = fileUpload.uploadIrisData("ve", 2); // versicolor petal length
                vePetalWidth = fileUpload.uploadIrisData("ve", 3); // versicolor petal width

                viSepalLength = fileUpload.uploadIrisData("vi", 0); // virginica sepal length
                viSepalWidth = fileUpload.uploadIrisData("vi", 1); // virginica sepal width
                viPetalLendth = fileUpload.uploadIrisData("vi", 2); // virginica petal length
                viPetalWidth = fileUpload.uploadIrisData("vi", 3); // virginica petal width

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {


                textBox_Count_Iris.Text = String.Format("{0}", seSepalLength.Count + seSepalWidth.Count + sePetalLendth.Count + sePetalWidth.Count +
                                                               veSepalLength.Count + veSepalWidth.Count + vePetalLendth.Count + vePetalWidth.Count +
                                                               viSepalLength.Count + viSepalWidth.Count + viPetalLendth.Count + viPetalWidth.Count);

                
                textBox_setosa_Count.Text = String.Format("{0}", seSepalLength.Count + seSepalWidth.Count + sePetalLendth.Count + sePetalWidth.Count);
                textBox_versicolor_Count.Text = String.Format("{0}", veSepalLength.Count + veSepalWidth.Count + vePetalLendth.Count + vePetalWidth.Count);
                textBox_virginica_Count.Text = String.Format("{0}", viSepalLength.Count + viSepalWidth.Count + viPetalLendth.Count + viPetalWidth.Count);

                #region Wypełnianie texBoxów
                /***** SETOSA ****/
                seSepalLength.Sort();
                foreach (double element in seSepalLength)
                {
                    textBox_se_0.Text += element.ToString() + "\n";
                }
                seSepalWidth.Sort();
                foreach (double element in seSepalWidth)
                {
                    textBox_se_1.Text += element.ToString() + "\n";
                }
                sePetalLendth.Sort();
                foreach (double element in sePetalLendth)
                {
                    textBox_se_2.Text += element.ToString() + "\n";
                }
                sePetalWidth.Sort();
                foreach (double element in sePetalWidth)
                {
                    textBox_se_3.Text += element.ToString() + "\n";
                }

                /**** VERSICOLOR ****/
                veSepalLength.Sort();
                foreach (double element in veSepalLength)
                {
                    textBox_ve_0.Text += element.ToString() + "\n";
                }
                veSepalWidth.Sort();
                foreach (double element in veSepalWidth)
                {
                    textBox_ve_1.Text += element.ToString() + "\n";
                }
                vePetalLendth.Sort();
                foreach (double element in vePetalLendth)
                {
                    textBox_ve_2.Text += element.ToString() + "\n";
                }
                vePetalWidth.Sort();
                foreach (double element in vePetalWidth)
                {
                    textBox_ve_3.Text += element.ToString() + "\n";
                }

                /**** VIRGINICA ****/
                viSepalLength.Sort();
                foreach (double element in viSepalLength)
                {
                    textBox_vi_0.Text += element.ToString() + "\n";
                }
                viSepalWidth.Sort();
                foreach (double element in viSepalWidth)
                {
                    textBox_vi_1.Text += element.ToString() + "\n";
                }
                viPetalLendth.Sort();
                foreach (double element in viPetalLendth)
                {
                    textBox_vi_2.Text += element.ToString() + "\n";
                }
                viPetalWidth.Sort();
                foreach (double element in viPetalWidth)
                {
                    textBox_vi_3.Text += element.ToString() + "\n";
                }
                #endregion

                button_load_iris.IsEnabled = false;
                
                button_histogram_iris_0.IsEnabled = true;
                button_histogram_iris_1.IsEnabled = true;
                button_histogram_iris_2.IsEnabled = true;
                button_histogram_iris_3.IsEnabled = true;
                button_iris_Count.IsEnabled = true;


            }

        }
        #region Iris histograms
        private void button_histogram_0_Click(object sender, RoutedEventArgs e)
        {
            ChartTypeColumnIris columnChart = new ChartTypeColumnIris(seSepalLength, veSepalLength, viSepalLength, 0);
            columnChart.Owner = this;
            columnChart.Show();
        }
        
        private void button_histogram_1_Click(object sender, RoutedEventArgs e)
        {
            ChartTypeColumnIris columnChart = new ChartTypeColumnIris(seSepalWidth, veSepalWidth, viSepalWidth, 1);
            columnChart.Owner = this;
            columnChart.Show();
        }

        private void button_histogram_2_Click(object sender, RoutedEventArgs e)
        {
            ChartTypeColumnIris columnChart = new ChartTypeColumnIris(sePetalLendth, vePetalLendth, viPetalLendth, 2);
            columnChart.Owner = this;
            columnChart.Show();
        }

        private void button_histogram_3_Click(object sender, RoutedEventArgs e)
        {
            ChartTypeColumnIris columnChart = new ChartTypeColumnIris(sePetalWidth, vePetalWidth, viPetalWidth, 3);
            columnChart.Owner = this;
            columnChart.Show();
        }
        #endregion

        private void button_iris_Count_Click(object sender, RoutedEventArgs e)
        {
            #region Sepal Length
            accountantSepalLen = new AccountantClass(seSepalLength, veSepalLength, viSepalLength);

            // Średnie
            textBox_av_se .Text = Math.Round(accountantSepalLen.averageList1, 3).ToString();
            textBox_av_ve.Text = Math.Round(accountantSepalLen.averageList2, 3).ToString();
            textBox_av_vi.Text = Math.Round(accountantSepalLen.averageList3, 3).ToString();

            // Wariancje
            textBox_variance_se.Text = Math.Round(accountantSepalLen.varianceList1, 3).ToString();
            textBox_variance_ve.Text = Math.Round(accountantSepalLen.varianceList2, 3).ToString();
            textBox_variance_vi.Text = Math.Round(accountantSepalLen.varianceList3, 3).ToString();

            // Odchylenia standardowe
            textBox_deviation_se .Text = Math.Round(accountantSepalLen.stdDev1, 3).ToString();
            textBox_deviation_ve.Text = Math.Round(accountantSepalLen.stdDev2, 3).ToString();
            textBox_deviation_vi.Text = Math.Round(accountantSepalLen.stdDev3, 3).ToString();

            // Wskażniki skośności
            textBox_slant_se_0.Text = Math.Round(accountantSepalLen.slant1, 3).ToString();
            textBox_slant_ve_0.Text = Math.Round(accountantSepalLen.slant2, 3).ToString();
            textBox_slant_vi_0.Text = Math.Round(accountantSepalLen.slant3, 3).ToString();
            #endregion

            #region Sepal Width
            accountantSepalWid = new AccountantClass(seSepalWidth, veSepalWidth, viSepalWidth);

            // Średnie
            textBox_av_se_1.Text = Math.Round(accountantSepalWid.averageList1, 3).ToString();
            textBox_av_ve_1.Text = Math.Round(accountantSepalWid.averageList2, 3).ToString();
            textBox_av_vi_1.Text = Math.Round(accountantSepalWid.averageList3, 3).ToString();

            // Wariancje
            textBox_variance_se_1.Text = Math.Round(accountantSepalWid.varianceList1, 3).ToString();
            textBox_variance_ve_1.Text = Math.Round(accountantSepalWid.varianceList2, 3).ToString();
            textBox_variance_vi_1.Text = Math.Round(accountantSepalWid.varianceList3, 3).ToString();

            // Odchylenia standardowe
            textBox_deviation_se_1.Text = Math.Round(accountantSepalWid.stdDev1, 3).ToString();
            textBox_deviation_ve_1.Text = Math.Round(accountantSepalWid.stdDev2, 3).ToString();
            textBox_deviation_vi_1.Text = Math.Round(accountantSepalWid.stdDev3, 3).ToString();

            // Wskażniki skośności
            textBox_slant_se_1.Text = Math.Round(accountantSepalWid.slant1, 3).ToString();
            textBox_slant_ve_1.Text = Math.Round(accountantSepalWid.slant2, 3).ToString();
            textBox_slant_vi_1.Text = Math.Round(accountantSepalWid.slant3, 3).ToString();
            #endregion

            #region Petal Length
            accountantPetalLen = new AccountantClass(sePetalLendth, vePetalLendth, viPetalLendth);

            // Średnie
            textBox_av_se_2.Text = Math.Round(accountantPetalLen.averageList1, 3).ToString();
            textBox_av_ve_2.Text = Math.Round(accountantPetalLen.averageList2, 3).ToString();
            textBox_av_vi_2.Text = Math.Round(accountantPetalLen.averageList3, 3).ToString();

            // Wariancje
            textBox_variance_se_2.Text = Math.Round(accountantPetalLen.varianceList1, 3).ToString();
            textBox_variance_ve_2.Text = Math.Round(accountantPetalLen.varianceList2, 3).ToString();
            textBox_variance_vi_2.Text = Math.Round(accountantPetalLen.varianceList3, 3).ToString();

            // Odchylenia standardowe
            textBox_deviation_se_2.Text = Math.Round(accountantPetalLen.stdDev1, 3).ToString();
            textBox_deviation_ve_2.Text = Math.Round(accountantPetalLen.stdDev2, 3).ToString();
            textBox_deviation_vi_2.Text = Math.Round(accountantPetalLen.stdDev3, 3).ToString();

            // Wskażniki skośności
            textBox_slant_se_2.Text = Math.Round(accountantPetalLen.slant1, 3).ToString();
            textBox_slant_ve_2.Text = Math.Round(accountantPetalLen.slant2, 3).ToString();
            textBox_slant_vi_2.Text = Math.Round(accountantPetalLen.slant3, 3).ToString();
            #endregion

            #region Petal Width
            accountantPetalWid = new AccountantClass(sePetalWidth, vePetalWidth, viPetalWidth);

            // Średnie
            textBox_av_se_3.Text = Math.Round(accountantPetalWid.averageList1, 3).ToString();
            textBox_av_ve_3.Text = Math.Round(accountantPetalWid.averageList2, 3).ToString();
            textBox_av_vi_3.Text = Math.Round(accountantPetalWid.averageList3, 3).ToString();

            // Wariancje
            textBox_variance_se_3.Text = Math.Round(accountantPetalWid.varianceList1, 3).ToString();
            textBox_variance_ve_3.Text = Math.Round(accountantPetalWid.varianceList2, 3).ToString();
            textBox_variance_vi_3.Text = Math.Round(accountantPetalWid.varianceList3, 3).ToString();

            // Odchylenia standardowe
            textBox_deviation_se_3.Text = Math.Round(accountantPetalWid.stdDev1, 3).ToString();
            textBox_deviation_ve_3.Text = Math.Round(accountantPetalWid.stdDev2, 3).ToString();
            textBox_deviation_vi_3.Text = Math.Round(accountantPetalWid.stdDev3, 3).ToString();

            // Wskażniki skośności
            textBox_slant_se_3.Text = Math.Round(accountantPetalWid.slant1, 3).ToString();
            textBox_slant_ve_3.Text = Math.Round(accountantPetalWid.slant2, 3).ToString();
            textBox_slant_vi_3.Text = Math.Round(accountantPetalWid.slant3, 3).ToString();
            #endregion
        }
    }
}
