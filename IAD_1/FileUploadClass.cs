using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IAD_1
{
    class FileUploadClass
    {
        string fileName;
        string tmpLine;
        public FileUploadClass(string _fileName)
        {
            fileName = _fileName;
        }

        public List<double> uploadData(string _listNum)
        {
            const char separator = ' '; // <== Spacja oddziela wartość od etykiety w pliku z danymi
            List<double> valuesList = new List<double>();
            string[] splittedLine = null;
            string label = null;

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                while ((tmpLine = streamReader.ReadLine()) != null)
                {
                    splittedLine = tmpLine.Split(separator); // <== Podzielona linia na wartość i etykietę
                    // [0] - wartość
                    // [1] - etykieta
                    try
                    {
                        label = splittedLine[1].Substring(0, 1);
                        if (label == _listNum)
                            valuesList.Add(Double.Parse((splittedLine[0]), System.Globalization.CultureInfo.InvariantCulture));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }

            return valuesList;
        }

        public List<double> uploadIrisData(string _irisType, int _featureNum)
        {
            const char separator = ','; // <== Spacja oddziela wartość od etykiety w pliku z danymi

            string[] splittedLine = null;
            string irisTypeInLine = null;

            //  4 caechy Irisów
            List<double> sepalLengthList = new List<double>();
            List<double> sepalWidthList = new List<double>();
            List<double> petalLengthList = new List<double>();
            List<double> petalWidthList = new List<double>();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                while ((tmpLine = streamReader.ReadLine()) != null)
                {
                    splittedLine = tmpLine.Split(separator); // <== Podzielona linia na wartość i etykietę
                    
                    try
                    {
                        irisTypeInLine = splittedLine[4].Substring(5, 2);

                        if (irisTypeInLine == _irisType)
                        {
                            // 4 listy z cechami
                            sepalLengthList.Add(Double.Parse((splittedLine[0]), System.Globalization.CultureInfo.InvariantCulture));
                            sepalWidthList.Add(Double.Parse((splittedLine[1]), System.Globalization.CultureInfo.InvariantCulture));
                            petalLengthList.Add(Double.Parse((splittedLine[2]), System.Globalization.CultureInfo.InvariantCulture));
                            petalWidthList.Add(Double.Parse((splittedLine[3]), System.Globalization.CultureInfo.InvariantCulture));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }

            switch(_featureNum)
            {
                case 0:
                    return sepalLengthList;
                case 1:
                    return sepalWidthList;
                case 2:
                    return petalLengthList;
                case 3:
                    return petalWidthList;
            }

            return new List<double>();
        }
    }
}
