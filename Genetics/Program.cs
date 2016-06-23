using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    class Program
    {
        private const int _genomeSize = 10;
        private const int _geneLength = 4;

        private static Genotype[] Karyotype = {
            new Genotype(3, 2, 1.0f, 0.1f, CrossoverType.SinglePoint, MutationType.Random, GeneType.Allosome), // Sex Chromosome
            new Genotype(8, 5, 1.0f, 0.1f, CrossoverType.DoublePoint, MutationType.Swap, GeneType.Autosome),   // Stat Chromosome
        };

        private static Genotype[] SimpleKaryotype = {
            new Genotype(10, 4, 1.0f, 1.0f, CrossoverType.DoublePoint, MutationType.Swap, GeneType.Autosome)
        };

        static void Main(string[] args)
        {
            Population pop1 = new Population(Karyotype, 2, 4);

            Population pop = new Population(SimpleKaryotype, 0, 100);

            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine($"-------------------------------GENERATION {i}------------------------------------");
                foreach (Organism organism in pop1)
                {
                    Console.WriteLine($"Organism {organism.Age}");

                    foreach (Chromosome chromosome in organism)
                    {
                        Console.WriteLine();

                        Console.Write("X-Point:    |");
                        foreach (Gene g in chromosome)
                        {
                            Console.Write(g.CrossPoint ? "|".PadLeft(chromosome.Genotype.GeneLength + 1, 'X') : "|".PadLeft(chromosome.Genotype.GeneLength + 1, ' '));
                        }
                        Console.WriteLine();

                        Console.Write("Chromosome: ");
                        Console.WriteLine(chromosome.ToString());

                        Console.Write("Mutation:   |");
                        foreach (Gene g in chromosome)
                        {
                            Console.Write(g.Mutation ? "|".PadLeft(chromosome.Genotype.GeneLength + 1, 'X') : "|".PadLeft(chromosome.Genotype.GeneLength + 1, ' '));
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
                Console.WriteLine($"------------------------------END GENERATION {i}---------------------------------");

                Console.ReadLine();

                pop1.Update();

            }
           /* Chromosome parent1 = new Chromosome(SimpleKaryotype[0]);
            Chromosome parent2 = new Chromosome(SimpleKaryotype[0]);

            Chromosome child1 = pop.Crossover(parent1, parent2);
            Chromosome child2 = pop.Crossover(parent1, parent2);

            Console.Write("Parent 1: ");
            Console.WriteLine(parent1.ToString());
            Console.Write("Parent 2: ");
            Console.WriteLine(parent2.ToString());
            Console.WriteLine();

            Console.Write("X-Point1: |");
            for (int i = 0; i < _genomeSize; i++) {
                Console.Write(child1[i].crossPoint ? "|".PadLeft(_geneLength + 1, 'X') : "|".PadLeft(_geneLength + 1, ' '));
            }
            Console.WriteLine();
            Console.Write("Child  1: ");
            Console.WriteLine(child1.ToString());
            Console.Write("Mutation: |");
            for (int i = 0; i < _genomeSize; i++) {
                Console.Write(child1[i].mutation ? "|".PadLeft(_geneLength + 1, 'X') : "    |".PadLeft(_geneLength + 1, ' '));
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("X-Point2: |");
            for (int i = 0; i < _genomeSize; i++) {
                Console.Write(child2[i].crossPoint ? "|".PadLeft(_geneLength + 1, 'X') : "|".PadLeft(_geneLength + 1, ' '));
            }
            Console.WriteLine();
            Console.Write("Child  2: ");
            Console.WriteLine(child2.ToString());
            Console.Write("Mutation: |");
            for (int i = 0; i < _genomeSize; i++) {
                Console.Write(child2[i].mutation ? "|".PadLeft(_geneLength + 1, 'X') : "|".PadLeft(_geneLength + 1, ' '));
            }*/

            Console.Read();
        }
    }
}
