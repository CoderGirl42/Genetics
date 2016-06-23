using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public enum CrossoverType {
        SinglePoint,
        DoublePoint,
        Random
    }

    public enum MutationType {
        Swap,
        Random
    }

    public class Population : IEnumerable<Organism>
    {
        private int _maxAge = 0;
        private Genotype[] _karyotype; 

        private List<Organism> _organisms = new List<Organism>();

        public int PopulationSize { get { return _organisms.Count; } }

        private Random _random = new Random((int)DateTime.Now.Ticks);

        public Population(Genotype[] karyotype, int initialSize, int maxAge) {
            _maxAge = maxAge;
            _karyotype = karyotype;

            for (int i = 0; i < initialSize; i++) {
                _organisms.Add(new Organism(_karyotype, maxAge));
            }
        }

        public void Update()
        {
            List<Organism>[] parents = new List<Organism>[2];

            // Update organisms.
            foreach (Organism o in _organisms) {
                o.Update();
            }

            // Remove Dead Organisms.
            _organisms = _organisms.Where(o => o.IsAlive).ToList<Organism>();

            // Shuffle Organisms.
            _organisms.Shuffle<Organism>();

            // Split Organisms into to parental groups and sort in order of fitness.
            parents[0] = _organisms.GetRange(0, _organisms.Count / 2).OrderBy(o => o.Fitness()).ToList();
            parents[1] = _organisms.GetRange(_organisms.Count / 2, _organisms.Count / 2).OrderBy(o => o.Fitness()).ToList();

            // Loop through each parent matching.
            for (int parent = 0; parent < parents[0].Count; parent++) {
                // Spawn a child organism.
                Organism child = new Organism(_karyotype, _maxAge);

                // Crossover and mutate each chromosome.
                for (int chromosome = 0; chromosome < _karyotype.Length; chromosome++) {
                    child[chromosome] = Crossover(parents[0][parent][chromosome], parents[1][parent][chromosome]);

                    if (_random.NextDouble() <= child[chromosome].Genotype.MutationRate) {
                        child[chromosome].Mutate();
                    }
                }

                _organisms.Add(child);
            }
        }

        public Chromosome Crossover(Chromosome parent1, Chromosome parent2) {
            Chromosome child = new Chromosome(parent1.Genotype);
            int p1 = _random.Next(0, child.Genotype.GeneCount - 1);
            int p2 = _random.Next(p1 + 1, child.Genotype.GeneCount);

            for (int i = 0; i < child.Genotype.GeneCount; i++) {
                switch (child.Genotype.CrossoverType)  {
                    case CrossoverType.SinglePoint:
                        child[i].Copy((i <= p1 ? parent1[i] : parent2[i]));
                        if (i == p1) child[i].SetCrossPoint();
                        break;
                    case CrossoverType.DoublePoint:
                        child[i].Copy((i <= p1 || i >= p2 ? parent1[i] : parent2[i]));
                        if (i == p1) child[i].SetCrossPoint();
                        if (i == p2) child[i].SetCrossPoint();
                        break;
                    case CrossoverType.Random:
                        child[i].Copy(_random.Next(0, 2) == 1 ? parent1[i] : parent2[i]);
                        break;
                }
            }

            //if (_random.NextDouble() <= child.Genotype.MutationRate) {
            //    child.Mutate();
            //}

            return child;
        }

        public Organism this[int i] {
            get { return _organisms[i]; }
        }

        public IEnumerator<Organism> GetEnumerator()
        {
            return _organisms.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _organisms.GetEnumerator();
        }
    }
}
