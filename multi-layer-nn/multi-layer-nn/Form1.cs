using multi_layer_nn.Models;
using multi_layer_nn.Train;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi_layer_nn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<int> sizes = new List<int>() {2,1};
            _preceptron = new Preceptron(3, sizes);
        }
        Preceptron _preceptron;
        private void button1_Click(object sender, EventArgs e)
        {
            TrainData trainData = new TrainData()
            {
                Data = new List<List<double>>()
            };

            trainData.Data.Add(new List<double>() {1.0, 0.0, 0.0 });
            trainData.Data.Add(new List<double>() {1.0, 1.0, 0.0 });
            trainData.Data.Add(new List<double>() {1.0, 0.0, 1.0 });
            trainData.Data.Add(new List<double>() {1.0, 1.0, 1.0 });
            
            DesiresData desiresData = new DesiresData()
            {
                Desires = new List<List<double>>()
            };

            desiresData.Desires.Add(new List<double>() { 0 });
            desiresData.Desires.Add(new List<double>() { 1 });
            desiresData.Desires.Add(new List<double>() { 1 });
            desiresData.Desires.Add(new List<double>() { 0 });

            _preceptron.Train(trainData, desiresData);
        }
    }
}
