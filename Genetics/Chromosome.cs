using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public class Chromosome : IEnumerable {
        private Gene[] _genes = null;

        public readonly Genotype Genotype;

        private static Random _random = new Random((int)DateTime.Now.Ticks);

        public Chromosome(Genotype genotype) {
            Genotype = genotype;

            _genes = new Gene[Genotype.GeneCount];

            for (int i = 0; i < Genotype.GeneCount; i++) {
                _genes[i] = Gene.RandomGene(Genotype.GeneLength);
            }
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            builder.Append("|");

            foreach (Gene g in _genes) {
                builder.AppendFormat("{0}|", g.ToString());
            }

            return builder.ToString();
        }

        public Gene this[int i] {
            get {
                return _genes[i];
            }
            set {
                _genes[i] = value;
            }
        }

        public void Mutate() {
            int locus1 = _random.Next(0, Genotype.GeneCount);
            int locus2 = _random.Next(0, Genotype.GeneCount);

            Gene gene1 = _genes[locus1];
            Gene gene2 = _genes[locus2];

            switch (Genotype.MutationType) {
                case MutationType.Random:
                    _genes[locus1] = Gene.RandomGene(Genotype.GeneLength);
                    _genes[locus1].SetMutation();
                    break;

                case MutationType.Swap:
                    _genes[locus1] = gene2;
                    _genes[locus2] = gene1;

                    _genes[locus1].SetMutation();
                    _genes[locus2].SetMutation();
                    break;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _genes.GetEnumerator();
        }
    }
}
