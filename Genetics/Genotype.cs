using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public enum GeneType {
        Allosome,
        Autosome
    }

    public struct Genotype {
        public int GeneCount;
        public int GeneLength;
        public float CrossoverRate;
        public float MutationRate;
        public CrossoverType CrossoverType;
        public MutationType MutationType;
        public GeneType GeneType;

        public Genotype(int geneCount, int geneLength, float crossoverRate, float mutationRate, CrossoverType crossoverType, MutationType mutationType, GeneType geneType) {
            GeneType = geneType;
            GeneCount = geneCount;
            GeneLength = geneLength;

            CrossoverRate = crossoverRate;
            MutationRate = mutationRate;

            CrossoverType = crossoverType;
            MutationType = mutationType;
        }
    }
}
