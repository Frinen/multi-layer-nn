using multi_layer_nn.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multi_layer_nn.Models
{
    public class Preceptron
    {
        public List<List<Neuron>> Network;
        public double Eta = 0.2;

        public Preceptron(int InputCount, List<int> sizes)
        {
            Network = new List<List<Neuron>>();
            for(int i =0;i<sizes.Count; i++)
            {
                List<Neuron> temp = new List<Neuron>();
                for (int j = 0; j < sizes[i]; j++)
                {
                    temp.Add(new Neuron(InputCount));
                }
                Network.Add(temp);
                InputCount = sizes[i] + 1;
            }
        }

        public void Train(TrainData train, DesiresData desires)
        {
            for(int i = 0; i<train.Data.Count; i++)
            {
                Forward(train.Data[i]);
            }
            

            
        }

        public void Forward(List<double> train)
        {
            List<double> currentIuput;
            List<double> nextIuput;
            currentIuput = train;
            for (int i = 0; i < Network.Count; i++)
            {
                nextIuput = new List<double>();
                nextIuput.Add(1.0);
                for (int j = 0; j< Network[i].Count; j++)
                {
                    Network[i][j].Calculate(currentIuput);
                    nextIuput.Add(Network[i][j].Output);
                }
                currentIuput = nextIuput;
            }
        }

        public void Backward(List<double> desires)
        {
            for (int i = Network.Count - 1; i >= 0; i--)
            {
                if (i == Network.Count - 1)
                {
                    for (int j = 0; j < Network[i].Count; j++)
                    {
                        double dif = Network[i][j].Output * (1.0 - Network[i][j].Output) * (desires[j] - Network[i][j].Output);
                        for (int p = 0; p < Network[i][j].Weights.Count; p++)
                        {
                            Network[i][j].Weights[p] += Eta * dif * Network[i-1][p].Output;
                        }
                    }
                }
                else
                {

                }
            }
        }
    }
}
