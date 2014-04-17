using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class EvolutionarySolver : Solver
    {
        private const double MutationProbability = 0.01;
        private const double MistakesFactor = 1000;
        private const int PopulationSize = 300;
        private const int InitiPopulationIterationCount = 1000;

        public override Grid Solve(Grid initialGrid)
        {
            Random r = new Random();
            var population = GetInitialPopulation(initialGrid);
            while (true)
            {
                var nextGeneration = Crossover(SelectForCrossover(population));
                foreach (var individual in nextGeneration)
                {
                    if (r.NextDouble() < MutationProbability)
                        Mutate(individual);
                }
                population = SelectNewPopulation(population, nextGeneration);

            }
        }

        private Grid[] SelectNewPopulation(Grid[] population, Grid[] nextGeneration)
        {
            throw new NotImplementedException();
        }

        public Grid[] GetInitialPopulation(Grid initialGrid)
        {
            var population = new List<Grid>( );
            for(int i = 0; i < PopulationSize; i++)
                population.Add(GetNewInitialSolution(initialGrid));
            return population.OrderBy(GetFitness).ToArray();
        }

        public Grid GetNewInitialSolution(Grid initialGrid)
        {
            Random r = new Random();
            Grid g = new Grid(initialGrid);
            for (int i = 0; i < InitiPopulationIterationCount;i++ )
            {
                var n = r.Next(1, g.Size+1);
                var row = r.Next(0, g.Size);
                var col = r.Next(0, g.Size);
                if (g.Get(row, col) != 0)
                {
                    g.Place(n,row,col);
                   
                }
            }
            return g;
        }


        public double GetFitness(Grid g)
        {
            return g.GetNumMistakes()*MistakesFactor + g.GetEmptyPositions().Count;
        }

        public Grid[] Crossover(Grid[] population)
        {
            throw new NotImplementedException();
        } 

        public Grid Mutate(Grid g)
        {
            throw new NotImplementedException();
        }

        public Grid[] SelectForCrossover(Grid[] population)
        {
          
            var selected = new Grid[population.Length];
            var popFitness = GetPopulationFitness(population);
            Random r = new Random();
        }

        private double[] GetPopulationFitness(Grid[] population)
        {
            double sum = 
        }
    }
}
