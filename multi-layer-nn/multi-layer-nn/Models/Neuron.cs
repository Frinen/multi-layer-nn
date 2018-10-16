using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multi_layer_nn.Models
{
    public class Neuron
    {
        public List<double> Inputs;
        public List<double> Weights;
        public double Output;
        public double Error;
        public double Eta;

        public Neuron()
        {
            Eta = 0.7;
            Inputs = new List<double>();
            Weights = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i < 26; i++)
            {

                if (i == 0)
                {
                    Weights.Add(rnd.NextDouble() * -1);
                }
                else
                {
                    Weights.Add(rnd.NextDouble());
                }
            }
            

        }

        public void SetWeight(List<double> _weights)
        {
            Weights = _weights;
        }

        public void SetInputs(List<double> _inputs)
        {
            Inputs = _inputs;
        }

        public void Calculate(List<double> input)
        {
            Inputs = input;
            double Sum = 0;
            for (int i = 0; i < Inputs.Count; i++)
            {
                Sum += Inputs[i] * Weights[i];
            }
            if (Sum < 0)
            {
                Output = 0;

            }
            else
            {
                Output = 1;
            }
        }
    }
}
